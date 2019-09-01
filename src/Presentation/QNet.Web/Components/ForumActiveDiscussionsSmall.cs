using System.Linq;
using Microsoft.AspNetCore.Mvc;
using QNet.Web.Factories;
using QNet.Web.Framework.Components;

namespace QNet.Web.Components
{
    public class ForumActiveDiscussionsSmallViewComponent : QNetViewComponent
    {
        private readonly IForumModelFactory _forumModelFactory;

        public ForumActiveDiscussionsSmallViewComponent(IForumModelFactory forumModelFactory)
        {
            _forumModelFactory = forumModelFactory;
        }

        public IViewComponentResult Invoke()
        {
            var model = _forumModelFactory.PrepareActiveDiscussionsModel();
            if (!model.ForumTopics.Any())
                return Content("");

            return View(model);
        }
    }
}
