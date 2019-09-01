using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Tax
{
    /// <summary>
    /// Represents a tax provider model
    /// </summary>
    public partial class TaxProviderModel : BaseQNetModel, IPluginModel
    {
        #region Properties

        [QNetResourceDisplayName("Admin.Configuration.Tax.Providers.Fields.FriendlyName")]
        public string FriendlyName { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Tax.Providers.Fields.SystemName")]
        public string SystemName { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Tax.Providers.Fields.IsPrimaryTaxProvider")]
        public bool IsPrimaryTaxProvider { get; set; }
        
        [QNetResourceDisplayName("Admin.Configuration.Tax.Providers.Configure")]
        public string ConfigurationUrl { get; set; }

        public string LogoUrl { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; }

        #endregion
    }
}