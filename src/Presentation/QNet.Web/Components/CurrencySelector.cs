using Microsoft.AspNetCore.Mvc;
using QNet.Web.Factories;
using QNet.Web.Framework.Components;

namespace QNet.Web.Components
{
    public class CurrencySelectorViewComponent : QNetViewComponent
    {
        private readonly ICommonModelFactory _commonModelFactory;

        public CurrencySelectorViewComponent(ICommonModelFactory commonModelFactory)
        {
            _commonModelFactory = commonModelFactory;
        }

        public IViewComponentResult Invoke()
        {
            var model = _commonModelFactory.PrepareCurrencySelectorModel();
            if (model.AvailableCurrencies.Count == 1)
                return Content("");

            return View(model);
        }
    }
}
