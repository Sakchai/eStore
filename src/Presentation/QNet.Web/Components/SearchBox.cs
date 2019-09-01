using Microsoft.AspNetCore.Mvc;
using QNet.Web.Factories;
using QNet.Web.Framework.Components;

namespace QNet.Web.Components
{
    public class SearchBoxViewComponent : QNetViewComponent
    {
        private readonly ICatalogModelFactory _catalogModelFactory;

        public SearchBoxViewComponent(ICatalogModelFactory catalogModelFactory)
        {
            _catalogModelFactory = catalogModelFactory;
        }

        public IViewComponentResult Invoke()
        {
            var model = _catalogModelFactory.PrepareSearchBoxModel();
            return View(model);
        }
    }
}
