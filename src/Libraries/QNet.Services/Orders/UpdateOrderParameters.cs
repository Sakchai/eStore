﻿using System;
using System.Collections.Generic;
using QNet.Core.Domain.Customers;
using QNet.Core.Domain.Orders;
using QNet.Core.Domain.Shipping;
using QNet.Services.Discounts;

namespace QNet.Services.Orders
{
    /// <summary>
    /// Parameters for the updating order totals
    /// </summary>
    public class UpdateOrderParameters
    {
        #region Ctor

        public UpdateOrderParameters(Order updatedOrder, OrderItem updatedOrderItem)
        {
            if (updatedOrder is null)
                throw new ArgumentNullException(nameof(updatedOrder));

            if (updatedOrderItem is null)
                throw new ArgumentNullException(nameof(updatedOrderItem));

            UpdatedOrder = updatedOrder;
            UpdatedOrderItem = updatedOrderItem;
        }

        #endregion

        /// <summary>
        /// Gets customer of order
        /// </summary>
        public Customer OrderCustomer => UpdatedOrder?.Customer;

        /// <summary>
        /// The updated order
        /// </summary>
        public Order UpdatedOrder { get; protected set; }

        /// <summary>
        /// The updated order item
        /// </summary>
        public OrderItem UpdatedOrderItem { get; protected set; }

        /// <summary>
        /// The price of item with tax
        /// </summary>
        public decimal PriceInclTax { get; set; }

        /// <summary>
        /// The price of item without tax
        /// </summary>
        public decimal PriceExclTax { get; set; }

        /// <summary>
        /// The quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// The amount of discount with tax
        /// </summary>
        public decimal DiscountAmountInclTax { get; set; }

        /// <summary>
        /// The amount of discount without tax
        /// </summary>
        public decimal DiscountAmountExclTax { get; set; }

        /// <summary>
        /// Subtotal of item with tax
        /// </summary>
        public decimal SubTotalInclTax { get; set; }

        /// <summary>
        /// Subtotal of item without tax
        /// </summary>
        public decimal SubTotalExclTax { get; set; }

        /// <summary>
        /// Warnings
        /// </summary>
        public List<string> Warnings { get; } = new List<string>();

        /// <summary>
        /// Applied discounts
        /// </summary>
        public List<DiscountForCaching> AppliedDiscounts { get; } = new List<DiscountForCaching>();

        /// <summary>
        /// Pickup point
        /// </summary>
        public PickupPoint PickupPoint { get; set; }
    }
}