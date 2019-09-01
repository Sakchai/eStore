using Microsoft.AspNetCore.Mvc;
using QNet.Web.Factories;
using QNet.Web.Framework.Components;

namespace QNet.Web.Components
{
    public class CategoryNavigationViewComponent : QNetViewComponent
    {
        private readonly ICatalogModelFactory _catalogModelFactory;

        public CategoryNavigationViewComponent(ICatalogModelFactory catalogModelFactory)
        {
            _catalogModelFactory = catalogModelFactory;
        }

        public IViewComponentResult Invoke(int currentCategoryId, int currentProductId)
        {
            var model = _catalogModelFactory.PrepareCategoryNavigationModel(currentCategoryId, currentProductId);
            return View(model);
        }
    }
}
