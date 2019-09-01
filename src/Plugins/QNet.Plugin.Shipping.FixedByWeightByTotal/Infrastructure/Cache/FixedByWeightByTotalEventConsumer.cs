using QNet.Core.Domain.Shipping;
using QNet.Core.Events;
using QNet.Services.Configuration;
using QNet.Services.Events;

namespace QNet.Plugin.Shipping.FixedByWeightByTotal.Infrastructure.Cache
{
    /// <summary>
    /// Event consumer of the "Fixed or by weight" shipping plugin (used for removing unused settings)
    /// </summary>
    public partial class FixedByWeightByTotalEventConsumer : IConsumer<EntityDeletedEvent<ShippingMethod>>
    {
        #region Fields
        
        private readonly ISettingService _settingService;

        #endregion

        #region Ctor

        public FixedByWeightByTotalEventConsumer(ISettingService settingService)
        {
            _settingService = settingService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Handle shipping method deleted event
        /// </summary>
        /// <param name="eventMessage">Event message</param>
        public void HandleEvent(EntityDeletedEvent<ShippingMethod> eventMessage)
        {
            var shippingMethod = eventMessage?.Entity;
            if (shippingMethod == null)
                return;

            //delete saved fixed rate if exists
            var setting = _settingService.GetSetting(string.Format(FixedByWeightByTotalDefaults.FixedRateSettingsKey, shippingMethod.Id));
            if (setting != null)
                _settingService.DeleteSetting(setting);
        }

        #endregion
    }
}