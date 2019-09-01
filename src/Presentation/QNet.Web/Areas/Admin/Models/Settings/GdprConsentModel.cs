using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;
using System.Collections.Generic;

namespace QNet.Web.Areas.Admin.Models.Settings
{
    /// <summary>
    /// Represents a GDPR consent model
    /// </summary>
    public partial class GdprConsentModel : BaseQNetEntityModel, ILocalizedModel<GdprConsentLocalizedModel>
    {
        #region Ctor

        public GdprConsentModel()
        {
            Locales = new List<GdprConsentLocalizedModel>();
        }

        #endregion

        #region Properties

        [QNetResourceDisplayName("Admin.Configuration.Settings.Gdpr.Consent.Message")]
        public string Message { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.Gdpr.Consent.IsRequired")]
        public bool IsRequired { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.Gdpr.Consent.RequiredMessage")]
        public string RequiredMessage { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.Gdpr.Consent.DisplayDuringRegistration")]
        public bool DisplayDuringRegistration { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.Gdpr.Consent.DisplayOnCustomerInfoPage")]
        public bool DisplayOnCustomerInfoPage { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.Gdpr.Consent.DisplayOrder")]
        public int DisplayOrder { get; set; }

        public IList<GdprConsentLocalizedModel> Locales { get; set; }

        #endregion
    }
}