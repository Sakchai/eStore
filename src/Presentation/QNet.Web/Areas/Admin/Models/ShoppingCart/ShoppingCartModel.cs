using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.ShoppingCart
{
    /// <summary>
    /// Represents a shopping cart model
    /// </summary>
    public partial class ShoppingCartModel : BaseQNetModel
    {
        #region Properties

        [QNetResourceDisplayName("Admin.CurrentCarts.Customer")]
        public int CustomerId { get; set; }

        [QNetResourceDisplayName("Admin.CurrentCarts.Customer")]
        public string CustomerEmail { get; set; }

        [QNetResourceDisplayName("Admin.CurrentCarts.TotalItems")]
        public int TotalItems { get; set; }

        #endregion
    }
}