using System.Linq;
using Microsoft.AspNetCore.Mvc;
using QNet.Web.Factories;
using QNet.Web.Framework.Components;

namespace QNet.Web.Components
{
    public class HomepageCategoriesViewComponent : QNetViewComponent
    {
        private readonly ICatalogModelFactory _catalogModelFactory;

        public HomepageCategoriesViewComponent(ICatalogModelFactory catalogModelFactory)
        {
            _catalogModelFactory = catalogModelFactory;
        }

        public IViewComponentResult Invoke()
        {
            var model = _catalogModelFactory.PrepareHomepageCategoryModels();
            if (!model.Any())
                return Content("");

            return View(model);
        }
    }
}
