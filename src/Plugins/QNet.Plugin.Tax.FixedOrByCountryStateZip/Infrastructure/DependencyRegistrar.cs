using Autofac;
using Autofac.Core;
using QNet.Core.Configuration;
using QNet.Core.Data;
using QNet.Core.Infrastructure;
using QNet.Core.Infrastructure.DependencyManagement;
using QNet.Data;
using QNet.Plugin.Tax.FixedOrByCountryStateZip.Data;
using QNet.Plugin.Tax.FixedOrByCountryStateZip.Domain;
using QNet.Plugin.Tax.FixedOrByCountryStateZip.Services;
using QNet.Services.Tax;
using QNet.Web.Framework.Infrastructure.Extensions;

namespace QNet.Plugin.Tax.FixedOrByCountryStateZip.Infrastructure
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
            builder.RegisterType<FixedOrByCountryStateZipTaxProvider>().As<ITaxProvider>().InstancePerLifetimeScope();
            builder.RegisterType<CountryStateZipService>().As<ICountryStateZipService>().InstancePerLifetimeScope();

            //data context
            builder.RegisterPluginDataContext<CountryStateZipObjectContext>("nop_object_context_tax_country_state_zip");

            //override required repository with our custom context
            builder.RegisterType<EfRepository<TaxRate>>().As<IRepository<TaxRate>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>("nop_object_context_tax_country_state_zip"))
                .InstancePerLifetimeScope();
        }

        /// <summary>
        /// Order of this dependency registrar implementation
        /// </summary>
        public int Order => 1;
    }
}