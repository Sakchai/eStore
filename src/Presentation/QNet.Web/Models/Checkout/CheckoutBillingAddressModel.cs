using System.Collections.Generic;
using QNet.Web.Framework.Models;
using QNet.Web.Models.Common;

namespace QNet.Web.Models.Checkout
{
    public partial class CheckoutBillingAddressModel : BaseQNetModel
    {
        public CheckoutBillingAddressModel()
        {
            ExistingAddresses = new List<AddressModel>();
            InvalidExistingAddresses = new List<AddressModel>();
            BillingNewAddress = new AddressModel();
        }

        public IList<AddressModel> ExistingAddresses { get; set; }
        public IList<AddressModel> InvalidExistingAddresses { get; set; }

        public AddressModel BillingNewAddress { get; set; }

        public bool ShipToSameAddress { get; set; }
        public bool ShipToSameAddressAllowed { get; set; }

        /// <summary>
        /// Used on one-page checkout page
        /// </summary>
        public bool NewAddressPreselected { get; set; }
    }
}