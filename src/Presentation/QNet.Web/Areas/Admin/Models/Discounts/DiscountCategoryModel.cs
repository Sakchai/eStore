using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Discounts
{
    /// <summary>
    /// Represents a discount category model
    /// </summary>
    public partial class DiscountCategoryModel : BaseQNetEntityModel
    {
        #region Properties

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        #endregion
    }
}