using System;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.ShoppingCart
{
    /// <summary>
    /// Represents a shopping cart item model
    /// </summary>
    public partial class ShoppingCartItemModel : BaseQNetEntityModel
    {
        #region Properties

        [QNetResourceDisplayName("Admin.CurrentCarts.Store")]
        public string Store { get; set; }

        [QNetResourceDisplayName("Admin.CurrentCarts.Product")]
        public int ProductId { get; set; }

        [QNetResourceDisplayName("Admin.CurrentCarts.Product")]
        public string ProductName { get; set; }

        public string AttributeInfo { get; set; }

        [QNetResourceDisplayName("Admin.CurrentCarts.UnitPrice")]
        public string UnitPrice { get; set; }

        [QNetResourceDisplayName("Admin.CurrentCarts.Quantity")]
        public int Quantity { get; set; }

        [QNetResourceDisplayName("Admin.CurrentCarts.Total")]
        public string Total { get; set; }

        [QNetResourceDisplayName("Admin.CurrentCarts.UpdatedOn")]
        public DateTime UpdatedOn { get; set; }

        #endregion
    }
}