using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Reports
{
    /// <summary>
    /// Represents a bestseller model
    /// </summary>
    public partial class BestsellerModel : BaseQNetModel
    {
        #region Properties

        public int ProductId { get; set; }

        [QNetResourceDisplayName("Admin.Reports.Sales.Bestsellers.Fields.Name")]
        public string ProductName { get; set; }

        [QNetResourceDisplayName("Admin.Reports.Sales.Bestsellers.Fields.TotalAmount")]
        public string TotalAmount { get; set; }

        [QNetResourceDisplayName("Admin.Reports.Sales.Bestsellers.Fields.TotalQuantity")]
        public decimal TotalQuantity { get; set; }

        #endregion
    }
}