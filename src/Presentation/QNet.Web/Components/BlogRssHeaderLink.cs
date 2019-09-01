using Microsoft.AspNetCore.Mvc;
using QNet.Core.Domain.Blogs;
using QNet.Web.Framework.Components;

namespace QNet.Web.Components
{
    public class BlogRssHeaderLinkViewComponent : QNetViewComponent
    {
        private readonly BlogSettings _blogSettings;

        public BlogRssHeaderLinkViewComponent(BlogSettings blogSettings)
        {
            _blogSettings = blogSettings;
        }

        public IViewComponentResult Invoke(int currentCategoryId, int currentProductId)
        {
            if (!_blogSettings.Enabled || !_blogSettings.ShowHeaderRssUrl)
                return Content("");

            return View();
        }
    }
}
