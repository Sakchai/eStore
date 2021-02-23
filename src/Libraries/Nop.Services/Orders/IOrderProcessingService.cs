﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Shipping;
using Nop.Services.Payments;

namespace Nop.Services.Orders
{
    /// <summary>
    /// Order processing service interface
    /// </summary>
    public partial interface IOrderProcessingService
    {
        /// <summary>
        /// Checks order status
        /// </summary>
        /// <param name="order">Order</param>
        Task CheckOrderStatusAsync(Order order);

        /// <summary>
        /// Places an order
        /// </summary>
        /// <param name="processPaymentRequest">Process payment request</param>
        /// <returns>Place order result</returns>
        Task<PlaceOrderResult> PlaceOrderAsync(ProcessPaymentRequest processPaymentRequest);

        /// <summary>
        /// Update order totals
        /// </summary>
        /// <param name="updateOrderParameters">Parameters for the updating order</param>
        Task UpdateOrderTotalsAsync(UpdateOrderParameters updateOrderParameters);

        /// <summary>
        /// Deletes an order
        /// </summary>
        /// <param name="order">The order</param>
        Task DeleteOrderAsync(Order order);

        /// <summary>
        /// Process next recurring payment
        /// </summary>
        /// <param name="recurringPayment">Recurring payment</param>
        /// <param name="paymentResult">Process payment result (info about last payment for automatic recurring payments)</param>
        /// <returns>Collection of errors</returns>
        Task<IEnumerable<string>> ProcessNextRecurringPaymentAsync(RecurringPayment recurringPayment, ProcessPaymentResult paymentResult = null);

        /// <summary>
        /// Cancels a recurring payment
        /// </summary>
        /// <param name="recurringPayment">Recurring payment</param>
        Task<IList<string>> CancelRecurringPaymentAsync(RecurringPayment recurringPayment);

        /// <summary>
        /// Gets a value indicating whether a customer can cancel recurring payment
        /// </summary>
        /// <param name="customerToValidate">Customer</param>
        /// <param name="recurringPayment">Recurring Payment</param>
        /// <returns>value indicating whether a customer can cancel recurring payment</returns>
        Task<bool> CanCancelRecurringPaymentAsync(Customer customerToValidate, RecurringPayment recurringPayment);

        /// <summary>
        /// Gets a value indicating whether a customer can retry last failed recurring payment
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="recurringPayment">Recurring Payment</param>
        /// <returns>True if a customer can retry payment; otherwise false</returns>
        Task<bool> CanRetryLastRecurringPaymentAsync(Customer customer, RecurringPayment recurringPayment);

        /// <summary>
        /// Send a shipment
        /// </summary>
        /// <param name="shipment">Shipment</param>
        /// <param name="notifyCustomer">True to notify customer</param>
        Task ShipAsync(Shipment shipment, bool notifyCustomer);
        
        /// <summary>
        /// Marks a shipment as delivered
        /// </summary>
        /// <param name="shipment">Shipment</param>
        /// <param name="notifyCustomer">True to notify customer</param>
        Task DeliverAsync(Shipment shipment, bool notifyCustomer);

        /// <summary>
        /// Gets a value indicating whether cancel is allowed
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>A value indicating whether cancel is allowed</returns>
        bool CanCancelOrder(Order order);

        /// <summary>
        /// Cancels order
        /// </summary>
        /// <param name="order">Order</param>
        /// <param name="notifyCustomer">True to notify customer</param>
        Task CancelOrderAsync(Order order, bool notifyCustomer);

        /// <summary>
        /// Gets a value indicating whether order can be marked as authorized
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>A value indicating whether order can be marked as authorized</returns>
        bool CanMarkOrderAsAuthorized(Order order);

        /// <summary>
        /// Marks order as authorized
        /// </summary>
        /// <param name="order">Order</param>
        Task MarkAsAuthorizedAsync(Order order);

        /// <summary>
        /// Gets a value indicating whether capture from admin panel is allowed
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>A value indicating whether capture from admin panel is allowed</returns>
        Task<bool> CanCaptureAsync(Order order);

        /// <summary>
        /// Capture an order (from admin panel)
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>A list of errors; empty list if no errors</returns>
        Task<IList<string>> CaptureAsync(Order order);

        /// <summary>
        /// Gets a value indicating whether order can be marked as paid
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>A value indicating whether order can be marked as paid</returns>
        bool CanMarkOrderAsPaid(Order order);

        /// <summary>
        /// Marks order as paid
        /// </summary>
        /// <param name="order">Order</param>
        Task MarkOrderAsPaidAsync(Order order);

