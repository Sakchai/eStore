using QNet.Core.Caching;
using QNet.Core.Domain.Common;
using QNet.Core.Events;
using QNet.Services.Events;

namespace QNet.Services.Tax.Cache
{
    /// <summary>
    /// Tax cache event consumer (used for caching of tax)
    /// </summary>
    public partial class TaxCacheEventConsumer :
        //address
        IConsumer<EntityUpdatedEvent<Address>>
    {
        #region Fields

        private readonly IStaticCacheManager _cacheManager;

        #endregion

        #region Ctor

        public TaxCacheEventConsumer(IStaticCacheManager cacheManager)
        {
            _cacheManager = cacheManager;
        }

        #endregion

        #region Methods

        public void HandleEvent(EntityUpdatedEvent<Address> eventMessage)
        {
            _cacheManager.RemoveByPrefix(string.Format(QNetTaxDefaults.TaxAddressPrefixCacheKey, eventMessage.Entity.Id));
        }

        #endregion
    }
}