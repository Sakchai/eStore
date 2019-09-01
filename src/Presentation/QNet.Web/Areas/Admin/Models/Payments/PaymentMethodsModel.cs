using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Payments
{
    /// <summary>
    /// Represents a payment methods model
    /// </summary>
    public partial class PaymentMethodsModel : BaseQNetModel
    {
        #region Ctor

        public PaymentMethodsModel()
        {
            PaymentsMethod = new PaymentMethodSearchModel();
            PaymentMethodRestriction = new PaymentMethodRestrictionModel();
        }

        #endregion

        #region Properties

        public PaymentMethodSearchModel PaymentsMethod { get; set; }

        public PaymentMethodRestrictionModel PaymentMethodRestriction { get; set; }

        #endregion
    }
}