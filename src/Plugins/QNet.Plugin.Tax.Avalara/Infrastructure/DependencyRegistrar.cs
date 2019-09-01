using Autofac;
using Autofac.Core;
using QNet.Core.Configuration;
using QNet.Core.Data;
using QNet.Core.Infrastructure;
using QNet.Core.Infrastructure.DependencyManagement;
using QNet.Data;
using QNet.Plugin.Tax.Avalara.Data;
using QNet.Plugin.Tax.Avalara.Domain;
using QNet.Plugin.Tax.Avalara.Factories;
using QNet.Plugin.Tax.Avalara.Services;
using QNet.Services.Orders;
using QNet.Web.Areas.Admin.Factories;
using QNet.Web.Framework.Infrastructure.Extensions;

namespace QNet.Plugin.Tax.Avalara.Infrastructure
{
    /// <summary>
    /// Dependency registrar of the Avalara tax provider services
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
            //register overridden services and factories
            builder.RegisterType<OverriddenOrderProcessingService>().As<IOrderProcessingService>().InstancePerLifetimeScope();
            builder.RegisterType<OverriddenOrderTotalCalculationService>().As<IOrderTotalCalculationService>().InstancePerLifetimeScope();
            builder.RegisterType<OverriddenShoppingCartModelFactory>().As<Web.Factories.IShoppingCartModelFactory>().InstancePerLifetimeScope();
            builder.RegisterType<OverriddenTaxModelFactory>().As<ITaxModelFactory>().InstancePerLifetimeScope();

            //register custom services
            builder.RegisterType<AvalaraTaxManager>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<TaxTransactionLogService>().AsSelf().InstancePerLifetimeScope();

            //register custom data context
            builder.RegisterPluginDataContext<TaxTransactionLogObjectContext>(AvalaraTaxDefaults.ObjectContextName);
            builder.RegisterType<EfRepository<TaxTransactionLog>>().As<IRepository<TaxTransactionLog>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(AvalaraTaxDefaults.ObjectContextName))
                .InstancePerLifetimeScope();
        }

        /// <summary>
        /// Order of this dependency registrar implementation
        /// </summary>
        public int Order => 4;
    }
}