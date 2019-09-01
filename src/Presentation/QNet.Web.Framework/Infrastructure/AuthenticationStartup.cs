using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QNet.Core.Infrastructure;
using QNet.Web.Framework.Infrastructure.Extensions;

namespace QNet.Web.Framework.Infrastructure
{
    /// <summary>
    /// Represents object for the configuring authentication middleware on application startup
    /// </summary>
    public class AuthenticationStartup : IQNetStartup
    {
        /// <summary>
        /// Add and configure any of the middleware
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        /// <param name="configuration">Configuration of the application</param>
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            //add data protection
            services.AddQNetDataProtection();

            services.AddQNetAuthentication();

        }

        /// <summary>
        /// Configure the using of added middleware
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        public void Configure(IApplicationBuilder application)
        {
            //configure authentication
            application.UseQNetAuthentication();

        }

        /// <summary>
        /// Gets order of this startup configuration implementation
        /// </summary>
        public int Order => 500; //authentication should be loaded before MVC
    }
}