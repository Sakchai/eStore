using QNet.Web.Framework.Models;
using QNet.Web.Models.Common;

namespace QNet.Web.Models.Customer
{
    public partial class CustomerAddressEditModel : BaseQNetModel
    {
        public CustomerAddressEditModel()
        {
            Address = new AddressModel();
        }
        
        public AddressModel Address { get; set; }
    }
}