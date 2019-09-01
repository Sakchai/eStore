using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Blogs
{
    /// <summary>
    /// Represents a blog content model
    /// </summary>
    public partial class BlogContentModel : BaseQNetModel
    {
        #region Ctor

        public BlogContentModel()
        {
            BlogPosts = new BlogPostSearchModel();
            BlogComments = new BlogCommentSearchModel();
        }

        #endregion

        #region Properties

        public BlogPostSearchModel BlogPosts { get; set; }

        public BlogCommentSearchModel BlogComments { get; set; }

        #endregion
    }
}
