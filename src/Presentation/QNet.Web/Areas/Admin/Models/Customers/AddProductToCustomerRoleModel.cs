using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Customers
{
    /// <summary>
    /// Represents a product model to add to the customer role 
    /// </summary>
    public partial class AddProductToCustomerRoleModel : BaseQNetEntityModel
    {
        #region Properties

        public int AssociatedToProductId { get; set; }

        #endregion
    }
}