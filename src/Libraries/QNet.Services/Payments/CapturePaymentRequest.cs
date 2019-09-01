using QNet.Core.Domain.Orders;

namespace QNet.Services.Payments
{
    /// <summary>
    /// Represents a CapturePaymentRequest
    /// </summary>
    public partial class CapturePaymentRequest
    {
        /// <summary>
        /// Gets or sets an order
        /// </summary>
        public Order Order { get; set; }
    }
}
