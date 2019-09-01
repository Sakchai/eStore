using QNet.Web.Framework.Models;

namespace QNet.Web.Models.Blogs
{
    public partial class BlogPostTagModel : BaseQNetModel
    {
        public string Name { get; set; }

        public int BlogPostCount { get; set; }
    }
}