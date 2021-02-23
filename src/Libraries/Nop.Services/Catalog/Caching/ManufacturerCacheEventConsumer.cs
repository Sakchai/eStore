﻿using System.Threading.Tasks;
using Nop.Core.Domain.Catalog;
using Nop.Services.Caching;
using Nop.Services.Discounts;

namespace Nop.Services.Catalog.Caching
{
    /// <summary>
    /// Represents a manufacturer cache event consumer
    /// </summary>
    public partial class ManufacturerCacheEventConsumer : CacheEventConsumer<Manufacturer>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <param name="entityEventType">Entity event type</param>
        protected override async Task ClearCacheAsync(Manufacturer entity, EntityEventType entityEventType)
        {
            await RemoveByPrefixAsync(NopDiscountDefaults.ManufacturerIdsPrefix);

            if (entityEventType != EntityEventType.Insert)
                await RemoveByPrefixAsync(NopCatalogDefaults.ManufacturersByCategoryPrefix);

            if (entityEventType == EntityEventType.Delete)
                await RemoveAsync(NopCatalogDefaults.SpecificationAttributeOptionsByManufacturerCacheKey, entity);

            await base.ClearCacheAsync(entity, entityEventType);
        }
    }
}
