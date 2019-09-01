using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Reports
{
    /// <summary>
    /// Represents a never sold products report model
    /// </summary>
    public partial class NeverSoldReportModel : BaseQNetModel
    {
        #region Properties

        public int ProductId { get; set; }

        [QNetResourceDisplayName("Admin.Reports.Sales.NeverSold.Fields.Name")]
        public string ProductName { get; set; }

        #endregion
    }
}