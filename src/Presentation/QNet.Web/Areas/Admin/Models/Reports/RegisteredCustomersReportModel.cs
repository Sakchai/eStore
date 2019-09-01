using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Reports
{
    /// <summary>
    /// Represents a registered customers report model
    /// </summary>
    public partial class RegisteredCustomersReportModel : BaseQNetModel
    {
        #region Properties

        [QNetResourceDisplayName("Admin.Reports.Customers.RegisteredCustomers.Fields.Period")]
        public string Period { get; set; }

        [QNetResourceDisplayName("Admin.Reports.Customers.RegisteredCustomers.Fields.Customers")]
        public int Customers { get; set; }

        #endregion
    }
}