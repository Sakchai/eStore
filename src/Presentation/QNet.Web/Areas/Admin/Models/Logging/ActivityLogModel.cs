using System;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Logging
{
    /// <summary>
    /// Represents an activity log model
    /// </summary>
    public partial class ActivityLogModel : BaseQNetEntityModel
    {
        #region Properties

        [QNetResourceDisplayName("Admin.Configuration.ActivityLog.ActivityLog.Fields.ActivityLogType")]
        public string ActivityLogTypeName { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.ActivityLog.ActivityLog.Fields.Customer")]
        public int CustomerId { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.ActivityLog.ActivityLog.Fields.Customer")]
        public string CustomerEmail { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.ActivityLog.ActivityLog.Fields.Comment")]
        public string Comment { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.ActivityLog.ActivityLog.Fields.CreatedOn")]
        public DateTime CreatedOn { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.ActivityLog.IpAddress")]
        public string IpAddress { get; set; }

        #endregion
    }
}