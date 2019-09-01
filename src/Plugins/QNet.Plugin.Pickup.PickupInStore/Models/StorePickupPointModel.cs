using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Plugin.Pickup.PickupInStore.Models
{
    public class StorePickupPointModel : BaseQNetEntityModel
    {
        public StorePickupPointModel()
        {
            Address = new AddressModel();
            AvailableStores = new List<SelectListItem>();
        }

        public AddressModel Address { get; set; }

        [QNetResourceDisplayName("Plugins.Pickup.PickupInStore.Fields.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Plugins.Pickup.PickupInStore.Fields.Description")]
        public string Description { get; set; }

        [QNetResourceDisplayName("Plugins.Pickup.PickupInStore.Fields.PickupFee")]
        public decimal PickupFee { get; set; }

        [QNetResourceDisplayName("Plugins.Pickup.PickupInStore.Fields.OpeningHours")]
        public string OpeningHours { get; set; }

        [QNetResourceDisplayName("Plugins.Pickup.PickupInStore.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        public List<SelectListItem> AvailableStores { get; set; }
        [QNetResourceDisplayName("Plugins.Pickup.PickupInStore.Fields.Store")]
        public int StoreId { get; set; }
        public string StoreName { get; set; }
    }

    public class AddressModel
    {
        public AddressModel()
        {
            AvailableCountries = new List<SelectListItem>();
            AvailableStates = new List<SelectListItem>();
        }

        [QNetResourceDisplayName("Admin.Address.Fields.Country")]
        public int? CountryId { get; set; }
        public IList<SelectListItem> AvailableCountries { get; set; }
        public bool CountryEnabled { get; set; }

        [QNetResourceDisplayName("Admin.Address.Fields.StateProvince")]
        public int? StateProvinceId { get; set; }
        public IList<SelectListItem> AvailableStates { get; set; }
        public bool StateProvinceEnabled { get; set; }

        [QNetResourceDisplayName("Admin.Address.Fields.County")]
        public string County { get; set; }
        public bool CountyEnabled { get; set; }

        [QNetResourceDisplayName("Admin.Address.Fields.City")]
        public string City { get; set; }
        public bool CityEnabled { get; set; }

        [QNetResourceDisplayName("Admin.Address.Fields.Address1")]
        public string Address1 { get; set; }

        [QNetResourceDisplayName("Admin.Address.Fields.ZipPostalCode")]
        public string ZipPostalCode { get; set; }
        public bool ZipPostalCodeEnabled { get; set; }
    }
}