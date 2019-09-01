using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Discounts
{
    /// <summary>
    /// Represents a manufacturer search model to add to the discount
    /// </summary>
    public partial class AddManufacturerToDiscountSearchModel : BaseSearchModel
    {
        #region Properties

        [QNetResourceDisplayName("Admin.Catalog.Manufacturers.List.SearchManufacturerName")]
        public string SearchManufacturerName { get; set; }

        #endregion
    }
}