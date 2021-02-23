﻿using System.Threading.Tasks;
using Nop.Core.Domain.Catalog;
using Nop.Services.Caching;

namespace Nop.Services.Catalog.Caching
{
    /// <summary>
    /// Represents a product attribute combination cache event consumer
    /// </summary>
    public partial class ProductAttributeCombinationCacheEventConsumer : CacheEventConsumer<ProductAttributeCombination>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override async Task ClearCacheAsync(ProductAttributeCombination entity)
        {
            await RemoveAsync(NopCatalogDefaults.ProductAttributeMappingsByProductCacheKey, entity.ProductId);
            await RemoveAsync(NopCatalogDefaults.ProductAttributeCombinationsByProductCacheKey, entity.ProductId);
        }
    }
}
