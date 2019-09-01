using QNet.Web.Framework.Models;

namespace QNet.Web.Models.Checkout
{
    public partial class CheckoutPaymentInfoModel : BaseQNetModel
    {
        public string PaymentViewComponentName { get; set; }

        /// <summary>
        /// Used on one-page checkout page
        /// </summary>
        public bool DisplayOrderTotals { get; set; }
    }
}