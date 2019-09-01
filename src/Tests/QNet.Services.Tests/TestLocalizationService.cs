using Moq;
using QNet.Core;
using QNet.Core.Caching;
using QNet.Core.Data;
using QNet.Core.Domain.Localization;
using QNet.Data;
using QNet.Services.Configuration;
using QNet.Services.Events;
using QNet.Services.Localization;
using QNet.Services.Logging;

namespace QNet.Services.Tests
{
    public class TestLocalizationService : LocalizationService
    {
        public TestLocalizationService(IDataProvider dataProvider, IDbContext dbContext, IEventPublisher eventPublisher, ILanguageService languageService, ILocalizedEntityService localizedEntityService, ILogger logger, IRepository<LocaleStringResource> lsrRepository, ISettingService settingService, IStaticCacheManager cacheManager, IWorkContext workContext, LocalizationSettings localizationSettings) : base(dataProvider, dbContext, eventPublisher, languageService, localizedEntityService, logger, lsrRepository, settingService, cacheManager, workContext, localizationSettings)
        {
        }

        public static TestLocalizationService Init()
        {
            return new TestLocalizationService(new  Mock<IDataProvider>().Object,
                new  Mock<IDbContext>().Object,
                new  Mock<IEventPublisher>().Object,
                new  Mock<ILanguageService>().Object,
                new  Mock<ILocalizedEntityService>().Object,
                new  Mock<ILogger>().Object,
                new  Mock<IRepository<LocaleStringResource>>().Object,
                new  Mock<ISettingService>().Object,
                new  Mock<IStaticCacheManager>().Object,
                new  Mock<IWorkContext>().Object,
                new LocalizationSettings());
        }

        public override string GetResource(string resourceKey)
        {
            var rez = string.Empty;

            switch (resourceKey)
            {
                    case "GiftCardAttribute.For.Virtual":
                        rez = "For: {0} <{1}>";
                        break;
                case "GiftCardAttribute.From.Virtual":
                    rez = "From: {0} <{1}>";
                    break;
                case "GiftCardAttribute.For.Physical":
                    rez = "For: {0}";
                    break;
                case "GiftCardAttribute.From.Physical":
                    rez = "From: {0}";
                    break;
            }

            return rez;
        }
    }
}
