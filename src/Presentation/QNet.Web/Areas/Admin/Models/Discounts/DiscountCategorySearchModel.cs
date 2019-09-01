using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Discounts
{
    /// <summary>
    /// Represents a discount category search model
    /// </summary>
    public partial class DiscountCategorySearchModel : BaseSearchModel
    {
        #region Properties

        public int DiscountId { get; set; }

        #endregion
    }
}