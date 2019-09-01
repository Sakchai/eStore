using QNet.Web.Framework.Models;

namespace QNet.Web.Models.Checkout
{
    public partial class CheckoutCompletedModel : BaseQNetModel
    {
        public int OrderId { get; set; }
        public string CustomOrderNumber { get; set; }
        public bool OnePageCheckoutEnabled { get; set; }
    }
}