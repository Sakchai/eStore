using System.Collections.Generic;
using QNet.Web.Framework.Models;
using QNet.Web.Models.Common;

namespace QNet.Web.Models.Customer
{
    public partial class CustomerAddressListModel : BaseQNetModel
    {
        public CustomerAddressListModel()
        {
            Addresses = new List<AddressModel>();
        }

        public IList<AddressModel> Addresses { get; set; }
    }
}