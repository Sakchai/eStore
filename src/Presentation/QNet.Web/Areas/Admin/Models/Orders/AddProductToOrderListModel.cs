using QNet.Web.Areas.Admin.Models.Catalog;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Orders
{
    /// <summary>
    /// Represents a product list model to add to the order
    /// </summary>
    public partial class AddProductToOrderListModel : BasePagedListModel<ProductModel>
    {
    }
}