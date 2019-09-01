using System;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Logging
{
    /// <summary>
    /// Represents a log model
    /// </summary>
    public partial class LogModel : BaseQNetEntityModel
    {
        #region Properties

        [QNetResourceDisplayName("Admin.System.Log.Fields.LogLevel")]
        public string LogLevel { get; set; }

        [QNetResourceDisplayName("Admin.System.Log.Fields.ShortMessage")]
        public string ShortMessage { get; set; }

        [QNetResourceDisplayName("Admin.System.Log.Fields.FullMessage")]
        public string FullMessage { get; set; }

        [QNetResourceDisplayName("Admin.System.Log.Fields.IPAddress")]
        public string IpAddress { get; set; }

        [QNetResourceDisplayName("Admin.System.Log.Fields.Customer")]
        public int? CustomerId { get; set; }

        [QNetResourceDisplayName("Admin.System.Log.Fields.Customer")]
        public string CustomerEmail { get; set; }

        [QNetResourceDisplayName("Admin.System.Log.Fields.PageURL")]
        public string PageUrl { get; set; }

        [QNetResourceDisplayName("Admin.System.Log.Fields.ReferrerURL")]
        public string ReferrerUrl { get; set; }

        [QNetResourceDisplayName("Admin.System.Log.Fields.CreatedOn")]
        public DateTime CreatedOn { get; set; }

        #endregion
    }
}