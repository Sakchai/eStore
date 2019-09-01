using System.ComponentModel.DataAnnotations;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Models.Common
{
    public partial class ContactVendorModel : BaseQNetModel
    {
        public int VendorId { get; set; }
        public string VendorName { get; set; }

        [DataType(DataType.EmailAddress)]
        [QNetResourceDisplayName("ContactVendor.Email")]
        public string Email { get; set; }

        [QNetResourceDisplayName("ContactVendor.Subject")]
        public string Subject { get; set; }
        public bool SubjectEnabled { get; set; }

        [QNetResourceDisplayName("ContactVendor.Enquiry")]
        public string Enquiry { get; set; }

        [QNetResourceDisplayName("ContactVendor.FullName")]
        public string FullName { get; set; }

        public bool SuccessfullySent { get; set; }
        public string Result { get; set; }

        public bool DisplayCaptcha { get; set; }
    }
}