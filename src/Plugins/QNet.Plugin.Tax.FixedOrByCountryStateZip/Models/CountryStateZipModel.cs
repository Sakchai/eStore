using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Plugin.Tax.FixedOrByCountryStateZip.Models
{
    public class CountryStateZipModel : BaseQNetEntityModel
    {
        [QNetResourceDisplayName("Plugins.Tax.FixedOrByCountryStateZip.Fields.Store")]
        public int StoreId { get; set; }
        [QNetResourceDisplayName("Plugins.Tax.FixedOrByCountryStateZip.Fields.Store")]
        public string StoreName { get; set; }

        [QNetResourceDisplayName("Plugins.Tax.FixedOrByCountryStateZip.Fields.TaxCategory")]
        public int TaxCategoryId { get; set; }
        [QNetResourceDisplayName("Plugins.Tax.FixedOrByCountryStateZip.Fields.TaxCategory")]
        public string TaxCategoryName { get; set; }

        [QNetResourceDisplayName("Plugins.Tax.FixedOrByCountryStateZip.Fields.Country")]
        public int CountryId { get; set; }
        [QNetResourceDisplayName("Plugins.Tax.FixedOrByCountryStateZip.Fields.Country")]
        public string CountryName { get; set; }

        [QNetResourceDisplayName("Plugins.Tax.FixedOrByCountryStateZip.Fields.StateProvince")]
        public int StateProvinceId { get; set; }
        [QNetResourceDisplayName("Plugins.Tax.FixedOrByCountryStateZip.Fields.StateProvince")]
        public string StateProvinceName { get; set; }

        [QNetResourceDisplayName("Plugins.Tax.FixedOrByCountryStateZip.Fields.Zip")]
        public string Zip { get; set; }

        [QNetResourceDisplayName("Plugins.Tax.FixedOrByCountryStateZip.Fields.Percentage")]
        public decimal Percentage { get; set; }
    }
}