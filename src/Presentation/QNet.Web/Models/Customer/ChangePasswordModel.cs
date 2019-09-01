using System.ComponentModel.DataAnnotations;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Models.Customer
{
    public partial class ChangePasswordModel : BaseQNetModel
    {
        [NoTrim]
        [DataType(DataType.Password)]
        [QNetResourceDisplayName("Account.ChangePassword.Fields.OldPassword")]
        public string OldPassword { get; set; }

        [NoTrim]
        [DataType(DataType.Password)]
        [QNetResourceDisplayName("Account.ChangePassword.Fields.NewPassword")]
        public string NewPassword { get; set; }

        [NoTrim]
        [DataType(DataType.Password)]
        [QNetResourceDisplayName("Account.ChangePassword.Fields.ConfirmNewPassword")]
        public string ConfirmNewPassword { get; set; }

        public string Result { get; set; }
    }
}