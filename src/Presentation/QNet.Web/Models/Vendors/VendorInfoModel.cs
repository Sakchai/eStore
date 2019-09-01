using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Models.Vendors
{
    public class VendorInfoModel : BaseQNetModel
    {
        public VendorInfoModel()
        {
            VendorAttributes = new List<VendorAttributeModel>();
        }

        [QNetResourceDisplayName("Account.VendorInfo.Name")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [QNetResourceDisplayName("Account.VendorInfo.Email")]
        public string Email { get; set; }

        [QNetResourceDisplayName("Account.VendorInfo.Description")]
        public string Description { get; set; }

        [QNetResourceDisplayName("Account.VendorInfo.Picture")]
        public string PictureUrl { get; set; }

        public IList<VendorAttributeModel> VendorAttributes { get; set; }
    }
}