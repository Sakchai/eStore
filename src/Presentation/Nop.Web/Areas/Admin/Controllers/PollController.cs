﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core.Domain.Polls;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Services.Polls;
using Nop.Services.Security;
using Nop.Services.Stores;
using Nop.Web.Areas.Admin.Factories;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Polls;
using Nop.Web.Framework.Mvc;
using Nop.Web.Framework.Mvc.Filters;
using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Web.Framework.Validators;

namespace Nop.Web.Areas.Admin.Controllers
{
    public partial class PollController : BaseAdminController
    {
        #region Fields

        private readonly ILocalizationService _localizationService;
        private readonly INotificationService _notificationService;
        private readonly IPermissionService _permissionService;
        private readonly IPollModelFactory _pollModelFactory;
        private readonly IPollService _pollService;
        private readonly IStoreMappingService _storeMappingService;
        private readonly IStoreService _storeService;

        #endregion

        #region Ctor

        public PollController(ILocalizationService localizationService,
            INotificationService notificationService,
            IPermissionService permissionService,
            IPollModelFactory pollModelFactory,
            IPollService pollService,
            IStoreMappingService storeMappingService,
            IStoreService storeService)
        {
            _localizationService = localizationService;
            _notificationService = notificationService;
            _permissionService = permissionService;
            _pollModelFactory = pollModelFactory;
            _pollService = pollService;
            _storeMappingService = storeMappingService;
            _storeService = storeService;
        }

        #endregion

        #region Utilities

        protected virtual async Task SaveStoreMappingsAsync(Poll poll, PollModel model)
        {
            poll.LimitedToStores = model.SelectedStoreIds.Any();
            await _pollService.UpdatePollAsync(poll);

            //manage store mappings
            var existingStoreMappings = await _storeMappingService.GetStoreMappingsAsync(poll);
            foreach (var store in await _storeService.GetAllStoresAsync())
            {
                var existingStoreMapping = existingStoreMappings.FirstOrDefault(storeMapping => storeMapping.StoreId == store.Id);

                //new store mapping
                if (model.SelectedStoreIds.Contains(store.Id))
                {
                    if (existingStoreMapping == null)
                        await _storeMappingService.InsertStoreMappingAsync(poll, store.Id);
                }
                //or remove existing one
                else if (existingStoreMapping != null)
                    await _storeMappingService.DeleteStoreMappingAsync(existingStoreMapping);
            }
        }

        #endregion

        #region Polls

        public virtual IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public virtual async Task<IActionResult> List()
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManagePolls))
                return AccessDeniedView();

            //prepare model
            var model = await _pollModelFactory.PreparePollSearchModelAsync(new PollSearchModel());

            return View(model);
        }

        [HttpPost]
        public virtual async Task<IActionResult> List(PollSearchModel searchModel)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManagePolls))
                return await AccessDeniedDataTablesJson();

            //prepare model
            var model = await _pollModelFactory.PreparePollListModelAsync(searchModel);

            return Json(model);
        }

        public virtual async Task<IActionResult> Create()
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManagePolls))
                return AccessDeniedView();

            //prepare model
            var model = await _pollModelFactory.PreparePollModelAsync(new PollModel(), null);

            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public virtual async Task<IActionResult> Create(PollModel model, bool continueEditing)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManagePolls))
                return AccessDeniedView();

            if (ModelState.IsValid)
            {
                var poll = model.ToEntity<Poll>();
                await _pollService.InsertPollAsync(poll);

                //save store mappings
                await SaveStoreMappingsAsync(poll, model);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.ContentManagement.Polls.Added"));

                if (!continueEditing)
                    return RedirectToAction("List");

                return RedirectToAction("Edit", new { id = poll.Id });
            }

            //prepare model
            model = await _pollModelFactory.PreparePollModelAsync(model, null, true);

            //if we got this far, something failed, redisplay form
            return View(model);
        }

        public virtual async Task<IActionResult> Edit(int id)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManagePolls))
                return AccessDeniedView();

            //try to get a poll with the specified id
            var poll = await _pollService.GetPollByIdAsync(id);
            if (poll == null)
                return RedirectToAction("List");

            //prepare model
            var model = await _pollModelFactory.PreparePollModelAsync(null, poll);

            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public virtual async Task<IActionResult> Edit(PollModel model, bool continueEditing)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManagePolls))
                return AccessDeniedView();

            //try to get a poll with the specified id
            var poll = await _pollService.GetPollByIdAsync(model.Id);
            if (poll == null)
                return RedirectToAction("List");

            if (ModelState.IsValid)
            {
                poll = model.ToEntity(poll);
                await _pollService.UpdatePollAsync(poll);

                //save store mappings
                await SaveStoreMappingsAsync(poll, model);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.ContentManagement.Polls.Updated"));

                if (!continueEditing)
                    return RedirectToAction("List");

                return RedirectToAction("Edit", new { id = poll.Id });
            }

            //prepare model
            model = await _pollModelFactory.PreparePollModelAsync(model, poll, true);

            //if we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Delete(int id)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManagePolls))
                return AccessDeniedView();

            //try to get a poll with the specified id
            var poll = await _pollService.GetPollByIdAsync(id);
            if (poll == null)
                return RedirectToAction("List");

            await _pollService.DeletePollAsync(poll);

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.ContentManagement.Polls.Deleted"));

            return RedirectToAction("List");
        }

        #endregion

        #region Poll answer

        [HttpPost]
        public virtual async Task<IActionResult> PollAnswers(PollAnswerSearchModel searchModel)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManagePolls))
                return await AccessDeniedDataTablesJson();

            //try to get a poll with the specified id
            var poll = await _pollService.GetPollByIdAsync(searchModel.PollId)
                ?? throw new ArgumentException("No poll found with the specified id");

            //prepare model
            var model = await _pollModelFactory.PreparePollAnswerListModelAsync(searchModel, poll);

            return Json(model);
        }

        //ValidateAttribute is used to force model validation
        [HttpPost]
        public virtual async Task<IActionResult> PollAnswerUpdate([Validate] PollAnswerModel model)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManagePolls))
                return AccessDeniedView();

            if (!ModelState.IsValid)
                return ErrorJson(ModelState.SerializeErrors());

            //try to get a poll answer with the specified id
            var pollAnswer = await _pollService.GetPollAnswerByIdAsync(model.Id)
                ?? throw new ArgumentException("No poll answer found with the specified id");

            pollAnswer = model.ToEntity(pollAnswer);

            await _pollService.UpdatePollAnswerAsync(pollAnswer);

            return new NullJsonResult();
        }

        //ValidateAttribute is used to force model validation
        [HttpPost]
        public virtual async Task<IActionResult> PollAnswerAdd(int pollId, [Validate] PollAnswerModel model)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManagePolls))
                return AccessDeniedView();

            if (!ModelState.IsValid)
                return ErrorJson(ModelState.SerializeErrors());

            //fill entity from model
            await _pollService.InsertPollAnswerAsync(model.ToEntity<PollAnswer>());

            return Json(new { Result = true });
        }

        [HttpPost]
        public virtual async Task<IActionResult> PollAnswerDelete(int id)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManagePolls))
                return AccessDeniedView();

            //try to get a poll answer with the specified id
            var pollAnswer = await _pollService.GetPollAnswerByIdAsync(id)
                ?? throw new ArgumentException("No poll answer found with the specified id", nameof(id));

            await _pollService.DeletePollAnswerAsync(pollAnswer);

            return new NullJsonResult();
        }

        #endregion
    }
}