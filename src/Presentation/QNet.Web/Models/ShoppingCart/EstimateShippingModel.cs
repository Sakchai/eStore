using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Models.ShoppingCart
{
    public partial class EstimateShippingModel : BaseQNetModel
    {
        public EstimateShippingModel()
        {
            AvailableCountries = new List<SelectListItem>();
            AvailableStates = new List<SelectListItem>();
        }

        public bool Enabled { get; set; }

        [QNetResourceDisplayName("ShoppingCart.EstimateShipping.Country")]
        public int? CountryId { get; set; }
        [QNetResourceDisplayName("ShoppingCart.EstimateShipping.StateProvince")]
        public int? StateProvinceId { get; set; }
        [QNetResourceDisplayName("ShoppingCart.EstimateShipping.ZipPostalCode")]
        public string ZipPostalCode { get; set; }
        
        public IList<SelectListItem> AvailableCountries { get; set; }
        public IList<SelectListItem> AvailableStates { get; set; }
    }

    public partial class EstimateShippingResultModel : BaseQNetModel
    {
        public EstimateShippingResultModel()
        {
            ShippingOptions = new List<ShippingOptionModel>();
            Warnings = new List<string>();
        }

        public IList<ShippingOptionModel> ShippingOptions { get; set; }

        public IList<string> Warnings { get; set; }

        #region Nested Classes

        public partial class ShippingOptionModel : BaseQNetModel
        {
            public string Name { get; set; }

            public string Description { get; set; }

            public string Price { get; set; }
        }

        #endregion
    }
}