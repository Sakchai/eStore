using Autofac;
using QNet.Core.Configuration;
using QNet.Core.Infrastructure;
using QNet.Core.Infrastructure.DependencyManagement;
using QNet.Plugin.Payments.Square.Services;

namespace QNet.Plugin.Payments.Square.Infrastructure
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
            builder.RegisterType<SquarePaymentManager>().AsSelf().InstancePerLifetimeScope();
        }

        /// <summary>
        /// Order of this dependency registrar implementation
        /// </summary>
        public int Order => 1;
    }
}