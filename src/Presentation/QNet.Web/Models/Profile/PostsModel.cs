using QNet.Web.Framework.Models;

namespace QNet.Web.Models.Profile
{
    public partial class PostsModel : BaseQNetModel
    {
        public int ForumTopicId { get; set; }
        public string ForumTopicTitle { get; set; }
        public string ForumTopicSlug { get; set; }
        public string ForumPostText { get; set; }
        public string Posted { get; set; }
    }
}