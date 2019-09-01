using System.ComponentModel.DataAnnotations;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Models.Customer
{
    public partial class PasswordRecoveryModel : BaseQNetModel
    {
        [DataType(DataType.EmailAddress)]
        [QNetResourceDisplayName("Account.PasswordRecovery.Email")]
        public string Email { get; set; }

        public string Result { get; set; }

        public bool DisplayCaptcha { get; set; }
    }
}