﻿﻿using System.Threading.Tasks;
﻿using Nop.Core.Caching;
using Nop.Core.Domain.Catalog;
using Nop.Services.Caching;

namespace Nop.Services.Catalog.Caching
{
    /// <summary>
    /// Represents a product tag cache event consumer
    /// </summary>
    public partial class ProductTagCacheEventConsumer : CacheEventConsumer<ProductTag>
    {
        /// <summary>
        /// Clear cache by entity event type
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <param name="entityEventType">Entity event type</param>
        protected override async Task ClearCacheAsync(ProductTag entity, EntityEventType entityEventType)
        {
            await RemoveByPrefixAsync(NopEntityCacheDefaults<ProductTag>.Prefix);
        }
    }
}
