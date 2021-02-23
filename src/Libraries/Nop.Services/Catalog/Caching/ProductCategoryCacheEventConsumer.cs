﻿using System.Threading.Tasks;
using Nop.Core.Domain.Catalog;
using Nop.Services.Caching;

namespace Nop.Services.Catalog.Caching
{
    /// <summary>
    /// Represents a product category cache event consumer
    /// </summary>
    public partial class ProductCategoryCacheEventConsumer : CacheEventConsumer<ProductCategory>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override async Task ClearCacheAsync(ProductCategory entity)
        {
            await RemoveByPrefixAsync(NopCatalogDefaults.ProductCategoriesByProductPrefix, entity.ProductId);
            await RemoveByPrefixAsync(NopCatalogDefaults.CategoryProductsNumberPrefix);
            await RemoveByPrefixAsync(NopCatalogDefaults.ProductPricePrefix, entity.ProductId);
            await RemoveByPrefixAsync(NopCatalogDefaults.CategoryFeaturedProductsIdsPrefix, entity.CategoryId);
            await RemoveAsync(NopCatalogDefaults.SpecificationAttributeOptionsByCategoryCacheKey, entity.CategoryId.ToString());
            await RemoveAsync(NopCatalogDefaults.ManufacturersByCategoryCacheKey, entity.CategoryId.ToString());
        }
    }
}
