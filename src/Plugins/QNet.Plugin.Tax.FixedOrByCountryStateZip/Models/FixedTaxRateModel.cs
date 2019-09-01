using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Plugin.Tax.FixedOrByCountryStateZip.Models
{
    public class FixedTaxRateModel: BaseQNetModel
    {
        public int TaxCategoryId { get; set; }

        [QNetResourceDisplayName("Plugins.Tax.FixedOrByCountryStateZip.Fields.TaxCategoryName")]
        public string TaxCategoryName { get; set; }

        [QNetResourceDisplayName("Plugins.Tax.FixedOrByCountryStateZip.Fields.Rate")]
        public decimal Rate { get; set; }
    }
}