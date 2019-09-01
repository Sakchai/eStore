using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Orders
{
    /// <summary>
    /// Represents an incomplete order report model
    /// </summary>
    public partial class OrderIncompleteReportModel : BaseQNetModel
    {
        #region Properties

        [QNetResourceDisplayName("Admin.SalesReport.Incomplete.Item")]
        public string Item { get; set; }

        [QNetResourceDisplayName("Admin.SalesReport.Incomplete.Total")]
        public string Total { get; set; }

        [QNetResourceDisplayName("Admin.SalesReport.Incomplete.Count")]
        public int Count { get; set; }

        [QNetResourceDisplayName("Admin.SalesReport.Incomplete.View")]
        public string ViewLink { get; set; }

        #endregion
    }
}