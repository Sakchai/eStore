using Microsoft.AspNetCore.Mvc;
using QNet.Web.Factories;
using QNet.Web.Framework.Components;

namespace QNet.Web.Components
{
    public class SelectedCheckoutAttributesViewComponent : QNetViewComponent
    {
        private readonly IShoppingCartModelFactory _shoppingCartModelFactory;

        public SelectedCheckoutAttributesViewComponent(IShoppingCartModelFactory shoppingCartModelFactory)
        {
            _shoppingCartModelFactory = shoppingCartModelFactory;
        }

        public IViewComponentResult Invoke()
        {
            var attributes = _shoppingCartModelFactory.FormatSelectedCheckoutAttributes();
            return View(null, attributes);
        }
    }
}
