using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using QNet.Web.Framework.Models;

namespace QNet.Plugin.Payments.Qualpay.Models
{
    /// <summary>
    /// Represents payment model
    /// </summary>
    public class PaymentInfoModel : BaseQNetModel
    {
        #region Ctor

        public PaymentInfoModel()
        {
            ExpireMonths = new List<SelectListItem>();
            ExpireYears = new List<SelectListItem>();
            BillingCards = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        public bool IsGuest { get; set; }

        public bool IsRecurringOrder { get; set; }

        public string Errors { get; set; }

        public string TokenizedCardId { get; set; }

        public string TransientKey { get; set; }

        public string CardholderName { get; set; }

        public string CardNumber { get; set; }

        public string CardCode { get; set; }

        public string ExpireMonth { get; set; }
        public IList<SelectListItem> ExpireMonths { get; set; }

        public string ExpireYear { get; set; }
        public IList<SelectListItem> ExpireYears { get; set; }

        public bool SaveCardDetails { get; set; }

        public string BillingCardId { get; set; }
        public IList<SelectListItem> BillingCards { get; set; }

        #endregion
    }
}