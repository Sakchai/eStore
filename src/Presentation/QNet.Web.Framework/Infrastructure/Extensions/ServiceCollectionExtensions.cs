using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Net;
using EasyCaching.Core;
using EasyCaching.InMemory;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using QNet.Core;
using QNet.Core.Caching;
using QNet.Core.Configuration;
using QNet.Core.Data;
using QNet.Core.Domain;
using QNet.Core.Domain.Common;
using QNet.Core.Domain.Security;
using QNet.Core.Http;
using QNet.Core.Infrastructure;
using QNet.Core.Redis;
using QNet.Data;
using QNet.Services.Authentication;
using QNet.Services.Authentication.External;
using QNet.Services.Common;
using QNet.Services.Logging;
using QNet.Services.Plugins;
using QNet.Services.Security;
using QNet.Services.Tasks;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Mvc.Routing;
using QNet.Web.Framework.Security.Captcha;
using QNet.Web.Framework.Themes;
using StackExchange.Profiling.Storage;
using Swashbuckle.AspNetCore.Swagger;
using WebMarkupMin.AspNetCore2;
using WebMarkupMin.NUglify;

namespace QNet.Web.Framework.Infrastructure.Extensions
{
    /// <summary>
    /// Represents extensions of IServiceCollection
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add services to the application and configure service provider
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        /// <param name="configuration">Configuration of the application</param>
        /// <param name="hostingEnvironment">Hosting environment</param>
        /// <returns>Configured service provider</returns>
        public static IServiceProvider ConfigureApplicationServices(this IServiceCollection services,
            IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            //most of API providers require TLS 1.2 nowadays
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            //add QNetConfig configuration parameters
            var nopConfig = services.ConfigureStartupConfig<QNetConfig>(configuration.GetSection("QNet"));

            //add hosting configuration parameters
            services.ConfigureStartupConfig<HostingConfig>(configuration.GetSection("Hosting"));

            //add accessor to HttpContext
            services.AddHttpContextAccessor();

            //create default file provider
            CommonHelper.DefaultFileProvider = new QNetFileProvider(hostingEnvironment);

            //initialize plugins
            var mvcCoreBuilder = services.AddMvcCore();
            mvcCoreBuilder.PartManager.InitializePlugins(nopConfig);

            //create engine and configure service provider
            var engine = EngineContext.Create();
            var serviceProvider = engine.ConfigureServices(services, configuration, nopConfig);

            //further actions are performed only when the database is installed
            if (!DataSettingsManager.DatabaseIsInstalled)
                return serviceProvider;

            //initialize and start schedule tasks
            TaskManager.Instance.Initialize();
            TaskManager.Instance.Start();

            //log application start
            engine.Resolve<ILogger>().Information("Application started");

            //install plugins
            engine.Resolve<IPluginService>().InstallPlugins();

            return serviceProvider;
        }

        /// <summary>
        /// Create, bind and register as service the specified configuration parameters 
        /// </summary>
        /// <typeparam name="TConfig">Configuration parameters</typeparam>
        /// <param name="services">Collection of service descriptors</param>
        /// <param name="configuration">Set of key/value application configuration properties</param>
        /// <returns>Instance of configuration parameters</returns>
        public static TConfig ConfigureStartupConfig<TConfig>(this IServiceCollection services, IConfiguration configuration) where TConfig : class, new()
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            //create instance of config
            var config = new TConfig();

            //bind it to the appropriate section of configuration
            configuration.Bind(config);

            //and register it as a service
            services.AddSingleton(config);

