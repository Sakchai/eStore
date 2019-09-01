using Microsoft.AspNetCore.Mvc;
using QNet.Services.Forums;
using QNet.Web.Factories;
using QNet.Web.Framework.Components;

namespace QNet.Web.Components
{
    public class ForumLastPostViewComponent : QNetViewComponent
    {
        private readonly IForumModelFactory _forumModelFactory;
        private readonly IForumService _forumService;

        public ForumLastPostViewComponent(IForumModelFactory forumModelFactory, IForumService forumService)
        {
            _forumModelFactory = forumModelFactory;
            _forumService = forumService;
        }

        public IViewComponentResult Invoke(int forumPostId, bool showTopic)
        {
            var forumPost = _forumService.GetPostById(forumPostId);
            var model = _forumModelFactory.PrepareLastPostModel(forumPost, showTopic);

            return View(model);
        }
    }
}
