using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Settings
{
    /// <summary>
    /// Represents a security settings model
    /// </summary>
    public partial class SecuritySettingsModel : BaseQNetModel, ISettingsModel
    {
        #region Properties

        public int ActiveStoreScopeConfiguration { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.GeneralCommon.EncryptionKey")]
        public string EncryptionKey { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.GeneralCommon.AdminAreaAllowedIpAddresses")]
        public string AdminAreaAllowedIpAddresses { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.GeneralCommon.ForceSslForAllPages")]
        public bool ForceSslForAllPages { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.GeneralCommon.EnableXSRFProtectionForAdminArea")]
        public bool EnableXsrfProtectionForAdminArea { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.GeneralCommon.EnableXSRFProtectionForPublicStore")]
        public bool EnableXsrfProtectionForPublicStore { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.GeneralCommon.HoneypotEnabled")]
        public bool HoneypotEnabled { get; set; }

        #endregion
    }
}