using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Payments
{
    /// <summary>
    /// Represents a payment method model
    /// </summary>
    public partial class PaymentMethodModel : BaseQNetModel, IPluginModel
    {
        #region Properties

        [QNetResourceDisplayName("Admin.Configuration.Payment.Methods.Fields.FriendlyName")]
        public string FriendlyName { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Payment.Methods.Fields.SystemName")]
        public string SystemName { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Payment.Methods.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Payment.Methods.Fields.IsActive")]
        public bool IsActive { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Payment.Methods.Configure")]
        public string ConfigurationUrl { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Payment.Methods.Fields.Logo")]
        public string LogoUrl { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Payment.Methods.Fields.SupportCapture")]
        public bool SupportCapture { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Payment.Methods.Fields.SupportPartiallyRefund")]
        public bool SupportPartiallyRefund { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Payment.Methods.Fields.SupportRefund")]
        public bool SupportRefund { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Payment.Methods.Fields.SupportVoid")]
        public bool SupportVoid { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Payment.Methods.Fields.RecurringPaymentType")]
        public string RecurringPaymentType { get; set; }

        #endregion
    }
}