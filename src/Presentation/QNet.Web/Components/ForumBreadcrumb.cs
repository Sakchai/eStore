using Microsoft.AspNetCore.Mvc;
using QNet.Web.Factories;
using QNet.Web.Framework.Components;

namespace QNet.Web.Components
{
    public class ForumBreadcrumbViewComponent : QNetViewComponent
    {
        private readonly IForumModelFactory _forumModelFactory;

        public ForumBreadcrumbViewComponent(IForumModelFactory forumModelFactory)
        {
            _forumModelFactory = forumModelFactory;
        }

        public IViewComponentResult Invoke(int? forumGroupId, int? forumId, int? forumTopicId)
        {
            var model = _forumModelFactory.PrepareForumBreadcrumbModel(forumGroupId, forumId, forumTopicId);
            return View(model);
        }
    }
}
