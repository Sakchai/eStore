using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Models.News
{
    public partial class AddNewsCommentModel : BaseQNetModel
    {
        [QNetResourceDisplayName("News.Comments.CommentTitle")]
        public string CommentTitle { get; set; }

        [QNetResourceDisplayName("News.Comments.CommentText")]
        public string CommentText { get; set; }

        public bool DisplayCaptcha { get; set; }
    }
}