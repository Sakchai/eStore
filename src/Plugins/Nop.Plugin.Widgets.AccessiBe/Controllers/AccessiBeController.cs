﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Widgets.AccessiBe.Models;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Services.Stores;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Widgets.AccessiBe.Controllers
{
    [Area(AreaNames.Admin)]
    [AuthorizeAdmin]
    [AutoValidateAntiforgeryToken]
    public class AccessiBeController : BasePluginController
    {
        #region Fields

        private readonly ILocalizationService _localizationService;
        private readonly INotificationService _notificationService;
        private readonly IPermissionService _permissionService;
        private readonly ISettingService _settingService;
        private readonly IStoreContext _storeContext;
        private readonly IStoreService _storeService;
        private readonly IWebHelper _webHelper;

        #endregion

        #region Ctor

        public AccessiBeController(ILocalizationService localizationService,
            INotificationService notificationService,
            IPermissionService permissionService,
            ISettingService settingService,
            IStoreContext storeContext,
            IStoreService storeService,
            IWebHelper webHelper)
        {
            _localizationService = localizationService;
            _notificationService = notificationService;
            _permissionService = permissionService;
            _settingService = settingService;
            _storeContext = storeContext;
            _storeService = storeService;
            _webHelper = webHelper;
        }

        #endregion

        #region Methods

        public async Task<IActionResult> Configure()
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            var storeId = await _storeContext.GetActiveStoreScopeConfigurationAsync();
            var settings = await _settingService.LoadSettingAsync<AccessiBeSettings>(storeId);
            var model = new ConfigurationModel
            {
                Script = settings.Script,
                ActiveStoreScopeConfiguration = storeId
            };
            if (storeId > 0)
            {
                model.Script_OverrideForStore = await _settingService.SettingExistsAsync(settings, setting => setting.Script, storeId);
            }

            //prepare store URL
            model.Url = storeId > 0
                ? (await _storeService.GetStoreByIdAsync(storeId))?.Url
                : _webHelper.GetStoreLocation();

            return View("~/Plugins/Widgets.AccessiBe/Views/Configure.cshtml", model);
        }

        [HttpPost]
        public async Task<IActionResult> Configure(ConfigurationModel model)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            if (!ModelState.IsValid)
                return await Configure();

            var storeId = await _storeContext.GetActiveStoreScopeConfigurationAsync();
            var settings = await _settingService.LoadSettingAsync<AccessiBeSettings>(storeId);
            settings.Script = model.Script;
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, setting => setting.Script, model.Script_OverrideForStore, storeId, false);
            await _settingService.ClearCacheAsync();

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Plugins.Saved"));

            return await Configure();
        }

        #endregion
    }
}