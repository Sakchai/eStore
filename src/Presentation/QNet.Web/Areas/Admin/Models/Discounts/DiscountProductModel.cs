using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Discounts
{
    /// <summary>
    /// Represents a discount product model
    /// </summary>
    public partial class DiscountProductModel : BaseQNetEntityModel
    {
        #region Properties

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        #endregion
    }
}