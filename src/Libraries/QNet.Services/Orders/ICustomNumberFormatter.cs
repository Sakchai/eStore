using QNet.Core.Domain.Orders;

namespace QNet.Services.Orders
{
    /// <summary>
    /// Custom number formatter
    /// </summary>
    public partial interface ICustomNumberFormatter
    {
        /// <summary>
        /// Generate return request custom number
        /// </summary>
        /// <param name="returnRequest">Return request</param>
        /// <returns>Custom number</returns>
        string GenerateReturnRequestCustomNumber(ReturnRequest returnRequest);

        /// <summary>
        /// Generate order custom number
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>Custom number</returns>
        string GenerateOrderCustomNumber(Order order);
    }
}