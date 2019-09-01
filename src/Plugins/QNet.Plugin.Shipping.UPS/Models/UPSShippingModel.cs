using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Plugin.Shipping.UPS.Models
{
    public class UPSShippingModel : BaseQNetModel
    {
        #region Ctor

        public UPSShippingModel()
        {
            CarrierServices = new List<string>();
            AvailableCarrierServices = new List<SelectListItem>();
            AvailableCustomerClassifications = new List<SelectListItem>();
            AvailablePickupTypes = new List<SelectListItem>();
            AvailablePackagingTypes = new List<SelectListItem>();
            AvaliablePackingTypes = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        [QNetResourceDisplayName("Plugins.Shipping.UPS.Fields.AccountNumber")]
        public string AccountNumber { get; set; }

        [QNetResourceDisplayName("Plugins.Shipping.UPS.Fields.AccessKey")]
        public string AccessKey { get; set; }

        [QNetResourceDisplayName("Plugins.Shipping.UPS.Fields.Username")]
        public string Username { get; set; }

        [QNetResourceDisplayName("Plugins.Shipping.UPS.Fields.Password")]
        public string Password { get; set; }

        [QNetResourceDisplayName("Plugins.Shipping.UPS.Fields.UseSandbox")]
        public bool UseSandbox { get; set; }

        [QNetResourceDisplayName("Plugins.Shipping.UPS.Fields.AdditionalHandlingCharge")]
        public decimal AdditionalHandlingCharge { get; set; }

        [QNetResourceDisplayName("Plugins.Shipping.UPS.Fields.InsurePackage")]
        public bool InsurePackage { get; set; }

        [QNetResourceDisplayName("Plugins.Shipping.UPS.Fields.CustomerClassification")]
        public int CustomerClassification { get; set; }
        public IList<SelectListItem> AvailableCustomerClassifications { get; set; }

        [QNetResourceDisplayName("Plugins.Shipping.UPS.Fields.PickupType")]
        public int PickupType { get; set; }
        public IList<SelectListItem> AvailablePickupTypes { get; set; }

        [QNetResourceDisplayName("Plugins.Shipping.UPS.Fields.PackagingType")]
        public int PackagingType { get; set; }
        public IList<SelectListItem> AvailablePackagingTypes { get; set; }

        [QNetResourceDisplayName("Plugins.Shipping.UPS.Fields.AvailableCarrierServices")]
        public IList<SelectListItem> AvailableCarrierServices { get; set; }
        public IList<string> CarrierServices { get; set; }

        [QNetResourceDisplayName("Plugins.Shipping.UPS.Fields.SaturdayDeliveryEnabled")]
        public bool SaturdayDeliveryEnabled { get; set; }

        [QNetResourceDisplayName("Plugins.Shipping.UPS.Fields.PassDimensions")]
        public bool PassDimensions { get; set; }

        [QNetResourceDisplayName("Plugins.Shipping.UPS.Fields.PackingPackageVolume")]
        public int PackingPackageVolume { get; set; }

        [QNetResourceDisplayName("Plugins.Shipping.UPS.Fields.PackingType")]
        public int PackingType { get; set; }
        public IList<SelectListItem> AvaliablePackingTypes { get; set; }

        [QNetResourceDisplayName("Plugins.Shipping.UPS.Fields.Tracing")]
        public bool Tracing { get; set; }

        #endregion
    }
}