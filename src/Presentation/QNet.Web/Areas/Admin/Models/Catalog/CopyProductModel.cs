using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a copy product model
    /// </summary>
    public partial class CopyProductModel : BaseQNetEntityModel
    {
        #region Properties

        [QNetResourceDisplayName("Admin.Catalog.Products.Copy.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.Copy.CopyImages")]
        public bool CopyImages { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.Copy.Published")]
        public bool Published { get; set; }

        #endregion
    }
}