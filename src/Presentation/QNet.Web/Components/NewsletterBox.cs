using Microsoft.AspNetCore.Mvc;
using QNet.Core.Domain.Customers;
using QNet.Web.Factories;
using QNet.Web.Framework.Components;

namespace QNet.Web.Components
{
    public class NewsletterBoxViewComponent : QNetViewComponent
    {
        private readonly CustomerSettings _customerSettings;
        private readonly INewsletterModelFactory _newsletterModelFactory;

        public NewsletterBoxViewComponent(CustomerSettings customerSettings, INewsletterModelFactory newsletterModelFactory)
        {
            _customerSettings = customerSettings;
            _newsletterModelFactory = newsletterModelFactory;
        }

        public IViewComponentResult Invoke()
        {
            if (_customerSettings.HideNewsletterBlock)
                return Content("");

            var model = _newsletterModelFactory.PrepareNewsletterBoxModel();
            return View(model);
        }
    }
}
