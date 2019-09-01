using System.Collections.Generic;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a product model to add to the category
    /// </summary>
    public partial class AddProductToCategoryModel : BaseQNetModel
    {
        #region Ctor

        public AddProductToCategoryModel()
        {
            SelectedProductIds = new List<int>();
        }
        #endregion

        #region Properties

        public int CategoryId { get; set; }

        public IList<int> SelectedProductIds { get; set; }

        #endregion
    }
}