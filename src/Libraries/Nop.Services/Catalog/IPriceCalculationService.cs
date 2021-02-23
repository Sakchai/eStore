﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Directory;
using Nop.Core.Domain.Discounts;

namespace Nop.Services.Catalog
{
    /// <summary>
    /// Price calculation service
    /// </summary>
    public partial interface IPriceCalculationService
    {
        /// <summary>
        /// Gets the final price
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="customer">The customer</param>
        /// <param name="additionalCharge">Additional charge</param>
        /// <param name="includeDiscounts">A value indicating whether include discounts or not for final price computation</param>
        /// <param name="quantity">Shopping cart item quantity</param>
        /// <returns>Final price without discounts, Final price, Applied discount amount, Applied discounts</returns>
        Task<(decimal priceWithoutDiscounts, decimal finalPrice, decimal appliedDiscountAmount, List<Discount> appliedDiscounts)> GetFinalPriceAsync(Product product,
            Customer customer,
            decimal additionalCharge = 0,
            bool includeDiscounts = true,
            int quantity = 1);

        /// <summary>
        /// Gets the final price
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="customer">The customer</param>
        /// <param name="additionalCharge">Additional charge</param>
        /// <param name="includeDiscounts">A value indicating whether include discounts or not for final price computation</param>
        /// <param name="quantity">Shopping cart item quantity</param>
        /// <param name="rentalStartDate">Rental period start date (for rental products)</param>
        /// <param name="rentalEndDate">Rental period end date (for rental products)</param>
        /// <returns>Final price without discounts, Final price, Applied discount amount, Applied discounts</returns>
        Task<(decimal priceWithoutDiscounts, decimal finalPrice, decimal appliedDiscountAmount, List<Discount> appliedDiscounts)> GetFinalPriceAsync(Product product,
            Customer customer,
            decimal additionalCharge,
            bool includeDiscounts,
            int quantity,
            DateTime? rentalStartDate,
            DateTime? rentalEndDate);

        /// <summary>
        /// Gets the final price
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="customer">The customer</param>
        /// <param name="overriddenProductPrice">Overridden product price. If specified, then it'll be used instead of a product price. For example, used with product attribute combinations</param>
        /// <param name="additionalCharge">Additional charge</param>
        /// <param name="includeDiscounts">A value indicating whether include discounts or not for final price computation</param>
        /// <param name="quantity">Shopping cart item quantity</param>
        /// <param name="rentalStartDate">Rental period start date (for rental products)</param>
        /// <param name="rentalEndDate">Rental period end date (for rental products)</param>
        /// <returns>Final price without discounts, Final price, Applied discount amount, Applied discounts</returns>
        Task<(decimal priceWithoutDiscounts, decimal finalPrice, decimal appliedDiscountAmount, List<Discount> appliedDiscounts)> GetFinalPriceAsync(Product product,
            Customer customer,
            decimal? overriddenProductPrice,
            decimal additionalCharge,
            bool includeDiscounts,
            int quantity,
            DateTime? rentalStartDate,
            DateTime? rentalEndDate);

        /// <summary>
        /// Gets the product cost (one item)
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="attributesXml">Shopping cart item attributes in XML</param>
        /// <returns>Product cost (one item)</returns>
        Task<decimal> GetProductCostAsync(Product product, string attributesXml);

        /// <summary>
        /// Get a price adjustment of a product attribute value
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="value">Product attribute value</param>
        /// <param name="customer">Customer</param>
        /// <param name="productPrice">Product price (null for using the base product price)</param>
        /// <returns>Price adjustment</returns>
        Task<decimal> GetProductAttributeValuePriceAdjustmentAsync(Product product, ProductAttributeValue value, Customer customer, decimal? productPrice = null);

        /// <summary>
        /// Round a product or order total for the currency
        /// </summary>
        /// <param name="value">Value to round</param>
        /// <param name="currency">Currency; pass null to use the primary store currency</param>
        /// <returns>Rounded value</returns>
        Task<decimal> RoundPriceAsync(decimal value, Currency currency = null);

        //TODO: migrate to an extension method
        /// <summary>
        /// Round
        /// </summary>
        /// <param name="value">Value to round</param>
        /// <param name="roundingType">The rounding type</param>
        /// <returns>Rounded value</returns>
        decimal Round(decimal value, RoundingType roundingType);
    }
}