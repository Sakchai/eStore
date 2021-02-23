﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Widgets.GoogleAnalytics.Models;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Widgets.GoogleAnalytics.Controllers
{
    [Area(AreaNames.Admin)]
    [AuthorizeAdmin]
    [AutoValidateAntiforgeryToken]
    public class WidgetsGoogleAnalyticsController : BasePluginController
    {
        #region Fields

        private readonly ILocalizationService _localizationService;
        private readonly INotificationService _notificationService;
        private readonly IPermissionService _permissionService;
        private readonly ISettingService _settingService;
        private readonly IStoreContext _storeContext;

        #endregion

        #region Ctor

        public WidgetsGoogleAnalyticsController(
            ILocalizationService localizationService,
            INotificationService notificationService,
            IPermissionService permissionService,
            ISettingService settingService,
            IStoreContext storeContext)
        {
            _localizationService = localizationService;
            _notificationService = notificationService;
            _permissionService = permissionService;
            _settingService = settingService;
            _storeContext = storeContext;
        }

        #endregion

        #region Methods
        
        public async Task<IActionResult> Configure()
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            //load settings for a chosen store scope
            var storeScope = await _storeContext.GetActiveStoreScopeConfigurationAsync();
            var googleAnalyticsSettings = await _settingService.LoadSettingAsync<GoogleAnalyticsSettings>(storeScope);

            var model = new ConfigurationModel
            {
                GoogleId = googleAnalyticsSettings.GoogleId,
                TrackingScript = googleAnalyticsSettings.TrackingScript,
                EnableEcommerce = googleAnalyticsSettings.EnableEcommerce,
                UseJsToSendEcommerceInfo = googleAnalyticsSettings.UseJsToSendEcommerceInfo,
                IncludingTax = googleAnalyticsSettings.IncludingTax,
                IncludeCustomerId = googleAnalyticsSettings.IncludeCustomerId,
                ActiveStoreScopeConfiguration = storeScope
            };

            if (storeScope > 0)
            {
                model.GoogleId_OverrideForStore = await _settingService.SettingExistsAsync(googleAnalyticsSettings, x => x.GoogleId, storeScope);
                model.TrackingScript_OverrideForStore = await _settingService.SettingExistsAsync(googleAnalyticsSettings, x => x.TrackingScript, storeScope);
                model.EnableEcommerce_OverrideForStore = await _settingService.SettingExistsAsync(googleAnalyticsSettings, x => x.EnableEcommerce, storeScope);
                model.UseJsToSendEcommerceInfo_OverrideForStore = await _settingService.SettingExistsAsync(googleAnalyticsSettings, x => x.UseJsToSendEcommerceInfo, storeScope);
                model.IncludingTax_OverrideForStore = await _settingService.SettingExistsAsync(googleAnalyticsSettings, x => x.IncludingTax, storeScope);
                model.IncludeCustomerId_OverrideForStore = await _settingService.SettingExistsAsync(googleAnalyticsSettings, x => x.IncludeCustomerId, storeScope);
            }

            return View("~/Plugins/Widgets.GoogleAnalytics/Views/Configure.cshtml", model);
        }

        [HttpPost]
        public async Task<IActionResult> Configure(ConfigurationModel model)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            //load settings for a chosen store scope
            var storeScope = await _storeContext.GetActiveStoreScopeConfigurationAsync();
            var googleAnalyticsSettings = await _settingService.LoadSettingAsync<GoogleAnalyticsSettings>(storeScope);

            googleAnalyticsSettings.GoogleId = model.GoogleId;
            googleAnalyticsSettings.TrackingScript = model.TrackingScript;
            googleAnalyticsSettings.EnableEcommerce = model.EnableEcommerce;
            googleAnalyticsSettings.UseJsToSendEcommerceInfo = model.UseJsToSendEcommerceInfo;
            googleAnalyticsSettings.IncludingTax = model.IncludingTax;
            googleAnalyticsSettings.IncludeCustomerId = model.IncludeCustomerId;

            /* We do not clear cache after each setting update.
             * This behavior can increase performance because cached settings will not be cleared 
             * and loaded from database after each update */
            await _settingService.SaveSettingOverridablePerStoreAsync(googleAnalyticsSettings, x => x.GoogleId, model.GoogleId_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(googleAnalyticsSettings, x => x.TrackingScript, model.TrackingScript_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(googleAnalyticsSettings, x => x.EnableEcommerce, model.EnableEcommerce_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(googleAnalyticsSettings, x => x.UseJsToSendEcommerceInfo, model.UseJsToSendEcommerceInfo_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(googleAnalyticsSettings, x => x.IncludingTax, model.IncludingTax_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(googleAnalyticsSettings, x => x.IncludeCustomerId, model.IncludeCustomerId_OverrideForStore, storeScope, false);

            //now clear settings cache
            await _settingService.ClearCacheAsync();

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Plugins.Saved"));

            return await Configure();
        }

        #endregion
    }
}