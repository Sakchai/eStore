using System.Collections.Generic;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a related product model to add to the product
    /// </summary>
    public partial class AddRelatedProductModel : BaseQNetModel
    {
        #region Ctor

        public AddRelatedProductModel()
        {
            SelectedProductIds = new List<int>();
        }
        #endregion

        #region Properties

        public int ProductId { get; set; }

        public IList<int> SelectedProductIds { get; set; }

        #endregion
    }
}