using QNet.Web.Framework.Models;

namespace QNet.Web.Models.Checkout
{
    public partial class OnePageCheckoutModel : BaseQNetModel
    {
        public bool ShippingRequired { get; set; }
        public bool DisableBillingAddressCheckoutStep { get; set; }

        public CheckoutBillingAddressModel BillingAddress { get; set; }
    }
}