using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace QNet.Web.Models.Customer
{
    public partial class CheckGiftCardBalanceModel : BaseQNetModel
    {
        public string Result { get; set; }

        public string Message { get; set; }
        
        [QNetResourceDisplayName("ShoppingCart.GiftCardCouponCode.Tooltip")]
        public string GiftCardCode { get; set; }
    }
}
