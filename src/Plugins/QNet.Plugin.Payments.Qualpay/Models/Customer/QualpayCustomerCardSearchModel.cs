using QNet.Web.Framework.Models;

namespace QNet.Plugin.Payments.Qualpay.Models.Customer
{
    /// <summary>
    /// Represents Qualpay customer card search model
    /// </summary>
    public class QualpayCustomerCardSearchModel : BaseSearchModel
    {
        public int CustomerId { get; set; }
    }
}