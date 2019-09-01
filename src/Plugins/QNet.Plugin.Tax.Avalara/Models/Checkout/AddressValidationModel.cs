using QNet.Web.Framework.Models;

namespace QNet.Plugin.Tax.Avalara.Models.Checkout
{
    /// <summary>
    /// Represents an address validation model
    /// </summary>
    public class AddressValidationModel : BaseQNetModel
    {
        #region Properties

        public string Message { get; set; }

        public bool IsError { get; set; }

        public bool IsNewAddress { get; set; }

        public int AddressId { get; set; }

        #endregion
    }
}