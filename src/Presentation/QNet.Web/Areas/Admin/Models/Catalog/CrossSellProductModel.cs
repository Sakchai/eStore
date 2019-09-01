using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a cross-sell product model
    /// </summary>
    public partial class CrossSellProductModel : BaseQNetEntityModel
    {
        #region Properties

        public int ProductId2 { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.CrossSells.Fields.Product")]
        public string Product2Name { get; set; }

        #endregion
    }
}