using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a product model to associate to the product attribute value
    /// </summary>
    public partial class AssociateProductToAttributeValueModel : BaseQNetModel
    {
        #region Properties
        
        public int AssociatedToProductId { get; set; }

        #endregion
    }
}