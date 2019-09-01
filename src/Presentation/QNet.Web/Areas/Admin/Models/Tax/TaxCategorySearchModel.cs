using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Tax
{
    /// <summary>
    /// Represents a tax category search model
    /// </summary>
    public partial class TaxCategorySearchModel : BaseSearchModel
    {
        #region Ctor

        public TaxCategorySearchModel()
        {
            AddTaxCategory = new TaxCategoryModel();
        }

        #endregion

        #region Properties

        public TaxCategoryModel AddTaxCategory { get; set; }

        #endregion
    }
}