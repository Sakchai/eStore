﻿using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Services.ExportImport;
using Nop.Services.Helpers;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Areas.Admin.Factories;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Messages;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Controllers
{
    public partial class NewsLetterSubscriptionController : BaseAdminController
    {
        #region Fields

        private readonly IDateTimeHelper _dateTimeHelper;
        private readonly IExportManager _exportManager;
        private readonly IImportManager _importManager;
        private readonly ILocalizationService _localizationService;
        private readonly INewsletterSubscriptionModelFactory _newsletterSubscriptionModelFactory;
        private readonly INewsLetterSubscriptionService _newsLetterSubscriptionService;
        private readonly INotificationService _notificationService;
        private readonly IPermissionService _permissionService;

        #endregion

        #region Ctor

        public NewsLetterSubscriptionController(IDateTimeHelper dateTimeHelper,
            IExportManager exportManager,
            IImportManager importManager,
            ILocalizationService localizationService,
            INewsletterSubscriptionModelFactory newsletterSubscriptionModelFactory,
            INewsLetterSubscriptionService newsLetterSubscriptionService,
            INotificationService notificationService,
            IPermissionService permissionService)
        {
            _dateTimeHelper = dateTimeHelper;
            _exportManager = exportManager;
            _importManager = importManager;
            _localizationService = localizationService;
            _newsletterSubscriptionModelFactory = newsletterSubscriptionModelFactory;
            _newsLetterSubscriptionService = newsLetterSubscriptionService;
            _notificationService = notificationService;
            _permissionService = permissionService;
        }

        #endregion

        #region Methods

        public virtual IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public virtual async Task<IActionResult> List()
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageNewsletterSubscribers))
                return AccessDeniedView();

            //prepare model
            var model = await _newsletterSubscriptionModelFactory.PrepareNewsletterSubscriptionSearchModelAsync(new NewsletterSubscriptionSearchModel());

            return View(model);
        }

        [HttpPost]
        public virtual async Task<IActionResult> SubscriptionList(NewsletterSubscriptionSearchModel searchModel)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageNewsletterSubscribers))
                return await AccessDeniedDataTablesJson();

            //prepare model
            var model = await _newsletterSubscriptionModelFactory.PrepareNewsletterSubscriptionListModelAsync(searchModel);

            return Json(model);
        }

        [HttpPost]
        public virtual async Task<IActionResult> SubscriptionUpdate(NewsletterSubscriptionModel model)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageNewsletterSubscribers))
                return AccessDeniedView();

            if (!ModelState.IsValid)
                return ErrorJson(ModelState.SerializeErrors());

            var subscription = await _newsLetterSubscriptionService.GetNewsLetterSubscriptionByIdAsync(model.Id);

            //fill entity from model
            subscription = model.ToEntity(subscription);
            await _newsLetterSubscriptionService.UpdateNewsLetterSubscriptionAsync(subscription);

            return new NullJsonResult();
        }

        [HttpPost]
        public virtual async Task<IActionResult> SubscriptionDelete(int id)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageNewsletterSubscribers))
                return AccessDeniedView();

            var subscription = await _newsLetterSubscriptionService.GetNewsLetterSubscriptionByIdAsync(id)
                ?? throw new ArgumentException("No subscription found with the specified id", nameof(id));

            await _newsLetterSubscriptionService.DeleteNewsLetterSubscriptionAsync(subscription);

            return new NullJsonResult();
        }

        [HttpPost, ActionName("ExportCSV")]
        [FormValueRequired("exportcsv")]
        public virtual async Task<IActionResult> ExportCsv(NewsletterSubscriptionSearchModel model)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageNewsletterSubscribers))
                return AccessDeniedView();

            bool? isActive = null;
            if (model.ActiveId == 1)
                isActive = true;
            else if (model.ActiveId == 2)
                isActive = false;

            var startDateValue = model.StartDate == null ? null
                : (DateTime?)_dateTimeHelper.ConvertToUtcTime(model.StartDate.Value, await _dateTimeHelper.GetCurrentTimeZoneAsync());
            var endDateValue = model.EndDate == null ? null
                : (DateTime?)_dateTimeHelper.ConvertToUtcTime(model.EndDate.Value, await _dateTimeHelper.GetCurrentTimeZoneAsync()).AddDays(1);

            var subscriptions = await _newsLetterSubscriptionService.GetAllNewsLetterSubscriptionsAsync(model.SearchEmail,
                startDateValue, endDateValue, model.StoreId, isActive, model.CustomerRoleId);

            var result = await _exportManager.ExportNewsletterSubscribersToTxtAsync(subscriptions);

            var fileName = $"newsletter_emails_{DateTime.Now:yyyy-MM-dd-HH-mm-ss}_{CommonHelper.GenerateRandomDigitCode(4)}.csv";

            return File(Encoding.UTF8.GetBytes(result), MimeTypes.TextCsv, fileName);
        }

        [HttpPost]
        public virtual async Task<IActionResult> ImportCsv(IFormFile importcsvfile)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageNewsletterSubscribers))
                return AccessDeniedView();

            try
            {
                if (importcsvfile != null && importcsvfile.Length > 0)
                {
                    var count = await _importManager.ImportNewsletterSubscribersFromTxtAsync(importcsvfile.OpenReadStream());

                    _notificationService.SuccessNotification(string.Format(await _localizationService.GetResourceAsync("Admin.Promotions.NewsLetterSubscriptions.ImportEmailsSuccess"), count));

                    return RedirectToAction("List");
                }

                _notificationService.ErrorNotification(await _localizationService.GetResourceAsync("Admin.Common.UploadFile"));
                return RedirectToAction("List");
            }
            catch (Exception exc)
            {
                await _notificationService.ErrorNotificationAsync(exc);
                return RedirectToAction("List");
            }
        }

        #endregion
    }
}