using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Reports
{
    /// <summary>
    /// Represents a country report model
    /// </summary>
    public partial class CountryReportModel : BaseQNetModel
    {
        #region Properties

        [QNetResourceDisplayName("Admin.Reports.Sales.Country.Fields.CountryName")]
        public string CountryName { get; set; }

        [QNetResourceDisplayName("Admin.Reports.Sales.Country.Fields.TotalOrders")]
        public int TotalOrders { get; set; }

        [QNetResourceDisplayName("Admin.Reports.Sales.Country.Fields.SumOrders")]
        public string SumOrders { get; set; }

        #endregion
    }
}