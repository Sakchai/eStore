using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.ExternalAuthentication
{
    /// <summary>
    /// Represents an external authentication method model
    /// </summary>
    public partial class ExternalAuthenticationMethodModel : BaseQNetModel, IPluginModel
    {
        #region Properties

        [QNetResourceDisplayName("Admin.Configuration.ExternalAuthenticationMethods.Fields.FriendlyName")]
        public string FriendlyName { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.ExternalAuthenticationMethods.Fields.SystemName")]
        public string SystemName { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.ExternalAuthenticationMethods.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.ExternalAuthenticationMethods.Fields.IsActive")]
        public bool IsActive { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.ExternalAuthenticationMethods.Configure")]
        public string ConfigurationUrl { get; set; }

        public string LogoUrl { get; set; }

        #endregion
    }
}