using QNet.Web.Areas.Admin.Models.ShoppingCart;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Customers
{
    /// <summary>
    /// Represents a customer shopping cart list model
    /// </summary>
    public partial class CustomerShoppingCartListModel : BasePagedListModel<ShoppingCartItemModel>
    {
    }
}