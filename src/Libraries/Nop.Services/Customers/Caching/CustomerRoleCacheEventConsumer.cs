﻿using System.Threading.Tasks;
using Nop.Core.Domain.Customers;
using Nop.Services.Caching;

namespace Nop.Services.Customers.Caching
{
    /// <summary>
    /// Represents a customer role cache event consumer
    /// </summary>
    public partial class CustomerRoleCacheEventConsumer : CacheEventConsumer<CustomerRole>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override async Task ClearCacheAsync(CustomerRole entity)
        {
            await RemoveByPrefixAsync(NopCustomerServicesDefaults.CustomerRolesBySystemNamePrefix);
            await RemoveByPrefixAsync(NopCustomerServicesDefaults.CustomerCustomerRolesPrefix);
        }
    }
}
