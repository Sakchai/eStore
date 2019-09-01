using System;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Customers
{
    /// <summary>
    /// Represents a customer back in stock subscription model
    /// </summary>
    public partial class CustomerBackInStockSubscriptionModel : BaseQNetEntityModel
    {
        #region Properties

        [QNetResourceDisplayName("Admin.Customers.Customers.BackInStockSubscriptions.Store")]
        public string StoreName { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.BackInStockSubscriptions.Product")]
        public int ProductId { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.BackInStockSubscriptions.Product")]
        public string ProductName { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.BackInStockSubscriptions.CreatedOn")]
        public DateTime CreatedOn { get; set; }

        #endregion
    }
}