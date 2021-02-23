﻿using System.Threading.Tasks;
using Nop.Core.Domain.Discounts;
using Nop.Services.Caching;

namespace Nop.Services.Discounts.Caching
{
    /// <summary>
    /// Represents a discount cache event consumer
    /// </summary>
    public partial class DiscountCacheEventConsumer : CacheEventConsumer<Discount>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override async Task ClearCacheAsync(Discount entity)
        {
            await RemoveAsync(NopDiscountDefaults.DiscountRequirementsByDiscountCacheKey, entity);
            await RemoveByPrefixAsync(NopDiscountDefaults.CategoryIdsByDiscountPrefix, entity);
            await RemoveByPrefixAsync(NopDiscountDefaults.ManufacturerIdsByDiscountPrefix, entity);
        }
    }
}
