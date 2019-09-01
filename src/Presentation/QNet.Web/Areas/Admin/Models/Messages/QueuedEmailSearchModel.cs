using System;
using System.ComponentModel.DataAnnotations;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Messages
{
    /// <summary>
    /// Represents a queued email search model
    /// </summary>
    public partial class QueuedEmailSearchModel : BaseSearchModel
    {
        #region Properties

        [QNetResourceDisplayName("Admin.System.QueuedEmails.List.StartDate")]
        [UIHint("DateNullable")]
        public DateTime? SearchStartDate { get; set; }

        [QNetResourceDisplayName("Admin.System.QueuedEmails.List.EndDate")]
        [UIHint("DateNullable")]
        public DateTime? SearchEndDate { get; set; }

        [DataType(DataType.EmailAddress)]
        [QNetResourceDisplayName("Admin.System.QueuedEmails.List.FromEmail")]
        public string SearchFromEmail { get; set; }

        [DataType(DataType.EmailAddress)]
        [QNetResourceDisplayName("Admin.System.QueuedEmails.List.ToEmail")]
        public string SearchToEmail { get; set; }

        [QNetResourceDisplayName("Admin.System.QueuedEmails.List.LoadNotSent")]
        public bool SearchLoadNotSent { get; set; }

        [QNetResourceDisplayName("Admin.System.QueuedEmails.List.MaxSentTries")]
        public int SearchMaxSentTries { get; set; }

        [QNetResourceDisplayName("Admin.System.QueuedEmails.List.GoDirectlyToNumber")]
        public int GoDirectlyToNumber { get; set; }

        #endregion
    }
}