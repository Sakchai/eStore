using Autofac;
using QNet.Core.Caching;
using QNet.Core.Configuration;
using QNet.Core.Infrastructure;
using QNet.Core.Infrastructure.DependencyManagement;
using QNet.Tests;

namespace QNet.Services.Tests
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
            //cache managers
            builder.RegisterType<TestCacheManager>().As<ICacheManager>().Named<ICacheManager>("nop_cache_static").SingleInstance();

        }

        /// <summary>
        /// Order of this dependency registrar implementation
        /// </summary>
        public int Order
        {
            get { return 0; }
        }
    }

}
