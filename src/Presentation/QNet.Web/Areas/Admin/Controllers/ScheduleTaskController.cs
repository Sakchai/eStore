using System;
using Microsoft.AspNetCore.Mvc;
using QNet.Services.Localization;
using QNet.Services.Logging;
using QNet.Services.Messages;
using QNet.Services.Security;
using QNet.Services.Tasks;
using QNet.Web.Areas.Admin.Factories;
using QNet.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using QNet.Web.Areas.Admin.Models.Tasks;
using QNet.Web.Framework.Mvc;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Controllers
{
    public partial class ScheduleTaskController : BaseAdminController
    {
        #region Fields

        private readonly ICustomerActivityService _customerActivityService;
        private readonly ILocalizationService _localizationService;
        private readonly INotificationService _notificationService;
        private readonly IPermissionService _permissionService;
        private readonly IScheduleTaskModelFactory _scheduleTaskModelFactory;
        private readonly IScheduleTaskService _scheduleTaskService;

        #endregion

        #region Ctor

        public ScheduleTaskController(ICustomerActivityService customerActivityService,
            ILocalizationService localizationService,
            INotificationService notificationService,
            IPermissionService permissionService,
            IScheduleTaskModelFactory scheduleTaskModelFactory,
            IScheduleTaskService scheduleTaskService)
        {
            _customerActivityService = customerActivityService;
            _localizationService = localizationService;
            _notificationService = notificationService;
            _permissionService = permissionService;
            _scheduleTaskModelFactory = scheduleTaskModelFactory;
            _scheduleTaskService = scheduleTaskService;
        }

        #endregion

        #region Methods

        public virtual IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public virtual IActionResult List()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageScheduleTasks))
                return AccessDeniedView();

            //prepare model
            var model = _scheduleTaskModelFactory.PrepareScheduleTaskSearchModel(new ScheduleTaskSearchModel());

            return View(model);
        }

        [HttpPost]
        public virtual IActionResult List(ScheduleTaskSearchModel searchModel)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageScheduleTasks))
                return AccessDeniedDataTablesJson();

            //prepare model
            var model = _scheduleTaskModelFactory.PrepareScheduleTaskListModel(searchModel);

            return Json(model);
        }

        [HttpPost]
        public virtual IActionResult TaskUpdate(ScheduleTaskModel model)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageScheduleTasks))
                return AccessDeniedView();

            if (!ModelState.IsValid)
                return ErrorJson(ModelState.SerializeErrors());

            //try to get a schedule task with the specified id
            var scheduleTask = _scheduleTaskService.GetTaskById(model.Id)
                               ?? throw new ArgumentException("Schedule task cannot be loaded");

            scheduleTask = model.ToEntity(scheduleTask);

            _scheduleTaskService.UpdateTask(scheduleTask);

            //activity log
            _customerActivityService.InsertActivity("EditTask",
                string.Format(_localizationService.GetResource("ActivityLog.EditTask"), scheduleTask.Id), scheduleTask);

            return new NullJsonResult();
        }

        public virtual IActionResult RunNow(int id)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageScheduleTasks))
                return AccessDeniedView();

            try
            {
                //try to get a schedule task with the specified id
                var scheduleTask = _scheduleTaskService.GetTaskById(id)
                                   ?? throw new ArgumentException("Schedule task cannot be loaded", nameof(id));

                //ensure that the task is enabled
                var task = new Task(scheduleTask) { Enabled = true };
                task.Execute(true, false);

                _notificationService.SuccessNotification(_localizationService.GetResource("Admin.System.ScheduleTasks.RunNow.Done"));
            }
            catch (Exception exc)
            {
                _notificationService.ErrorNotification(exc);
            }

            return RedirectToAction("List");
        }

        #endregion
    }
}