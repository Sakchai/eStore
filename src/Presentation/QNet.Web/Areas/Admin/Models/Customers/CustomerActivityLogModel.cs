using System;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Customers
{
    /// <summary>
    /// Represents a customer activity log model
    /// </summary>
    public partial class CustomerActivityLogModel : BaseQNetEntityModel
    {
        #region Properties

        [QNetResourceDisplayName("Admin.Customers.Customers.ActivityLog.ActivityLogType")]
        public string ActivityLogTypeName { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.ActivityLog.Comment")]
        public string Comment { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.ActivityLog.CreatedOn")]
        public DateTime CreatedOn { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.ActivityLog.IpAddress")]
        public string IpAddress { get; set; }

        #endregion
    }
}