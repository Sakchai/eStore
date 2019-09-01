using QNet.Core.Caching;
using QNet.Core.Domain.Catalog;
using QNet.Core.Domain.Configuration;
using QNet.Core.Domain.Vendors;
using QNet.Core.Events;
using QNet.Services.Events;
using QNet.Services.Plugins;

namespace QNet.Web.Areas.Admin.Infrastructure.Cache
{
    /// <summary>
    /// Model cache event consumer (used for caching of presentation layer models)
    /// </summary>
    public partial class ModelCacheEventConsumer :
        //settings
        IConsumer<EntityUpdatedEvent<Setting>>,
        //specification attributes
        IConsumer<EntityInsertedEvent<SpecificationAttribute>>,
        IConsumer<EntityUpdatedEvent<SpecificationAttribute>>,
        IConsumer<EntityDeletedEvent<SpecificationAttribute>>,
        //categories
        IConsumer<EntityInsertedEvent<Category>>,
        IConsumer<EntityUpdatedEvent<Category>>,
        IConsumer<EntityDeletedEvent<Category>>,
        //manufacturers
        IConsumer<EntityInsertedEvent<Manufacturer>>,
        IConsumer<EntityUpdatedEvent<Manufacturer>>,
        IConsumer<EntityDeletedEvent<Manufacturer>>,
        //vendors
        IConsumer<EntityInsertedEvent<Vendor>>,
        IConsumer<EntityUpdatedEvent<Vendor>>,
        IConsumer<EntityDeletedEvent<Vendor>>,

        IConsumer<PluginUpdatedEvent>
    {
        #region Fields

        private readonly IStaticCacheManager _cacheManager;

        #endregion

        #region Ctor

        public ModelCacheEventConsumer(IStaticCacheManager cacheManager)
        {
            _cacheManager = cacheManager;
        }

        #endregion

        #region Methods

        public void HandleEvent(EntityUpdatedEvent<Setting> eventMessage)
        {
            //clear models which depend on settings
            _cacheManager.RemoveByPrefix(QNetModelCacheDefaults.OfficialNewsPrefixCacheKey); //depends on AdminAreaSettings.HideAdvertisementsOnAdminArea
        }

        //specification attributes
        public void HandleEvent(EntityInsertedEvent<SpecificationAttribute> eventMessage)
        {
            _cacheManager.RemoveByPrefix(QNetModelCacheDefaults.SpecAttributesPrefixCacheKey);
        }
        public void HandleEvent(EntityUpdatedEvent<SpecificationAttribute> eventMessage)
        {
            _cacheManager.RemoveByPrefix(QNetModelCacheDefaults.SpecAttributesPrefixCacheKey);
        }
        public void HandleEvent(EntityDeletedEvent<SpecificationAttribute> eventMessage)
        {
            _cacheManager.RemoveByPrefix(QNetModelCacheDefaults.SpecAttributesPrefixCacheKey);
        }

        //categories
        public void HandleEvent(EntityInsertedEvent<Category> eventMessage)
        {
            _cacheManager.RemoveByPrefix(QNetModelCacheDefaults.CategoriesListPrefixCacheKey);
        }
        public void HandleEvent(EntityUpdatedEvent<Category> eventMessage)
        {
            _cacheManager.RemoveByPrefix(QNetModelCacheDefaults.CategoriesListPrefixCacheKey);
        }
        public void HandleEvent(EntityDeletedEvent<Category> eventMessage)
        {
            _cacheManager.RemoveByPrefix(QNetModelCacheDefaults.CategoriesListPrefixCacheKey);
        }

        //manufacturers
        public void HandleEvent(EntityInsertedEvent<Manufacturer> eventMessage)
        {
            _cacheManager.RemoveByPrefix(QNetModelCacheDefaults.ManufacturersListPrefixCacheKey);
        }
        public void HandleEvent(EntityUpdatedEvent<Manufacturer> eventMessage)
        {
            _cacheManager.RemoveByPrefix(QNetModelCacheDefaults.ManufacturersListPrefixCacheKey);
        }
        public void HandleEvent(EntityDeletedEvent<Manufacturer> eventMessage)
        {
            _cacheManager.RemoveByPrefix(QNetModelCacheDefaults.ManufacturersListPrefixCacheKey);
        }

        //vendors
        public void HandleEvent(EntityInsertedEvent<Vendor> eventMessage)
        {
            _cacheManager.RemoveByPrefix(QNetModelCacheDefaults.VendorsListPrefixCacheKey);
        }
        public void HandleEvent(EntityUpdatedEvent<Vendor> eventMessage)
        {
            _cacheManager.RemoveByPrefix(QNetModelCacheDefaults.VendorsListPrefixCacheKey);
        }
        public void HandleEvent(EntityDeletedEvent<Vendor> eventMessage)
        {
            _cacheManager.RemoveByPrefix(QNetModelCacheDefaults.VendorsListPrefixCacheKey);
        }

        /// <summary>
        /// Handle plugin updated event
        /// </summary>
        /// <param name="eventMessage">Event</param>
        public void HandleEvent(PluginUpdatedEvent eventMessage)
        {
            _cacheManager.RemoveByPrefix(QNetPluginDefaults.AdminNavigationPluginsPrefixCacheKey);
        }

        #endregion
    }
}