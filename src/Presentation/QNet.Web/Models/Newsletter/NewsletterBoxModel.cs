using System.ComponentModel.DataAnnotations;
using QNet.Web.Framework.Models;

namespace QNet.Web.Models.Newsletter
{
    public partial class NewsletterBoxModel : BaseQNetModel
    {
        [DataType(DataType.EmailAddress)]
        public string NewsletterEmail { get; set; }
        public bool AllowToUnsubscribe { get; set; }
    }
}