using Autofac;
using Autofac.Core;
using QNet.Core.Configuration;
using QNet.Core.Data;
using QNet.Core.Infrastructure;
using QNet.Core.Infrastructure.DependencyManagement;
using QNet.Data;
using QNet.Plugin.Shipping.FixedByWeightByTotal.Data;
using QNet.Plugin.Shipping.FixedByWeightByTotal.Domain;
using QNet.Plugin.Shipping.FixedByWeightByTotal.Services;
using QNet.Web.Framework.Infrastructure.Extensions;

namespace QNet.Plugin.Shipping.FixedByWeightByTotal.Infrastructure
{
    /// <summary>
    /// Dependency registrar
    /// </summary>
    public class DependencyRegistrar : IDependencyRegistrar
    {
        /// <summary>
        /// Register services and interfaces
        /// </summary>
        /// <param name="builder">Container builder</param>
        /// <param name="typeFinder">Type finder</param>
        /// <param name="config">Config</param>
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, QNetConfig config)
        {
            builder.RegisterType<ShippingByWeightByTotalService>().As<IShippingByWeightByTotalService>().InstancePerLifetimeScope();

            //data context
            builder.RegisterPluginDataContext<ShippingByWeightByTotalObjectContext>("nop_object_context_shipping_weight_total_zip");

            //override required repository with our custom context
            builder.RegisterType<EfRepository<ShippingByWeightByTotalRecord>>().As<IRepository<ShippingByWeightByTotalRecord>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>("nop_object_context_shipping_weight_total_zip"))
                .InstancePerLifetimeScope();
        }

        /// <summary>
        /// Order of this dependency registrar implementation
        /// </summary>
        public int Order => 1;
    }
}