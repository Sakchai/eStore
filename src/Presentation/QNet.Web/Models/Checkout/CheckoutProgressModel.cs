using QNet.Web.Framework.Models;

namespace QNet.Web.Models.Checkout
{
    public partial class CheckoutProgressModel : BaseQNetModel
    {
        public CheckoutProgressStep CheckoutProgressStep { get; set; }
    }

    public enum CheckoutProgressStep
    {
        Cart,
        Address,
        Shipping,
        Payment,
        Confirm,
        Complete
    }
}