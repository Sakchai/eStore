using Autofac;
using Autofac.Core;
using QNet.Core.Configuration;
using QNet.Core.Data;
using QNet.Core.Infrastructure;
using QNet.Core.Infrastructure.DependencyManagement;
using QNet.Data;
using QNet.Plugin.Pickup.PickupInStore.Data;
using QNet.Plugin.Pickup.PickupInStore.Domain;
using QNet.Plugin.Pickup.PickupInStore.Factories;
using QNet.Plugin.Pickup.PickupInStore.Services;
using QNet.Web.Framework.Infrastructure.Extensions;

namespace QNet.Plugin.Pickup.PickupInStore.Infrastructure
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
            builder.RegisterType<StorePickupPointService>().As<IStorePickupPointService>().InstancePerLifetimeScope();
            builder.RegisterType<StorePickupPointModelFactory>().As<IStorePickupPointModelFactory>().InstancePerLifetimeScope();

            //data context
            builder.RegisterPluginDataContext<StorePickupPointObjectContext>("nop_object_context_pickup_in_store-pickup");

            //override required repository with our custom context
            builder.RegisterType<EfRepository<StorePickupPoint>>().As<IRepository<StorePickupPoint>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>("nop_object_context_pickup_in_store-pickup"))
                .InstancePerLifetimeScope();
        }

        /// <summary>
        /// Order of this dependency registrar implementation
        /// </summary>
        public int Order => 1;
    }
}