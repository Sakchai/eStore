using QNet.Core.Caching;
using QNet.Core.Domain.Customers;
using QNet.Services.Events;

namespace QNet.Services.Customers.Cache
{
    /// <summary>
    /// Customer cache event consumer (used for caching of current customer password)
    /// </summary>
    public partial class CustomerCacheEventConsumer : IConsumer<CustomerPasswordChangedEvent>
    {
        #region Fields

        private readonly IStaticCacheManager _cacheManager;

        #endregion

        #region Ctor

        public CustomerCacheEventConsumer(IStaticCacheManager cacheManager)
        {
            _cacheManager = cacheManager;
        }

        #endregion

        #region Methods

        //password changed
        public void HandleEvent(CustomerPasswordChangedEvent eventMessage)
        {
            _cacheManager.Remove(string.Format(QNetCustomerServiceDefaults.CustomerPasswordLifetimeCacheKey, eventMessage.Password.CustomerId));
        }

        #endregion
    }
}