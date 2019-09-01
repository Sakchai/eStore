using System.Collections.Generic;
using QNet.Web.Framework.Models;

namespace QNet.Web.Models.Checkout
{
    public partial class CheckoutConfirmModel : BaseQNetModel
    {
        public CheckoutConfirmModel()
        {
            Warnings = new List<string>();
        }

        public bool TermsOfServiceOnOrderConfirmPage { get; set; }
        public bool TermsOfServicePopup { get; set; }
        public string MinOrderTotalWarning { get; set; }

        public IList<string> Warnings { get; set; }
    }
}