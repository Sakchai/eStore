﻿using System.Threading.Tasks;
using Nop.Core.Domain.Customers;
using Nop.Services.Caching;

namespace Nop.Services.Customers.Caching
{
    /// <summary>
    /// Represents a customer attribute value cache event consumer
    /// </summary>
    public partial class CustomerAttributeValueCacheEventConsumer : CacheEventConsumer<CustomerAttributeValue>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override async Task ClearCacheAsync(CustomerAttributeValue entity)
        {
            await RemoveAsync(NopCustomerServicesDefaults.CustomerAttributeValuesByAttributeCacheKey, entity.CustomerAttributeId);
        }
    }
}