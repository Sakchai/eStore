using System;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.News
{
    /// <summary>
    /// Represents a news comment model
    /// </summary>
    public partial class NewsCommentModel : BaseQNetEntityModel
    {
        #region Properties

        [QNetResourceDisplayName("Admin.ContentManagement.News.Comments.Fields.NewsItem")]
        public int NewsItemId { get; set; }

        [QNetResourceDisplayName("Admin.ContentManagement.News.Comments.Fields.NewsItem")]
        public string NewsItemTitle { get; set; }

        [QNetResourceDisplayName("Admin.ContentManagement.News.Comments.Fields.Customer")]
        public int CustomerId { get; set; }

        [QNetResourceDisplayName("Admin.ContentManagement.News.Comments.Fields.Customer")]
        public string CustomerInfo { get; set; }
        
        [QNetResourceDisplayName("Admin.ContentManagement.News.Comments.Fields.CommentTitle")]
        public string CommentTitle { get; set; }
        
        [QNetResourceDisplayName("Admin.ContentManagement.News.Comments.Fields.CommentText")]
        public string CommentText { get; set; }

        [QNetResourceDisplayName("Admin.ContentManagement.News.Comments.Fields.IsApproved")]
        public bool IsApproved { get; set; }

        [QNetResourceDisplayName("Admin.ContentManagement.News.Comments.Fields.StoreName")]
        public int StoreId { get; set; }

        public string StoreName { get; set; }

        [QNetResourceDisplayName("Admin.ContentManagement.News.Comments.Fields.CreatedOn")]
        public DateTime CreatedOn { get; set; }

        #endregion
    }
}