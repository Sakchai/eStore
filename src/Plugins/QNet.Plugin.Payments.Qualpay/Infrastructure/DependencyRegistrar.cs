using Autofac;
using QNet.Core.Configuration;
using QNet.Core.Infrastructure;
using QNet.Core.Infrastructure.DependencyManagement;
using QNet.Plugin.Payments.Qualpay.Factories;
using QNet.Plugin.Payments.Qualpay.Services;

namespace QNet.Plugin.Payments.Qualpay.Infrastructure
{
    /// <summary>
    /// Represents a plugin dependency registrar
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
            //register service manager
            builder.RegisterType<QualpayManager>().AsSelf().InstancePerLifetimeScope();

            //register custom factories
            builder.RegisterType<QualpayCustomerModelFactory>().AsSelf().InstancePerLifetimeScope();
        }

        /// <summary>
        /// Gets order of this dependency registrar implementation
        /// </summary>
        public int Order => 1;
    }
}