            return config;
        }

        /// <summary>
        /// Register HttpContextAccessor
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        public static void AddHttpContextAccessor(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        /// <summary>
        /// Adds services required for anti-forgery support
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        public static void AddAntiForgery(this IServiceCollection services)
        {
            //override cookie name
            services.AddAntiforgery(options =>
            {
                options.Cookie.Name = $"{QNetCookieDefaults.Prefix}{QNetCookieDefaults.AntiforgeryCookie}";

                //whether to allow the use of anti-forgery cookies from SSL protected page on the other store pages which are not
                options.Cookie.SecurePolicy = DataSettingsManager.DatabaseIsInstalled && EngineContext.Current.Resolve<SecuritySettings>().ForceSslForAllPages
                    ? CookieSecurePolicy.SameAsRequest : CookieSecurePolicy.None;
            });
        }

        /// <summary>
        /// Adds services required for application session state
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        public static void AddHttpSession(this IServiceCollection services)
        {
            services.AddSession(options =>
            {
                options.Cookie.Name = $"{QNetCookieDefaults.Prefix}{QNetCookieDefaults.SessionCookie}";
                options.Cookie.HttpOnly = true;

                //whether to allow the use of session values from SSL protected page on the other store pages which are not
                options.Cookie.SecurePolicy = DataSettingsManager.DatabaseIsInstalled && EngineContext.Current.Resolve<SecuritySettings>().ForceSslForAllPages
                    ? CookieSecurePolicy.SameAsRequest : CookieSecurePolicy.None;
            });
        }

        /// <summary>
        /// Adds services required for themes support
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        public static void AddThemes(this IServiceCollection services)
        {
            if (!DataSettingsManager.DatabaseIsInstalled)
                return;

            //themes support
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.ViewLocationExpanders.Add(new ThemeableViewLocationExpander());
            });
        }

        /// <summary>
        /// Adds SwaggerGen
        /// </summary>
        /// <param name="services">Add Swagger Gen</param>
        public static void AddQNetSwaggerGen(this IServiceCollection services)
        {
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "QNet API", Version = "v1" });
            });
        }
        /// <summary>
        /// Adds data protection services
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        public static void AddQNetDataProtection(this IServiceCollection services)
        {
            //check whether to persist data protection in Redis
            var nopConfig = services.BuildServiceProvider().GetRequiredService<QNetConfig>();
            if (nopConfig.RedisEnabled && nopConfig.UseRedisToStoreDataProtectionKeys)
            {
                //store keys in Redis
                services.AddDataProtection().PersistKeysToRedis(() =>
                {
                    var redisConnectionWrapper = EngineContext.Current.Resolve<IRedisConnectionWrapper>();
                    return redisConnectionWrapper.GetDatabase(nopConfig.RedisDatabaseId ?? (int)RedisDatabaseNumber.DataProtectionKeys);
                }, QNetCachingDefaults.RedisDataProtectionKey);
            }
            else
            {
                var dataProtectionKeysPath = CommonHelper.DefaultFileProvider.MapPath("~/App_Data/DataProtectionKeys");
                var dataProtectionKeysFolder = new System.IO.DirectoryInfo(dataProtectionKeysPath);

                //configure the data protection system to persist keys to the specified directory
                services.AddDataProtection().PersistKeysToFileSystem(dataProtectionKeysFolder);
            }
        }

        /// <summary>
        /// Adds authentication service
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        public static void AddQNetAuthentication(this IServiceCollection services)
        {
            //set default authentication schemes
            var authenticationBuilder = services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = QNetAuthenticationDefaults.AuthenticationScheme;
                options.DefaultScheme = QNetAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = QNetAuthenticationDefaults.ExternalAuthenticationScheme;
            });

            //add main cookie authentication
            authenticationBuilder.AddCookie(QNetAuthenticationDefaults.AuthenticationScheme, options =>
            {
                options.Cookie.Name = $"{QNetCookieDefaults.Prefix}{QNetCookieDefaults.AuthenticationCookie}";
                options.Cookie.HttpOnly = true;
                options.LoginPath = QNetAuthenticationDefaults.LoginPath;
                options.AccessDeniedPath = QNetAuthenticationDefaults.AccessDeniedPath;

                //whether to allow the use of authentication cookies from SSL protected page on the other store pages which are not
                options.Cookie.SecurePolicy = DataSettingsManager.DatabaseIsInstalled && EngineContext.Current.Resolve<SecuritySettings>().ForceSslForAllPages
                    ? CookieSecurePolicy.SameAsRequest : CookieSecurePolicy.None;
            });

            //add external authentication
            authenticationBuilder.AddCookie(QNetAuthenticationDefaults.ExternalAuthenticationScheme, options =>
            {
                options.Cookie.Name = $"{QNetCookieDefaults.Prefix}{QNetCookieDefaults.ExternalAuthenticationCookie}";
                options.Cookie.HttpOnly = true;
                options.LoginPath = QNetAuthenticationDefaults.LoginPath;
                options.AccessDeniedPath = QNetAuthenticationDefaults.AccessDeniedPath;

                //whether to allow the use of authentication cookies from SSL protected page on the other store pages which are not
                options.Cookie.SecurePolicy = DataSettingsManager.DatabaseIsInstalled && EngineContext.Current.Resolve<SecuritySettings>().ForceSslForAllPages
                    ? CookieSecurePolicy.SameAsRequest : CookieSecurePolicy.None;
            });

            //register and configure external authentication plugins now
            var typeFinder = new WebAppTypeFinder();
            var externalAuthConfigurations = typeFinder.FindClassesOfType<IExternalAuthenticationRegistrar>();
            var externalAuthInstances = externalAuthConfigurations
                .Select(x => (IExternalAuthenticationRegistrar)Activator.CreateInstance(x));

            foreach (var instance in externalAuthInstances)
                instance.Configure(authenticationBuilder);
        }

        /// <summary>
        /// Add and configure MVC for the application
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        /// <returns>A builder for configuring MVC services</returns>
        public static IMvcBuilder AddQNetMvc(this IServiceCollection services)
        {
            //add basic MVC feature
            var mvcBuilder = services.AddMvc();

            //we use legacy (from previous versions) routing logic
            mvcBuilder.AddMvcOptions(options => options.EnableEndpointRouting = false);

            //sets the default value of settings on MvcOptions to match the behavior of asp.net core mvc 2.2
            mvcBuilder.SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var nopConfig = services.BuildServiceProvider().GetRequiredService<QNetConfig>();
            if (nopConfig.UseSessionStateTempDataProvider)
            {
                //use session-based temp data provider
                mvcBuilder.AddSessionStateTempDataProvider();
            }
            else
            {
                //use cookie-based temp data provider
                mvcBuilder.AddCookieTempDataProvider(options =>
                {
                    options.Cookie.Name = $"{QNetCookieDefaults.Prefix}{QNetCookieDefaults.TempDataCookie}";

                    //whether to allow the use of cookies from SSL protected page on the other store pages which are not
                    options.Cookie.SecurePolicy = DataSettingsManager.DatabaseIsInstalled && EngineContext.Current.Resolve<SecuritySettings>().ForceSslForAllPages
                        ? CookieSecurePolicy.SameAsRequest : CookieSecurePolicy.None;
                });
            }

            //MVC now serializes JSON with camel case names by default, use this code to avoid it
            mvcBuilder.AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            //add custom display metadata provider
            mvcBuilder.AddMvcOptions(options => options.ModelMetadataDetailsProviders.Add(new QNetMetadataProvider()));

            //add custom model binder provider (to the top of the provider list)
            mvcBuilder.AddMvcOptions(options => options.ModelBinderProviders.Insert(0, new QNetModelBinderProvider()));

            //add fluent validation
            mvcBuilder.AddFluentValidation(configuration =>
            {
                //register all available validators from QNet assemblies
                var assemblies = mvcBuilder.PartManager.ApplicationParts
                    .OfType<AssemblyPart>()
                    .Where(part => part.Name.StartsWith("QNet", StringComparison.InvariantCultureIgnoreCase))
                    .Select(part => part.Assembly);
                configuration.RegisterValidatorsFromAssemblies(assemblies);

                //implicit/automatic validation of child properties
                configuration.ImplicitlyValidateChildProperties = true;
            });

            //register controllers as services, it'll allow to override them
            mvcBuilder.AddControllersAsServices();

            return mvcBuilder;
        }

        /// <summary>
        /// Register custom RedirectResultExecutor
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        public static void AddQNetRedirectResultExecutor(this IServiceCollection services)
        {
            //we use custom redirect executor as a workaround to allow using non-ASCII characters in redirect URLs
            services.AddSingleton<IActionResultExecutor<RedirectResult>, QNetRedirectResultExecutor>();
        }

        /// <summary>
        /// Register base object context
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        public static void AddQNetObjectContext(this IServiceCollection services)
        {
            services.AddDbContextPool<QNetObjectContext>(optionsBuilder =>
            {
                //optionsBuilder.UseSqlServerWithLazyLoading(services);
                optionsBuilder.UseMySQLWithLazyLoading(services);
            });
        }

        /// <summary>
        /// Add and configure MiniProfiler service
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        public static void AddQNetMiniProfiler(this IServiceCollection services)
        {
            //whether database is already installed
            if (!DataSettingsManager.DatabaseIsInstalled)
                return;

            services.AddMiniProfiler(miniProfilerOptions =>
            {
                //use memory cache provider for storing each result
                ((MemoryCacheStorage)miniProfilerOptions.Storage).CacheDuration = TimeSpan.FromMinutes(60);

                //whether MiniProfiler should be displayed
                miniProfilerOptions.ShouldProfile = request =>
                    EngineContext.Current.Resolve<StoreInformationSettings>().DisplayMiniProfilerInPublicStore;

                //determine who can access the MiniProfiler results
                miniProfilerOptions.ResultsAuthorize = request =>
                    !EngineContext.Current.Resolve<StoreInformationSettings>().DisplayMiniProfilerForAdminOnly ||
                    EngineContext.Current.Resolve<IPermissionService>().Authorize(StandardPermissionProvider.AccessAdminPanel);
            }).AddEntityFramework();
        }

        /// <summary>
        /// Add and configure WebMarkupMin service
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        public static void AddQNetWebMarkupMin(this IServiceCollection services)
        {
            //check whether database is installed
            if (!DataSettingsManager.DatabaseIsInstalled)
                return;

            services
                .AddWebMarkupMin(options =>
                {
                    options.AllowMinificationInDevelopmentEnvironment = true;
                    options.AllowCompressionInDevelopmentEnvironment = true;
                    options.DisableMinification = !EngineContext.Current.Resolve<CommonSettings>().EnableHtmlMinification;
                    options.DisableCompression = true;
                    options.DisablePoweredByHttpHeaders = true;
                })
                .AddHtmlMinification(options =>
                {
                    var settings = options.MinificationSettings;

                    options.CssMinifierFactory = new NUglifyCssMinifierFactory();
                    options.JsMinifierFactory = new NUglifyJsMinifierFactory();
                })
                .AddXmlMinification(options =>
                {
                    var settings = options.MinificationSettings;
                    settings.RenderEmptyTagsWithSpace = true;
                    settings.CollapseTagsWithoutContent = true;
                });
        }

        /// <summary>
        /// Add and configure EasyCaching service
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        public static void AddEasyCaching(this IServiceCollection services)
        {
            services.AddEasyCaching(option =>
            {
                //use memory cache
                option.UseInMemory("nopCommerce_memory_cache");
            });
        }

        /// <summary>
        /// Add and configure default HTTP clients
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        public static void AddQNetHttpClients(this IServiceCollection services)
        {
            //default client
            services.AddHttpClient(QNetHttpDefaults.DefaultHttpClient).WithProxy();

            //client to request current store
            services.AddHttpClient<StoreHttpClient>();

            //client to request nopCommerce official site
            services.AddHttpClient<QNetHttpClient>().WithProxy();

            //client to request reCAPTCHA service
            services.AddHttpClient<CaptchaHttpClient>().WithProxy();
        }
    }
}