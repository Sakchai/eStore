using Microsoft.AspNetCore.Routing;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Shipping
{
    /// <summary>
    /// Represents a pickup point provider model
    /// </summary>
    public partial class PickupPointProviderModel : BaseQNetModel, IPluginModel
    {
        #region Properties

        [QNetResourceDisplayName("Admin.Configuration.Shipping.PickupPointProviders.Fields.FriendlyName")]
        public string FriendlyName { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Shipping.PickupPointProviders.Fields.SystemName")]
        public string SystemName { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Shipping.PickupPointProviders.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Shipping.PickupPointProviders.Fields.IsActive")]
        public bool IsActive { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Shipping.PickupPointProviders.Fields.Logo")]
        public string LogoUrl { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Shipping.PickupPointProviders.Configure")]
        public string ConfigurationUrl { get; set; }

        #endregion
    }
}