﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Orders;
using Nop.Web.Models.Catalog;

namespace Nop.Web.Factories
{

    /// <summary>
    /// Represents the interface of the product model factory
    /// </summary>
    public partial interface IProductModelFactory
    {
        /// <summary>
        /// Get the product template view path
        /// </summary>
        /// <param name="product">Product</param>
        /// <returns>View path</returns>
        Task<string> PrepareProductTemplateViewPathAsync(Product product);

        /// <summary>
        /// Prepare the product overview models
        /// </summary>
        /// <param name="products">Collection of products</param>
        /// <param name="preparePriceModel">Whether to prepare the price model</param>
        /// <param name="preparePictureModel">Whether to prepare the picture model</param>
        /// <param name="productThumbPictureSize">Product thumb picture size (longest side); pass null to use the default value of media settings</param>
        /// <param name="prepareSpecificationAttributes">Whether to prepare the specification attribute models</param>
        /// <param name="forceRedirectionAfterAddingToCart">Whether to force redirection after adding to cart</param>
        /// <returns>Collection of product overview model</returns>
        Task<IEnumerable<ProductOverviewModel>> PrepareProductOverviewModelsAsync(IEnumerable<Product> products,
            bool preparePriceModel = true, bool preparePictureModel = true,
            int? productThumbPictureSize = null, bool prepareSpecificationAttributes = false,
            bool forceRedirectionAfterAddingToCart = false);

        /// <summary>
        /// Prepare the product combination models
        /// </summary>
        /// <param name="product">Product</param>
        /// <returns>Product combination models</returns>
        Task<IList<ProductCombinationModel>> PrepareProductCombinationModelsAsync(Product product);

        /// <summary>
        /// Prepare the product details model
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="updatecartitem">Updated shopping cart item</param>
        /// <param name="isAssociatedProduct">Whether the product is associated</param>
        /// <returns>Product details model</returns>
        Task<ProductDetailsModel> PrepareProductDetailsModelAsync(Product product, ShoppingCartItem updatecartitem = null, bool isAssociatedProduct = false);

        /// <summary>
        /// Prepare the product reviews model
        /// </summary>
        /// <param name="model">Product reviews model</param>
        /// <param name="product">Product</param>
        /// <returns>Product reviews model</returns>
        Task<ProductReviewsModel> PrepareProductReviewsModelAsync(ProductReviewsModel model, Product product);

        /// <summary>
        /// Prepare the customer product reviews model
        /// </summary>
        /// <param name="page">Number of items page; pass null to load the first page</param>
        /// <returns>Customer product reviews model</returns>
        Task<CustomerProductReviewsModel> PrepareCustomerProductReviewsModelAsync(int? page);

        /// <summary>
        /// Prepare the product email a friend model
        /// </summary>
        /// <param name="model">Product email a friend model</param>
        /// <param name="product">Product</param>
        /// <param name="excludeProperties">Whether to exclude populating of model properties from the entity</param>
        /// <returns>product email a friend model</returns>
        Task<ProductEmailAFriendModel> PrepareProductEmailAFriendModelAsync(ProductEmailAFriendModel model, Product product, bool excludeProperties);

        /// <summary>
        /// Prepare the product specification model
        /// </summary>
        /// <param name="product">Product</param>
        /// <returns>The product specification model</returns>
        Task<ProductSpecificationModel> PrepareProductSpecificationModelAsync(Product product);
    }
}