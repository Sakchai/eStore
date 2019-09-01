using Microsoft.AspNetCore.Mvc;
using QNet.Web.Factories;
using QNet.Web.Framework.Components;

namespace QNet.Web.Components
{
    public class FaviconViewComponent : QNetViewComponent
    {
        private readonly ICommonModelFactory _commonModelFactory;

        public FaviconViewComponent(ICommonModelFactory commonModelFactory)
        {
            _commonModelFactory = commonModelFactory;
        }

        public IViewComponentResult Invoke()
        {
            var model = _commonModelFactory.PrepareFaviconAndAppIconsModel();
            if (string.IsNullOrEmpty(model.HeadCode))
                return Content("");
            return View(model);
        }
    }
}
