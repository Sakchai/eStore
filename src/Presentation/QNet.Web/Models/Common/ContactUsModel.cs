using System.ComponentModel.DataAnnotations;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Models.Common
{
    public partial class ContactUsModel : BaseQNetModel
    {
        [DataType(DataType.EmailAddress)]
        [QNetResourceDisplayName("ContactUs.Email")]
        public string Email { get; set; }
        
        [QNetResourceDisplayName("ContactUs.Subject")]
        public string Subject { get; set; }
        public bool SubjectEnabled { get; set; }

        [QNetResourceDisplayName("ContactUs.Enquiry")]
        public string Enquiry { get; set; }

        [QNetResourceDisplayName("ContactUs.FullName")]
        public string FullName { get; set; }

        public bool SuccessfullySent { get; set; }
        public string Result { get; set; }

        public bool DisplayCaptcha { get; set; }
    }
}