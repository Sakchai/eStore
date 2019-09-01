using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Moq;
using QNet.Core;
using QNet.Core.Infrastructure;
using QNet.Services.Plugins;
using QNet.Services.Tests.Directory;
using QNet.Services.Tests.Discounts;
using QNet.Services.Tests.Payments;
using QNet.Services.Tests.Shipping;
using QNet.Services.Tests.Tax;
using NUnit.Framework;

namespace QNet.Services.Tests
{
    [TestFixture]
    public abstract class ServiceTest
    {
        [SetUp]
        public void SetUp()
        {
            //init plugins
            InitPlugins();
        }

        private void InitPlugins()
        {
            var hostingEnvironment = new Mock<IHostingEnvironment>();
            hostingEnvironment.Setup(x => x.ContentRootPath).Returns(System.Reflection.Assembly.GetExecutingAssembly().Location);
            hostingEnvironment.Setup(x => x.WebRootPath).Returns(System.IO.Directory.GetCurrentDirectory());
            CommonHelper.DefaultFileProvider = new QNetFileProvider(hostingEnvironment.Object);

            Singleton<IPluginsInfo>.Instance = new PluginsInfo(CommonHelper.DefaultFileProvider)
            {
                PluginDescriptors = new List<PluginDescriptor>
                {
                    new PluginDescriptor(typeof(FixedRateTestTaxProvider).Assembly)
                    {
                        PluginType = typeof(FixedRateTestTaxProvider),
                        SystemName = "FixedTaxRateTest",
                        FriendlyName = "Fixed tax test rate provider",
                        Installed = true
                    },
                    new PluginDescriptor(typeof(FixedRateTestShippingRateComputationMethod).Assembly)
                    {
                        PluginType = typeof(FixedRateTestShippingRateComputationMethod),
                        SystemName = "FixedRateTestShippingRateComputationMethod",
                        FriendlyName = "Fixed rate test shipping computation method",
                        Installed = true
                    },
                    new PluginDescriptor(typeof(TestPaymentMethod).Assembly)
                    {
                        PluginType = typeof(TestPaymentMethod),
                        SystemName = "Payments.TestMethod",
                        FriendlyName = "Test payment method",
                        Installed = true
                    },
                    new PluginDescriptor(typeof(TestDiscountRequirementRule).Assembly)
                    {
                        PluginType = typeof(TestDiscountRequirementRule),
                        SystemName = "TestDiscountRequirementRule",
                        FriendlyName = "Test discount requirement rule",
                        Installed = true
                    },
                    new PluginDescriptor(typeof(TestExchangeRateProvider).Assembly)
                    {
                        PluginType = typeof(TestExchangeRateProvider),
                        SystemName = "CurrencyExchange.TestProvider",
                        FriendlyName = "Test exchange rate provider",
                        Installed = true
                    }
                }
            };
        }
    }
}
