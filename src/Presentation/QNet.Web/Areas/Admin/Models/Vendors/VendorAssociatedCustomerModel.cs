using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Vendors
{
    /// <summary>
    /// Represents a vendor associated customer model
    /// </summary>
    public partial class VendorAssociatedCustomerModel : BaseQNetEntityModel
    {
        #region Properties

        public string Email { get; set; }

        #endregion
    }
}