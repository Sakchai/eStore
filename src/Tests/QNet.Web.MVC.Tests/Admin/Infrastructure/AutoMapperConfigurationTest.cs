using AutoMapper;
using QNet.Web.Areas.Admin.Infrastructure.Mapper;
using QNet.Core.Infrastructure.Mapper;
using NUnit.Framework;

namespace QNet.Web.MVC.Tests.Admin.Infrastructure
{
    [TestFixture]
    public class AutoMapperConfigurationTest
    {
        [Test]
        public void Configuration_is_valid()
        {
            var config = new MapperConfiguration(cfg => {
                
                    cfg.AddProfile(typeof(AdminMapperConfiguration));
            });
            
            AutoMapperConfiguration.Init(config);
            AutoMapperConfiguration.MapperConfiguration.AssertConfigurationIsValid();
        }
    }
}