using System;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Customers
{
    /// <summary>
    /// Represents a customer order model
    /// </summary>
    public partial class CustomerOrderModel : BaseQNetEntityModel
    {
        #region Properties

        public override int Id { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.Orders.CustomOrderNumber")]
        public string CustomOrderNumber { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.Orders.OrderStatus")]
        public string OrderStatus { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.Orders.OrderStatus")]
        public int OrderStatusId { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.Orders.PaymentStatus")]
        public string PaymentStatus { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.Orders.ShippingStatus")]
        public string ShippingStatus { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.Orders.OrderTotal")]
        public string OrderTotal { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.Orders.Store")]
        public string StoreName { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.Orders.CreatedOn")]
        public DateTime CreatedOn { get; set; }

        #endregion
    }
}