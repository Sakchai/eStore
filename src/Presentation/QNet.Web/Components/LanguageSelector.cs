using Microsoft.AspNetCore.Mvc;
using QNet.Web.Factories;
using QNet.Web.Framework.Components;

namespace QNet.Web.Components
{
    public class LanguageSelectorViewComponent : QNetViewComponent
    {
        private readonly ICommonModelFactory _commonModelFactory;

        public LanguageSelectorViewComponent(ICommonModelFactory commonModelFactory)
        {
            _commonModelFactory = commonModelFactory;
        }

        public IViewComponentResult Invoke()
        {
            var model = _commonModelFactory.PrepareLanguageSelectorModel();

            if (model.AvailableLanguages.Count == 1)
                return Content("");

            return View(model);
        }
    }
}
