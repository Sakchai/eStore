using System;
using QNet.Web.Framework.Models;

namespace QNet.Web.Models.Blogs
{
    public partial class BlogCommentModel : BaseQNetEntityModel
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string CustomerAvatarUrl { get; set; }

        public string CommentText { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool AllowViewingProfiles { get; set; }
    }
}