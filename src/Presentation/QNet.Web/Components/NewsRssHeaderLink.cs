using Microsoft.AspNetCore.Mvc;
using QNet.Core.Domain.News;
using QNet.Web.Framework.Components;

namespace QNet.Web.Components
{
    public class NewsRssHeaderLinkViewComponent : QNetViewComponent
    {
        private readonly NewsSettings _newsSettings;

        public NewsRssHeaderLinkViewComponent(NewsSettings newsSettings)
        {
            _newsSettings = newsSettings;
        }

        public IViewComponentResult Invoke(int currentCategoryId, int currentProductId)
        {
            if (!_newsSettings.Enabled || !_newsSettings.ShowHeaderRssUrl)
                return Content("");

            return View();
        }
    }
}
