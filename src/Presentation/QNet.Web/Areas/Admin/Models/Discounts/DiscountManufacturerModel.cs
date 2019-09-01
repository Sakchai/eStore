using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Discounts
{
    /// <summary>
    /// Represents a discount manufacturer model
    /// </summary>
    public partial class DiscountManufacturerModel : BaseQNetEntityModel
    {
        #region Properties

        public int ManufacturerId { get; set; }

        public string ManufacturerName { get; set; }

        #endregion
    }
}