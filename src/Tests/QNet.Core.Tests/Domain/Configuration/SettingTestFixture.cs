using QNet.Core.Domain.Configuration;
using QNet.Tests;
using NUnit.Framework;

namespace QNet.Core.Tests.Domain.Configuration
{
    [TestFixture]
    public class SettingTestFixture
    {
        [Test]
        public void Can_create_setting()
        {
            var setting = new Setting("Setting1", "Value1");
            setting.Name.ShouldEqual("Setting1");
            setting.Value.ShouldEqual("Value1");
        }
    }
}
