using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Plugin.Payments.Manual.Models
{
    public class PaymentInfoModel : BaseQNetModel
    {
        public PaymentInfoModel()
        {
            CreditCardTypes = new List<SelectListItem>();
            ExpireMonths = new List<SelectListItem>();
            ExpireYears = new List<SelectListItem>();
        }

        [QNetResourceDisplayName("Payment.SelectCreditCard")]
        public string CreditCardType { get; set; }

        [QNetResourceDisplayName("Payment.SelectCreditCard")]
        public IList<SelectListItem> CreditCardTypes { get; set; }

        [QNetResourceDisplayName("Payment.CardholderName")]
        public string CardholderName { get; set; }

        [QNetResourceDisplayName("Payment.CardNumber")]
        public string CardNumber { get; set; }

        [QNetResourceDisplayName("Payment.ExpirationDate")]
        public string ExpireMonth { get; set; }

        [QNetResourceDisplayName("Payment.ExpirationDate")]
        public string ExpireYear { get; set; }

        public IList<SelectListItem> ExpireMonths { get; set; }

        public IList<SelectListItem> ExpireYears { get; set; }

        [QNetResourceDisplayName("Payment.CardCode")]
        public string CardCode { get; set; }
    }
}