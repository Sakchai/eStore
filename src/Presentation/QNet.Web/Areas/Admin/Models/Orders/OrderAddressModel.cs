using QNet.Web.Areas.Admin.Models.Common;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Orders
{
    public partial class OrderAddressModel : BaseQNetModel
    {
        #region Ctor

        public OrderAddressModel()
        {
            Address = new AddressModel();
        }

        #endregion

        #region Properties

        public int OrderId { get; set; }

        public AddressModel Address { get; set; }

        #endregion
    }
}