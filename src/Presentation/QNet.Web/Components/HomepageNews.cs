using Microsoft.AspNetCore.Mvc;
using QNet.Core.Domain.News;
using QNet.Web.Factories;
using QNet.Web.Framework.Components;

namespace QNet.Web.Components
{
    public class HomepageNewsViewComponent : QNetViewComponent
    {
        private readonly INewsModelFactory _newsModelFactory;
        private readonly NewsSettings _newsSettings;

        public HomepageNewsViewComponent(INewsModelFactory newsModelFactory, NewsSettings newsSettings)
        {
            _newsModelFactory = newsModelFactory;
            _newsSettings = newsSettings;
        }

        public IViewComponentResult Invoke()
        {
            if (!_newsSettings.Enabled || !_newsSettings.ShowNewsOnMainPage)
                return Content("");

            var model = _newsModelFactory.PrepareHomepageNewsItemsModel();
            return View(model);
        }
    }
}
