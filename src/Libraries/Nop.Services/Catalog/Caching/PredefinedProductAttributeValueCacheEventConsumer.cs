﻿using System.Threading.Tasks;
using Nop.Core.Domain.Catalog;
using Nop.Services.Caching;

namespace Nop.Services.Catalog.Caching
{
    /// <summary>
    /// Represents a predefined product attribute value cache event consumer
    /// </summary>
    public partial class PredefinedProductAttributeValueCacheEventConsumer : CacheEventConsumer<PredefinedProductAttributeValue>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override async Task ClearCacheAsync(PredefinedProductAttributeValue entity)
        {
            await RemoveAsync(NopCatalogDefaults.PredefinedProductAttributeValuesByAttributeCacheKey, entity.ProductAttributeId);
        }
    }
}
