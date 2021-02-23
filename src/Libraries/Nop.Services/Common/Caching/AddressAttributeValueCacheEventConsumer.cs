﻿using System.Threading.Tasks;
using Nop.Core.Domain.Common;
using Nop.Services.Caching;

namespace Nop.Services.Common.Caching
{
    /// <summary>
    /// Represents a address attribute value cache event consumer
    /// </summary>
    public partial class AddressAttributeValueCacheEventConsumer : CacheEventConsumer<AddressAttributeValue>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override async Task ClearCacheAsync(AddressAttributeValue entity)
        {
            await RemoveAsync(NopCommonDefaults.AddressAttributeValuesByAttributeCacheKey, entity.AddressAttributeId);
        }
    }
}
