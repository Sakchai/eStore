using Microsoft.AspNetCore.Mvc;
using QNet.Web.Framework.Components;

namespace QNet.Plugin.Payments.PayPalStandard.Components
{
    [ViewComponent(Name = "PaymentPayPalStandard")]
    public class PaymentPayPalStandardViewComponent : QNetViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Plugins/Payments.PayPalStandard/Views/PaymentInfo.cshtml");
        }
    }
}
