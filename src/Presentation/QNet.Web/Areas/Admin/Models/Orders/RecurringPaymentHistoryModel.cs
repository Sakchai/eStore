using System;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Orders
{
    /// <summary>
    /// Represents a recurring payment history model
    /// </summary>
    public partial class RecurringPaymentHistoryModel : BaseQNetEntityModel
    {
        #region Properties

        public int OrderId { get; set; }

        [QNetResourceDisplayName("Admin.RecurringPayments.History.CustomOrderNumber")]
        public string CustomOrderNumber { get; set; }

        public int RecurringPaymentId { get; set; }

        [QNetResourceDisplayName("Admin.RecurringPayments.History.OrderStatus")]
        public string OrderStatus { get; set; }

        [QNetResourceDisplayName("Admin.RecurringPayments.History.PaymentStatus")]
        public string PaymentStatus { get; set; }

        [QNetResourceDisplayName("Admin.RecurringPayments.History.ShippingStatus")]
        public string ShippingStatus { get; set; }

        [QNetResourceDisplayName("Admin.RecurringPayments.History.CreatedOn")]
        public DateTime CreatedOn { get; set; }

        #endregion
    }
}