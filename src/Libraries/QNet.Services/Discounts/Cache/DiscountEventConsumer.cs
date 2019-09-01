using QNet.Core.Caching;
using QNet.Core.Domain.Catalog;
using QNet.Core.Domain.Configuration;
using QNet.Core.Domain.Discounts;
using QNet.Core.Events;
using QNet.Services.Events;

namespace QNet.Services.Discounts.Cache
{
    /// <summary>
    /// Cache event consumer (used for caching of discounts)
    /// </summary>
    public partial class DiscountEventConsumer :
        //discounts
        IConsumer<EntityInsertedEvent<Discount>>,
        IConsumer<EntityUpdatedEvent<Discount>>,
        IConsumer<EntityDeletedEvent<Discount>>,
        //discount requirements
        IConsumer<EntityInsertedEvent<DiscountRequirement>>,
        IConsumer<EntityUpdatedEvent<DiscountRequirement>>,
        IConsumer<EntityDeletedEvent<DiscountRequirement>>,
        //settings
        IConsumer<EntityUpdatedEvent<Setting>>,
        //categories
        IConsumer<EntityInsertedEvent<Category>>,
        IConsumer<EntityUpdatedEvent<Category>>,
        IConsumer<EntityDeletedEvent<Category>>,
        //manufacturers
        IConsumer<EntityInsertedEvent<Manufacturer>>,
        IConsumer<EntityUpdatedEvent<Manufacturer>>,
        IConsumer<EntityDeletedEvent<Manufacturer>>
    {
        #region Fields

        private readonly IStaticCacheManager _cacheManager;

        #endregion

        #region Ctor

        public DiscountEventConsumer(IStaticCacheManager cacheManager)
        {
            _cacheManager = cacheManager;
        }

        #endregion

        #region Methods

        #region Discounts

        public void HandleEvent(EntityInsertedEvent<Discount> eventMessage)
        {
            _cacheManager.RemoveByPrefix(QNetDiscountDefaults.DiscountAllPrefixCacheKey);
            _cacheManager.RemoveByPrefix(QNetDiscountDefaults.DiscountRequirementPrefixCacheKey);
            _cacheManager.RemoveByPrefix(QNetDiscountDefaults.DiscountCategoryIdsPrefixCacheKey);
            _cacheManager.RemoveByPrefix(QNetDiscountDefaults.DiscountManufacturerIdsPrefixCacheKey);
        }

        public void HandleEvent(EntityUpdatedEvent<Discount> eventMessage)
        {
            _cacheManager.RemoveByPrefix(QNetDiscountDefaults.DiscountAllPrefixCacheKey);
            _cacheManager.RemoveByPrefix(QNetDiscountDefaults.DiscountRequirementPrefixCacheKey);
            _cacheManager.RemoveByPrefix(QNetDiscountDefaults.DiscountCategoryIdsPrefixCacheKey);
            _cacheManager.RemoveByPrefix(QNetDiscountDefaults.DiscountManufacturerIdsPrefixCacheKey);
        }

        public void HandleEvent(EntityDeletedEvent<Discount> eventMessage)
        {
            _cacheManager.RemoveByPrefix(QNetDiscountDefaults.DiscountAllPrefixCacheKey);
            _cacheManager.RemoveByPrefix(QNetDiscountDefaults.DiscountRequirementPrefixCacheKey);
            _cacheManager.RemoveByPrefix(QNetDiscountDefaults.DiscountCategoryIdsPrefixCacheKey);
            _cacheManager.RemoveByPrefix(QNetDiscountDefaults.DiscountManufacturerIdsPrefixCacheKey);
        }

        #endregion

        #region Discount requirements

        public void HandleEvent(EntityInsertedEvent<DiscountRequirement> eventMessage)
        {
            _cacheManager.RemoveByPrefix(QNetDiscountDefaults.DiscountRequirementPrefixCacheKey);
        }

        public void HandleEvent(EntityUpdatedEvent<DiscountRequirement> eventMessage)
        {
            _cacheManager.RemoveByPrefix(QNetDiscountDefaults.DiscountRequirementPrefixCacheKey);
        }

        public void HandleEvent(EntityDeletedEvent<DiscountRequirement> eventMessage)
        {
            _cacheManager.RemoveByPrefix(QNetDiscountDefaults.DiscountRequirementPrefixCacheKey);
        }

        #endregion

        #region Settings

        public void HandleEvent(EntityUpdatedEvent<Setting> eventMessage)
        {
            _cacheManager.RemoveByPrefix(QNetDiscountDefaults.DiscountCategoryIdsPrefixCacheKey);
            _cacheManager.RemoveByPrefix(QNetDiscountDefaults.DiscountManufacturerIdsPrefixCacheKey);
        }

        #endregion

        #region Categories

        public void HandleEvent(EntityInsertedEvent<Category> eventMessage)
        {
            _cacheManager.RemoveByPrefix(QNetDiscountDefaults.DiscountCategoryIdsPrefixCacheKey);
        }

        public void HandleEvent(EntityUpdatedEvent<Category> eventMessage)
        {
            _cacheManager.RemoveByPrefix(QNetDiscountDefaults.DiscountCategoryIdsPrefixCacheKey);
        }

        public void HandleEvent(EntityDeletedEvent<Category> eventMessage)
        {
            _cacheManager.RemoveByPrefix(QNetDiscountDefaults.DiscountCategoryIdsPrefixCacheKey);
        }

        #endregion

        #region Manufacturers

        public void HandleEvent(EntityInsertedEvent<Manufacturer> eventMessage)
        {
            _cacheManager.RemoveByPrefix(QNetDiscountDefaults.DiscountManufacturerIdsPrefixCacheKey);
        }

        public void HandleEvent(EntityUpdatedEvent<Manufacturer> eventMessage)
        {
            _cacheManager.RemoveByPrefix(QNetDiscountDefaults.DiscountManufacturerIdsPrefixCacheKey);
        }

        public void HandleEvent(EntityDeletedEvent<Manufacturer> eventMessage)
        {
            _cacheManager.RemoveByPrefix(QNetDiscountDefaults.DiscountManufacturerIdsPrefixCacheKey);
        }

        #endregion

        #endregion
    }
}