        /// <summary>
        /// Gets a value indicating whether refund from admin panel is allowed
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>A value indicating whether refund from admin panel is allowed</returns>
        Task<bool> CanRefundAsync(Order order);

        /// <summary>
        /// Refunds an order (from admin panel)
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>A list of errors; empty list if no errors</returns>
        Task<IList<string>> RefundAsync(Order order);

        /// <summary>
        /// Gets a value indicating whether order can be marked as refunded
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>A value indicating whether order can be marked as refunded</returns>
        bool CanRefundOffline(Order order);

        /// <summary>
        /// Refunds an order (offline)
        /// </summary>
        /// <param name="order">Order</param>
        Task RefundOfflineAsync(Order order);

        /// <summary>
        /// Gets a value indicating whether partial refund from admin panel is allowed
        /// </summary>
        /// <param name="order">Order</param>
        /// <param name="amountToRefund">Amount to refund</param>
        /// <returns>A value indicating whether refund from admin panel is allowed</returns>
        Task<bool> CanPartiallyRefundAsync(Order order, decimal amountToRefund);

        /// <summary>
        /// Partially refunds an order (from admin panel)
        /// </summary>
        /// <param name="order">Order</param>
        /// <param name="amountToRefund">Amount to refund</param>
        /// <returns>A list of errors; empty list if no errors</returns>
        Task<IList<string>> PartiallyRefundAsync(Order order, decimal amountToRefund);

        /// <summary>
        /// Gets a value indicating whether order can be marked as partially refunded
        /// </summary>
        /// <param name="order">Order</param>
        /// <param name="amountToRefund">Amount to refund</param>
        /// <returns>A value indicating whether order can be marked as partially refunded</returns>
        bool CanPartiallyRefundOffline(Order order, decimal amountToRefund);

        /// <summary>
        /// Partially refunds an order (offline)
        /// </summary>
        /// <param name="order">Order</param>
        /// <param name="amountToRefund">Amount to refund</param>
        Task PartiallyRefundOfflineAsync(Order order, decimal amountToRefund);

        /// <summary>
        /// Gets a value indicating whether Task from admin panel is allowed
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>A value indicating whether Task from admin panel is allowed</returns>
        Task<bool> CanVoidAsync(Order order);

        /// <summary>
        /// Voids order (from admin panel)
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>Voided order</returns>
        Task<IList<string>> VoidAsync(Order order);

        /// <summary>
        /// Gets a value indicating whether order can be marked as Tasked
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>A value indicating whether order can be marked as Tasked</returns>
        bool CanVoidOffline(Order order);

        /// <summary>
        /// Voids order (offline)
        /// </summary>
        /// <param name="order">Order</param>
        Task VoidOfflineAsync(Order order);

        /// <summary>
        /// Place order items in current user shopping cart.
        /// </summary>
        /// <param name="order">The order</param>
        Task ReOrderAsync(Order order);

        /// <summary>
        /// Check whether return request is allowed
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>Result</returns>
        Task<bool> IsReturnRequestAllowedAsync(Order order);

        /// <summary>
        /// Validate minimum order sub-total amount
        /// </summary>
        /// <param name="cart">Shopping cart</param>
        /// <returns>true - OK; false - minimum order sub-total amount is not reached</returns>
        Task<bool> ValidateMinOrderSubtotalAmountAsync(IList<ShoppingCartItem> cart);

        /// <summary>
        /// Validate minimum order total amount
        /// </summary>
        /// <param name="cart">Shopping cart</param>
        /// <returns>true - OK; false - minimum order total amount is not reached</returns>
        Task<bool> ValidateMinOrderTotalAmountAsync(IList<ShoppingCartItem> cart);

        /// <summary>
        /// Gets a value indicating whether payment workflow is required
        /// </summary>
        /// <param name="cart">Shopping cart</param>
        /// <param name="useRewardPoints">A value indicating reward points should be used; null to detect current choice of the customer</param>
        /// <returns>true - OK; false - minimum order total amount is not reached</returns>
        Task<bool> IsPaymentWorkflowRequiredAsync(IList<ShoppingCartItem> cart, bool? useRewardPoints = null);

        /// <summary>
        /// Gets the next payment date
        /// </summary>
        /// <param name="recurringPayment">Recurring payment</param>
        Task<DateTime?> GetNextPaymentDateAsync(RecurringPayment recurringPayment);

        /// <summary>
        /// Gets the cycles remaining
        /// </summary>
        /// <param name="recurringPayment">Recurring payment</param>
        Task<int> GetCyclesRemainingAsync(RecurringPayment recurringPayment);
    }
}
