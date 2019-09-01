using Microsoft.AspNetCore.Mvc;
using QNet.Core.Domain.Customers;
using QNet.Services.Authentication.External;
using QNet.Services.Configuration;
using QNet.Services.Events;
using QNet.Services.Plugins;
using QNet.Services.Security;
using QNet.Web.Areas.Admin.Factories;
using QNet.Web.Areas.Admin.Models.ExternalAuthentication;
using QNet.Web.Framework.Mvc;

namespace QNet.Web.Areas.Admin.Controllers
{
    public partial class ExternalAuthenticationController : BaseAdminController
    {
        #region Fields

        private readonly ExternalAuthenticationSettings _externalAuthenticationSettings;
        private readonly IAuthenticationPluginManager _authenticationPluginManager;
        private readonly IEventPublisher _eventPublisher;
        private readonly IExternalAuthenticationMethodModelFactory _externalAuthenticationMethodModelFactory;
        private readonly IPermissionService _permissionService;
        private readonly ISettingService _settingService;

        #endregion

        #region Ctor

        public ExternalAuthenticationController(ExternalAuthenticationSettings externalAuthenticationSettings,
            IAuthenticationPluginManager authenticationPluginManager,
            IEventPublisher eventPublisher,
            IExternalAuthenticationMethodModelFactory externalAuthenticationMethodModelFactory,
            IPermissionService permissionService,
            ISettingService settingService)
        {
            _externalAuthenticationSettings = externalAuthenticationSettings;
            _authenticationPluginManager = authenticationPluginManager;
            _eventPublisher = eventPublisher;
            _externalAuthenticationMethodModelFactory = externalAuthenticationMethodModelFactory;
            _permissionService = permissionService;
            _settingService = settingService;
        }

        #endregion

        #region Methods

        public virtual IActionResult Methods()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageExternalAuthenticationMethods))
                return AccessDeniedView();

            //prepare model
            var model = _externalAuthenticationMethodModelFactory
                .PrepareExternalAuthenticationMethodSearchModel(new ExternalAuthenticationMethodSearchModel());

            return View(model);
        }

        [HttpPost]
        public virtual IActionResult Methods(ExternalAuthenticationMethodSearchModel searchModel)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageExternalAuthenticationMethods))
                return AccessDeniedDataTablesJson();

            //prepare model
            var model = _externalAuthenticationMethodModelFactory.PrepareExternalAuthenticationMethodListModel(searchModel);

            return Json(model);
        }

        [HttpPost]
        public virtual IActionResult MethodUpdate(ExternalAuthenticationMethodModel model)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageExternalAuthenticationMethods))
                return AccessDeniedView();

            var method = _authenticationPluginManager.LoadPluginBySystemName(model.SystemName);
            if (_authenticationPluginManager.IsPluginActive(method))
            {
                if (!model.IsActive)
                {
                    //mark as disabled
                    _externalAuthenticationSettings.ActiveAuthenticationMethodSystemNames.Remove(method.PluginDescriptor.SystemName);
                    _settingService.SaveSetting(_externalAuthenticationSettings);
                }
            }
            else
            {
                if (model.IsActive)
                {
                    //mark as active
                    _externalAuthenticationSettings.ActiveAuthenticationMethodSystemNames.Add(method.PluginDescriptor.SystemName);
                    _settingService.SaveSetting(_externalAuthenticationSettings);
                }
            }

            var pluginDescriptor = method.PluginDescriptor;
            pluginDescriptor.DisplayOrder = model.DisplayOrder;

            //update the description file
            pluginDescriptor.Save();

            //raise event
            _eventPublisher.Publish(new PluginUpdatedEvent(pluginDescriptor));

            return new NullJsonResult();
        }

        #endregion
    }
}