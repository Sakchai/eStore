﻿using System.Threading.Tasks;
using Nop.Core.Domain.Customers;
using Nop.Services.Caching;

namespace Nop.Services.Customers.Caching
{
    /// <summary>
    /// Represents a customer attribute cache event consumer
    /// </summary>
    public partial class CustomerAttributeCacheEventConsumer : CacheEventConsumer<CustomerAttribute>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override async Task ClearCacheAsync(CustomerAttribute entity)
        {
            await RemoveAsync(NopCustomerServicesDefaults.CustomerAttributeValuesByAttributeCacheKey, entity);
        }
    }
}
