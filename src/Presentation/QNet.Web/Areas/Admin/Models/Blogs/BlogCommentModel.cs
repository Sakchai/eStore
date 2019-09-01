using System;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Blogs
{
    /// <summary>
    /// Represents a blog comment model
    /// </summary>
    public partial class BlogCommentModel : BaseQNetEntityModel
    {
        #region Properties

        [QNetResourceDisplayName("Admin.ContentManagement.Blog.Comments.Fields.BlogPost")]
        public int BlogPostId { get; set; }

        [QNetResourceDisplayName("Admin.ContentManagement.Blog.Comments.Fields.BlogPost")]
        public string BlogPostTitle { get; set; }

        [QNetResourceDisplayName("Admin.ContentManagement.Blog.Comments.Fields.Customer")]
        public int CustomerId { get; set; }

        [QNetResourceDisplayName("Admin.ContentManagement.Blog.Comments.Fields.Customer")]
        public string CustomerInfo { get; set; }
        
        [QNetResourceDisplayName("Admin.ContentManagement.Blog.Comments.Fields.Comment")]
        public string Comment { get; set; }

        [QNetResourceDisplayName("Admin.ContentManagement.Blog.Comments.Fields.IsApproved")]
        public bool IsApproved { get; set; }

        [QNetResourceDisplayName("Admin.ContentManagement.Blog.Comments.Fields.StoreName")]
        public int StoreId { get; set; }
        public string StoreName { get; set; }

        [QNetResourceDisplayName("Admin.ContentManagement.Blog.Comments.Fields.CreatedOn")]
        public DateTime CreatedOn { get; set; }

        #endregion
    }
}