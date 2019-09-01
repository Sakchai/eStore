using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Models.Vendors
{
    public partial class ApplyVendorModel : BaseQNetModel
    {
        public ApplyVendorModel()
        {
            VendorAttributes = new List<VendorAttributeModel>();
        }

        [QNetResourceDisplayName("Vendors.ApplyAccount.Name")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [QNetResourceDisplayName("Vendors.ApplyAccount.Email")]
        public string Email { get; set; }

        [QNetResourceDisplayName("Vendors.ApplyAccount.Description")]
        public string Description { get; set; }

        public IList<VendorAttributeModel> VendorAttributes { get; set; }

        public bool DisplayCaptcha { get; set; }

        public bool TermsOfServiceEnabled { get; set; }
        public bool TermsOfServicePopup { get; set; }

        public bool DisableFormInput { get; set; }
        public string Result { get; set; }
    }
}