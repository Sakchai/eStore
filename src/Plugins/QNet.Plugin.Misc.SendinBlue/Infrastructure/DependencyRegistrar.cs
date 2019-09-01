using Autofac;
using QNet.Core.Configuration;
using QNet.Core.Infrastructure;
using QNet.Core.Infrastructure.DependencyManagement;
using QNet.Plugin.Misc.SendinBlue.Services;
using QNet.Services.Messages;

namespace QNet.Plugin.Misc.SendinBlue.Infrastructure
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
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, QNetConfig config)
        {
            //register custom services
            builder.RegisterType<SendinBlueManager>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<SendinBlueMarketingAutomationManager>().AsSelf().InstancePerLifetimeScope();

            //override services
            builder.RegisterType<SendinBlueMessageService>().As<IWorkflowMessageService>().InstancePerLifetimeScope();
            builder.RegisterType<SendinBlueEmailSender>().As<IEmailSender>().InstancePerLifetimeScope();
        }

        /// <summary>
        /// Order of this dependency registrar implementation
        /// </summary>
        public int Order => 2;
    }
}