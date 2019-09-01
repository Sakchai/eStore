using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QNet.Core.Infrastructure;
using QNet.Web.Framework.Infrastructure.Extensions;

namespace QNet.Web.Framework.Infrastructure
{
    /// <summary>
    /// Represents object for the configuring MVC on application startup
    /// </summary>
    public class QNetMvcStartup : IQNetStartup
    {
        /// <summary>
        /// Add and configure any of the middleware
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        /// <param name="configuration">Configuration of the application</param>
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            //add MiniProfiler services
            services.AddQNetMiniProfiler();

            //add WebMarkupMin services to the services container
            services.AddQNetWebMarkupMin();

            //add and configure MVC feature
            services.AddQNetMvc();

            //add custom redirect result executor
            services.AddQNetRedirectResultExecutor();

            //chai add swagger
            services.AddQNetSwaggerGen();
        }

        /// <summary>
        /// Configure the using of added middleware
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        public void Configure(IApplicationBuilder application)
        {
            //use MiniProfiler
            application.UseMiniProfiler();

            //use WebMarkupMin
            application.UseQNetWebMarkupMin();

            //MVC routing
            application.UseQNetMvc();

            //chai swagger 
            application.UseQNetSwagger();
        }

        /// <summary>
        /// Gets order of this startup configuration implementation
        /// </summary>
        public int Order => 1000; //MVC should be loaded last
    }
}