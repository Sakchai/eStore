using QNet.Web.Framework.Models;

namespace QNet.Web.Models.Profile
{
    public partial class ProfileIndexModel : BaseQNetModel
    {
        public int CustomerProfileId { get; set; }
        public string ProfileTitle { get; set; }
        public int PostsPage { get; set; }
        public bool PagingPosts { get; set; }
        public bool ForumsEnabled { get; set; }
    }
}