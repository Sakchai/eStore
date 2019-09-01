using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Orders
{
    /// <summary>
    /// Represents a recurring payment model
    /// </summary>
    public partial class RecurringPaymentModel : BaseQNetEntityModel
    {
        #region Ctor

        public RecurringPaymentModel()
        {
            RecurringPaymentHistorySearchModel = new RecurringPaymentHistorySearchModel();
        }

        #endregion

        #region Properties

        [QNetResourceDisplayName("Admin.RecurringPayments.Fields.ID")]
        public override int Id { get; set; }

        [QNetResourceDisplayName("Admin.RecurringPayments.Fields.CycleLength")]
        public int CycleLength { get; set; }

        [QNetResourceDisplayName("Admin.RecurringPayments.Fields.CyclePeriod")]
        public int CyclePeriodId { get; set; }

        [QNetResourceDisplayName("Admin.RecurringPayments.Fields.CyclePeriod")]
        public string CyclePeriodStr { get; set; }

        [QNetResourceDisplayName("Admin.RecurringPayments.Fields.TotalCycles")]
        public int TotalCycles { get; set; }

        [QNetResourceDisplayName("Admin.RecurringPayments.Fields.StartDate")]
        public string StartDate { get; set; }

        [QNetResourceDisplayName("Admin.RecurringPayments.Fields.IsActive")]
        public bool IsActive { get; set; }

        [QNetResourceDisplayName("Admin.RecurringPayments.Fields.NextPaymentDate")]
        public string NextPaymentDate { get; set; }

        [QNetResourceDisplayName("Admin.RecurringPayments.Fields.CyclesRemaining")]
        public int CyclesRemaining { get; set; }

        [QNetResourceDisplayName("Admin.RecurringPayments.Fields.InitialOrder")]
        public int InitialOrderId { get; set; }

        [QNetResourceDisplayName("Admin.RecurringPayments.Fields.Customer")]
        public int CustomerId { get; set; }

        [QNetResourceDisplayName("Admin.RecurringPayments.Fields.Customer")]
        public string CustomerEmail { get; set; }

        [QNetResourceDisplayName("Admin.RecurringPayments.Fields.PaymentType")]
        public string PaymentType { get; set; }

        public bool CanCancelRecurringPayment { get; set; }

        public bool LastPaymentFailed { get; set; }

        public RecurringPaymentHistorySearchModel RecurringPaymentHistorySearchModel { get; set; }

        #endregion
    }
}