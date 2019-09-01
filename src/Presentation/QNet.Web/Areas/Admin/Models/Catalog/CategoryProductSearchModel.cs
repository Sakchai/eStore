using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a category product search model
    /// </summary>
    public partial class CategoryProductSearchModel : BaseSearchModel
    {
        #region Properties

        public int CategoryId { get; set; }

        #endregion
    }
}