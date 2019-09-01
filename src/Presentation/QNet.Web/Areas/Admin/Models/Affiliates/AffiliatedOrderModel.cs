using System;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Affiliates
{
    /// <summary>
    /// Represents an affiliated order model
    /// </summary>
    public partial class AffiliatedOrderModel : BaseQNetEntityModel
    {
        #region Properties

        public override int Id { get; set; }

        [QNetResourceDisplayName("Admin.Affiliates.Orders.CustomOrderNumber")]
        public string CustomOrderNumber { get; set; }

        [QNetResourceDisplayName("Admin.Affiliates.Orders.OrderStatus")]
        public string OrderStatus { get; set; }
        [QNetResourceDisplayName("Admin.Affiliates.Orders.OrderStatus")]
        public int OrderStatusId { get; set; }

        [QNetResourceDisplayName("Admin.Affiliates.Orders.PaymentStatus")]
        public string PaymentStatus { get; set; }

        [QNetResourceDisplayName("Admin.Affiliates.Orders.ShippingStatus")]
        public string ShippingStatus { get; set; }

        [QNetResourceDisplayName("Admin.Affiliates.Orders.OrderTotal")]
        public string OrderTotal { get; set; }

        [QNetResourceDisplayName("Admin.Affiliates.Orders.CreatedOn")]
        public DateTime CreatedOn { get; set; }

        #endregion
    }
}