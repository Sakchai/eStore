using Microsoft.AspNetCore.Mvc;
using QNet.Web.Factories;
using QNet.Web.Framework.Components;

namespace QNet.Web.Components
{
    public class TopMenuViewComponent : QNetViewComponent
    {
        private readonly ICatalogModelFactory _catalogModelFactory;

        public TopMenuViewComponent(ICatalogModelFactory catalogModelFactory)
        {
            _catalogModelFactory = catalogModelFactory;
        }

        public IViewComponentResult Invoke(int? productThumbPictureSize)
        {
            var model = _catalogModelFactory.PrepareTopMenuModel();
            return View(model);
        }
    }
}
