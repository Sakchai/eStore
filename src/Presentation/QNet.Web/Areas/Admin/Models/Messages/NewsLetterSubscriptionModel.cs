using System.ComponentModel.DataAnnotations;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Messages
{
    /// <summary>
    /// Represents a newsletter subscription model
    /// </summary>
    public partial class NewsletterSubscriptionModel : BaseQNetEntityModel
    {
        #region Properties

        [DataType(DataType.EmailAddress)]
        [QNetResourceDisplayName("Admin.Promotions.NewsLetterSubscriptions.Fields.Email")]
        public string Email { get; set; }

        [QNetResourceDisplayName("Admin.Promotions.NewsLetterSubscriptions.Fields.Active")]
        public bool Active { get; set; }

        [QNetResourceDisplayName("Admin.Promotions.NewsLetterSubscriptions.Fields.Store")]
        public string StoreName { get; set; }

        [QNetResourceDisplayName("Admin.Promotions.NewsLetterSubscriptions.Fields.CreatedOn")]
        public string CreatedOn { get; set; }

        #endregion
    }
}