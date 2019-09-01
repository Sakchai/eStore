using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Settings
{
    /// <summary>
    /// Represents a GDPR consent localized model
    /// </summary>
    public partial class GdprConsentLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.Gdpr.Consent.Message")]
        public string Message { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.Gdpr.Consent.RequiredMessage")]
        public string RequiredMessage { get; set; }
    }
}
