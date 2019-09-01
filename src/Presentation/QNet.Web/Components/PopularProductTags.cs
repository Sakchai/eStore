using System.Linq;
using Microsoft.AspNetCore.Mvc;
using QNet.Web.Factories;
using QNet.Web.Framework.Components;

namespace QNet.Web.Components
{
    public class PopularProductTagsViewComponent : QNetViewComponent
    {
        private readonly ICatalogModelFactory _catalogModelFactory;

        public PopularProductTagsViewComponent(ICatalogModelFactory catalogModelFactory)
        {
            _catalogModelFactory = catalogModelFactory;
        }

        public IViewComponentResult Invoke()
        {
            var model = _catalogModelFactory.PreparePopularProductTagsModel();

            if (!model.Tags.Any())
                return Content("");

            return View(model);
        }
    }
}
