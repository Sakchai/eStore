using System.ComponentModel.DataAnnotations;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Messages
{
    /// <summary>
    /// Represents an email account model
    /// </summary>
    public partial class EmailAccountModel : BaseQNetEntityModel
    {
        #region Properties

        [DataType(DataType.EmailAddress)]
        [QNetResourceDisplayName("Admin.Configuration.EmailAccounts.Fields.Email")]
        public string Email { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.EmailAccounts.Fields.DisplayName")]
        public string DisplayName { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.EmailAccounts.Fields.Host")]
        public string Host { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.EmailAccounts.Fields.Port")]
        public int Port { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.EmailAccounts.Fields.Username")]
        public string Username { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.EmailAccounts.Fields.Password")]
        [DataType(DataType.Password)]
        [NoTrim]
        public string Password { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.EmailAccounts.Fields.EnableSsl")]
        public bool EnableSsl { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.EmailAccounts.Fields.UseDefaultCredentials")]
        public bool UseDefaultCredentials { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.EmailAccounts.Fields.IsDefaultEmailAccount")]
        public bool IsDefaultEmailAccount { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.EmailAccounts.Fields.SendTestEmailTo")]
        public string SendTestEmailTo { get; set; }

        #endregion
    }
}