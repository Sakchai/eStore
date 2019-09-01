using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Discounts
{
    /// <summary>
    /// Represents a category search model to add to the discount
    /// </summary>
    public partial class AddCategoryToDiscountSearchModel : BaseSearchModel
    {
        #region Properties

        [QNetResourceDisplayName("Admin.Catalog.Categories.List.SearchCategoryName")]
        public string SearchCategoryName { get; set; }

        #endregion
    }
}