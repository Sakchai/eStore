using System;
using System.ComponentModel.DataAnnotations;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Messages
{
    /// <summary>
    /// Represents a queued email model
    /// </summary>
    public partial class QueuedEmailModel: BaseQNetEntityModel
    {
        #region Properties

        [QNetResourceDisplayName("Admin.System.QueuedEmails.Fields.Id")]
        public override int Id { get; set; }

        [QNetResourceDisplayName("Admin.System.QueuedEmails.Fields.Priority")]
        public string PriorityName { get; set; }

        [QNetResourceDisplayName("Admin.System.QueuedEmails.Fields.From")]
        public string From { get; set; }

        [QNetResourceDisplayName("Admin.System.QueuedEmails.Fields.FromName")]
        public string FromName { get; set; }

        [QNetResourceDisplayName("Admin.System.QueuedEmails.Fields.To")]
        public string To { get; set; }

        [QNetResourceDisplayName("Admin.System.QueuedEmails.Fields.ToName")]
        public string ToName { get; set; }

        [QNetResourceDisplayName("Admin.System.QueuedEmails.Fields.ReplyTo")]
        public string ReplyTo { get; set; }

        [QNetResourceDisplayName("Admin.System.QueuedEmails.Fields.ReplyToName")]
        public string ReplyToName { get; set; }

        [QNetResourceDisplayName("Admin.System.QueuedEmails.Fields.CC")]
        public string CC { get; set; }

        [QNetResourceDisplayName("Admin.System.QueuedEmails.Fields.Bcc")]
        public string Bcc { get; set; }

        [QNetResourceDisplayName("Admin.System.QueuedEmails.Fields.Subject")]
        public string Subject { get; set; }

        [QNetResourceDisplayName("Admin.System.QueuedEmails.Fields.Body")]
        public string Body { get; set; }

        [QNetResourceDisplayName("Admin.System.QueuedEmails.Fields.AttachmentFilePath")]
        public string AttachmentFilePath { get; set; }

        [QNetResourceDisplayName("Admin.System.QueuedEmails.Fields.AttachedDownload")]
        [UIHint("Download")]
        public int AttachedDownloadId { get; set; }

        [QNetResourceDisplayName("Admin.System.QueuedEmails.Fields.CreatedOn")]
        public DateTime CreatedOn { get; set; }

        [QNetResourceDisplayName("Admin.System.QueuedEmails.Fields.SendImmediately")]
        public bool SendImmediately { get; set; }

        [QNetResourceDisplayName("Admin.System.QueuedEmails.Fields.DontSendBeforeDate")]
        [UIHint("DateTimeNullable")]
        public DateTime? DontSendBeforeDate { get; set; }

        [QNetResourceDisplayName("Admin.System.QueuedEmails.Fields.SentTries")]
        public int SentTries { get; set; }

        [QNetResourceDisplayName("Admin.System.QueuedEmails.Fields.SentOn")]
        public DateTime? SentOn { get; set; }

        [QNetResourceDisplayName("Admin.System.QueuedEmails.Fields.EmailAccountName")]
        public string EmailAccountName { get; set; }

        #endregion
    }
}