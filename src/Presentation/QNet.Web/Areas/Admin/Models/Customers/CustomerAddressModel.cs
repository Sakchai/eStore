using QNet.Web.Areas.Admin.Models.Common;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Customers
{
    /// <summary>
    /// Represents a customer address model
    /// </summary>
    public partial class CustomerAddressModel : BaseQNetModel
    {
        #region Ctor

        public CustomerAddressModel()
        {
            Address = new AddressModel();
        }

        #endregion

        #region Properties

        public int CustomerId { get; set; }

        public AddressModel Address { get; set; }

        #endregion
    }
}