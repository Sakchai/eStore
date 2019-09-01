using Microsoft.AspNetCore.Mvc;
using QNet.Core.Domain.Cms;
using QNet.Services.Cms;
using QNet.Services.Configuration;
using QNet.Services.Events;
using QNet.Services.Plugins;
using QNet.Services.Security;
using QNet.Web.Areas.Admin.Factories;
using QNet.Web.Areas.Admin.Models.Cms;
using QNet.Web.Framework.Mvc;

namespace QNet.Web.Areas.Admin.Controllers
{
    public partial class WidgetController : BaseAdminController
    {
        #region Fields

        private readonly IEventPublisher _eventPublisher;
        private readonly IPermissionService _permissionService;
        private readonly ISettingService _settingService;
        private readonly IWidgetModelFactory _widgetModelFactory;
        private readonly IWidgetPluginManager _widgetPluginManager;
        private readonly WidgetSettings _widgetSettings;

        #endregion

        #region Ctor

        public WidgetController(IEventPublisher eventPublisher,
            IPermissionService permissionService,
            ISettingService settingService,
            IWidgetModelFactory widgetModelFactory,
            IWidgetPluginManager widgetPluginManager,
            WidgetSettings widgetSettings)
        {
            _eventPublisher = eventPublisher;
            _permissionService = permissionService;
            _settingService = settingService;
            _widgetModelFactory = widgetModelFactory;
            _widgetPluginManager = widgetPluginManager;
            _widgetSettings = widgetSettings;
        }

        #endregion

        #region Methods

        public virtual IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public virtual IActionResult List()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            //prepare model
            var model = _widgetModelFactory.PrepareWidgetSearchModel(new WidgetSearchModel());

            return View(model);
        }

        [HttpPost]
        public virtual IActionResult List(WidgetSearchModel searchModel)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedDataTablesJson();

            //prepare model
            var model = _widgetModelFactory.PrepareWidgetListModel(searchModel);

            return Json(model);
        }

        [HttpPost]
        public virtual IActionResult WidgetUpdate(WidgetModel model)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            var widget = _widgetPluginManager.LoadPluginBySystemName(model.SystemName);
            if (_widgetPluginManager.IsPluginActive(widget, _widgetSettings.ActiveWidgetSystemNames))
            {
                if (!model.IsActive)
                {
                    //mark as disabled
                    _widgetSettings.ActiveWidgetSystemNames.Remove(widget.PluginDescriptor.SystemName);
                    _settingService.SaveSetting(_widgetSettings);
                }
            }
            else
            {
                if (model.IsActive)
                {
                    //mark as active
                    _widgetSettings.ActiveWidgetSystemNames.Add(widget.PluginDescriptor.SystemName);
                    _settingService.SaveSetting(_widgetSettings);
                }
            }

            var pluginDescriptor = widget.PluginDescriptor;

            //display order
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