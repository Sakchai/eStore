using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Reports
{
    /// <summary>
    /// Represents a best customers report model
    /// </summary>
    public partial class BestCustomersReportModel : BaseQNetModel
    {
        #region Properties

        public int CustomerId { get; set; }

        [QNetResourceDisplayName("Admin.Reports.Customers.BestBy.Fields.Customer")]
        public string CustomerName { get; set; }

        [QNetResourceDisplayName("Admin.Reports.Customers.BestBy.Fields.OrderTotal")]
        public string OrderTotal { get; set; }

        [QNetResourceDisplayName("Admin.Reports.Customers.BestBy.Fields.OrderCount")]
        public decimal OrderCount { get; set; }
        
        #endregion
    }
}