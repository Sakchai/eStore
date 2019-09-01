using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QNet.Core.Infrastructure;
using QNet.Plugin.Shipping.FixedByWeightByTotal.Data;
using QNet.Web.Framework.Infrastructure.Extensions;

namespace QNet.Plugin.Shipping.FixedByWeightByTotal.Infrastructure
{
    /// <summary>
    /// Represents object for the configuring plugin DB context on application startup
    /// </summary>
    public class PluginDbStartup : IQNetStartup
    {
        /// <summary>
        /// Add and configure any of the middleware
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        /// <param name="configuration">Configuration of the application</param>
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            //add object context
            services.AddDbContext<ShippingByWeightByTotalObjectContext>(optionsBuilder =>
            {
                //optionsBuilder.UseSqlServerWithLazyLoading(services);
                optionsBuilder.UseMySQLWithLazyLoading(services);
            });
        }

        /// <summary>
        /// Configure the using of added middleware
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        public void Configure(IApplicationBuilder application)
        {
        }

        /// <summary>
        /// Gets order of this startup configuration implementation
        /// </summary>
        public int Order => 11;
    }
}