using System.ComponentModel.DataAnnotations;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Models.Customer
{
    public partial class PasswordRecoveryConfirmModel : BaseQNetModel
    {
        [DataType(DataType.Password)]
        [NoTrim]
        [QNetResourceDisplayName("Account.PasswordRecovery.NewPassword")]
        public string NewPassword { get; set; }
        
        [NoTrim]
        [DataType(DataType.Password)]
        [QNetResourceDisplayName("Account.PasswordRecovery.ConfirmNewPassword")]
        public string ConfirmNewPassword { get; set; }

        public bool DisablePasswordChanging { get; set; }
        public string Result { get; set; }
    }
}