using System.ComponentModel.DataAnnotations;
using QNet.Core.Domain.Customers;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Models.Customer
{
    public partial class LoginModel : BaseQNetModel
    {
        public bool CheckoutAsGuest { get; set; }

        [DataType(DataType.EmailAddress)]
        [QNetResourceDisplayName("Account.Login.Fields.Email")]
        public string Email { get; set; }

        public bool UsernamesEnabled { get; set; }

        public UserRegistrationType RegistrationType { get; set; }

        [QNetResourceDisplayName("Account.Login.Fields.Username")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [NoTrim]
        [QNetResourceDisplayName("Account.Login.Fields.Password")]
        public string Password { get; set; }

        [QNetResourceDisplayName("Account.Login.Fields.RememberMe")]
        public bool RememberMe { get; set; }

        public bool DisplayCaptcha { get; set; }
    }
}