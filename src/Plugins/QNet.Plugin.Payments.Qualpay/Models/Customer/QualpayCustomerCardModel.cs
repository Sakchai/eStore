using QNet.Web.Framework.Models;

namespace QNet.Plugin.Payments.Qualpay.Models.Customer
{
    /// <summary>
    /// Represents Qualpay customer card model
    /// </summary>
    public class QualpayCustomerCardModel : BaseQNetModel
    {
        public string Id { get; set; }

        public string CardId { get; set; }

        public string MaskedNumber { get; set; }

        public string ExpirationDate { get; set; }

        public string CardType { get; set; }
    }
}