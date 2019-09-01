using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Plugin.Shipping.FixedByWeightByTotal.Models
{
    public class FixedRateModel : BaseQNetModel
    {
        public int ShippingMethodId { get; set; }

        [QNetResourceDisplayName("Plugins.Shipping.FixedByWeightByTotal.Fields.ShippingMethod")]
        public string ShippingMethodName { get; set; }

        [QNetResourceDisplayName("Plugins.Shipping.FixedByWeightByTotal.Fields.Rate")]
        public decimal Rate { get; set; }
    }
}