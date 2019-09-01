using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Orders
{
    /// <summary>
    /// Represents a checkout attribute value search model
    /// </summary>
    public partial class CheckoutAttributeValueSearchModel : BaseSearchModel
    {
        #region Properties

        public int CheckoutAttributeId { get; set; }

        #endregion
    }
}