using System;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Customers
{
    /// <summary>
    /// Represents a GDPR log (request) model
    /// </summary>
    public partial class GdprLogModel : BaseQNetEntityModel
    {
        #region Properties

        [QNetResourceDisplayName("Admin.Customers.GdprLog.Fields.CustomerInfo")]
        public string CustomerInfo { get; set; }

        [QNetResourceDisplayName("Admin.Customers.GdprLog.Fields.RequestType")]
        public string RequestType { get; set; }

        [QNetResourceDisplayName("Admin.Customers.GdprLog.Fields.RequestDetails")]
        public string RequestDetails { get; set; }

        [QNetResourceDisplayName("Admin.Customers.GdprLog.Fields.CreatedOn")]
        public DateTime CreatedOn { get; set; }

        #endregion
    }
}