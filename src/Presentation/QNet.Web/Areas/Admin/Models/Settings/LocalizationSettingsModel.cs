using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Settings
{
    /// <summary>
    /// Represents a localization settings model
    /// </summary>
    public partial class LocalizationSettingsModel : BaseQNetModel, ISettingsModel
    {
        #region Properties

        public int ActiveStoreScopeConfiguration { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.GeneralCommon.UseImagesForLanguageSelection")]
        public bool UseImagesForLanguageSelection { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.GeneralCommon.SeoFriendlyUrlsForLanguagesEnabled")]
        public bool SeoFriendlyUrlsForLanguagesEnabled { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.GeneralCommon.AutomaticallyDetectLanguage")]
        public bool AutomaticallyDetectLanguage { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.GeneralCommon.LoadAllLocaleRecordsOnStartup")]
        public bool LoadAllLocaleRecordsOnStartup { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.GeneralCommon.LoadAllLocalizedPropertiesOnStartup")]
        public bool LoadAllLocalizedPropertiesOnStartup { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.GeneralCommon.LoadAllUrlRecordsOnStartup")]
        public bool LoadAllUrlRecordsOnStartup { get; set; }

        #endregion
    }
}