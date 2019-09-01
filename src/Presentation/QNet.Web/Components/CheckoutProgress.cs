using Microsoft.AspNetCore.Mvc;
using QNet.Web.Factories;
using QNet.Web.Framework.Components;
using QNet.Web.Models.Checkout;

namespace QNet.Web.Components
{
    public class CheckoutProgressViewComponent : QNetViewComponent
    {
        private readonly ICheckoutModelFactory _checkoutModelFactory;

        public CheckoutProgressViewComponent(ICheckoutModelFactory checkoutModelFactory)
        {
            _checkoutModelFactory = checkoutModelFactory;
        }

        public IViewComponentResult Invoke(CheckoutProgressStep step)
        {
            var model = _checkoutModelFactory.PrepareCheckoutProgressModel(step);
            return View(model);
        }
    }
}
