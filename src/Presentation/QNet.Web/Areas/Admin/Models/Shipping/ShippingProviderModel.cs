using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Shipping
{
    /// <summary>
    /// Represents a shipping provider model
    /// </summary>
    public partial class ShippingProviderModel : BaseQNetModel, IPluginModel
    {
        #region Properties

        [QNetResourceDisplayName("Admin.Configuration.Shipping.Providers.Fields.FriendlyName")]
        public string FriendlyName { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Shipping.Providers.Fields.SystemName")]
        public string SystemName { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Shipping.Providers.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Shipping.Providers.Fields.IsActive")]
        public bool IsActive { get; set; }
        
        [QNetResourceDisplayName("Admin.Configuration.Shipping.Providers.Fields.Logo")]
        public string LogoUrl { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Shipping.Providers.Configure")]
        public string ConfigurationUrl { get; set; }

        #endregion
    }
}