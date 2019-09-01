using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using QNet.Core.Domain.Polls;
using QNet.Services.Localization;
using QNet.Services.Messages;
using QNet.Services.Polls;
using QNet.Services.Security;
using QNet.Services.Stores;
using QNet.Web.Areas.Admin.Factories;
using QNet.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using QNet.Web.Areas.Admin.Models.Polls;
using QNet.Web.Framework.Mvc;
using QNet.Web.Framework.Mvc.Filters;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Validators;

namespace QNet.Web.Areas.Admin.Controllers
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

        protected virtual void SaveStoreMappings(Poll poll, PollModel model)
        {
            poll.LimitedToStores = model.SelectedStoreIds.Any();

            //manage store mappings
            var existingStoreMappings = _storeMappingService.GetStoreMappings(poll);
            foreach (var store in _storeService.GetAllStores())
            {
                var existingStoreMapping = existingStoreMappings.FirstOrDefault(storeMapping => storeMapping.StoreId == store.Id);

                //new store mapping
                if (model.SelectedStoreIds.Contains(store.Id))
                {
                    if (existingStoreMapping == null)
                        _storeMappingService.InsertStoreMapping(poll, store.Id);
                }
                //or remove existing one
                else if (existingStoreMapping != null)
                    _storeMappingService.DeleteStoreMapping(existingStoreMapping);
            }
        }

        #endregion

        #region Polls

        public virtual IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public virtual IActionResult List()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManagePolls))
                return AccessDeniedView();

            //prepare model
            var model = _pollModelFactory.PreparePollSearchModel(new PollSearchModel());

            return View(model);
        }

        [HttpPost]
        public virtual IActionResult List(PollSearchModel searchModel)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManagePolls))
                return AccessDeniedDataTablesJson();

            //prepare model
            var model = _pollModelFactory.PreparePollListModel(searchModel);

            return Json(model);
        }

        public virtual IActionResult Create()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManagePolls))
                return AccessDeniedView();

            //prepare model
            var model = _pollModelFactory.PreparePollModel(new PollModel(), null);

            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public virtual IActionResult Create(PollModel model, bool continueEditing)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManagePolls))
                return AccessDeniedView();

            if (ModelState.IsValid)
            {
                var poll = model.ToEntity<Poll>();
                _pollService.InsertPoll(poll);

                //save store mappings
                SaveStoreMappings(poll, model);

                _notificationService.SuccessNotification(_localizationService.GetResource("Admin.ContentManagement.Polls.Added"));

                if (!continueEditing)
                    return RedirectToAction("List");

                return RedirectToAction("Edit", new { id = poll.Id });
            }

            //prepare model
            model = _pollModelFactory.PreparePollModel(model, null, true);

            //if we got this far, something failed, redisplay form
            return View(model);
        }

        public virtual IActionResult Edit(int id)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManagePolls))
                return AccessDeniedView();

            //try to get a poll with the specified id
            var poll = _pollService.GetPollById(id);
            if (poll == null)
                return RedirectToAction("List");

            //prepare model
            var model = _pollModelFactory.PreparePollModel(null, poll);

            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public virtual IActionResult Edit(PollModel model, bool continueEditing)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManagePolls))
                return AccessDeniedView();

            //try to get a poll with the specified id
            var poll = _pollService.GetPollById(model.Id);
            if (poll == null)
                return RedirectToAction("List");

            if (ModelState.IsValid)
            {
                poll = model.ToEntity(poll);
                _pollService.UpdatePoll(poll);

                //save store mappings
                SaveStoreMappings(poll, model);

                _notificationService.SuccessNotification(_localizationService.GetResource("Admin.ContentManagement.Polls.Updated"));

                if (!continueEditing)
                    return RedirectToAction("List");

                return RedirectToAction("Edit", new { id = poll.Id });
            }

            //prepare model
            model = _pollModelFactory.PreparePollModel(model, poll, true);

            //if we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost]
        public virtual IActionResult Delete(int id)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManagePolls))
                return AccessDeniedView();

            //try to get a poll with the specified id
            var poll = _pollService.GetPollById(id);
            if (poll == null)
                return RedirectToAction("List");

            _pollService.DeletePoll(poll);

            _notificationService.SuccessNotification(_localizationService.GetResource("Admin.ContentManagement.Polls.Deleted"));

            return RedirectToAction("List");
        }

        #endregion

        #region Poll answer

        [HttpPost]
        public virtual IActionResult PollAnswers(PollAnswerSearchModel searchModel)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManagePolls))
                return AccessDeniedDataTablesJson();

            //try to get a poll with the specified id
            var poll = _pollService.GetPollById(searchModel.PollId)
                ?? throw new ArgumentException("No poll found with the specified id");

            //prepare model
            var model = _pollModelFactory.PreparePollAnswerListModel(searchModel, poll);

            return Json(model);
        }

        //ValidateAttribute is used to force model validation
        [HttpPost]
        public virtual IActionResult PollAnswerUpdate([Validate] PollAnswerModel model)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManagePolls))
                return AccessDeniedView();

            if (!ModelState.IsValid)
                return ErrorJson(ModelState.SerializeErrors());

            //try to get a poll answer with the specified id
            var pollAnswer = _pollService.GetPollAnswerById(model.Id)
                ?? throw new ArgumentException("No poll answer found with the specified id");

            pollAnswer = model.ToEntity(pollAnswer);
            _pollService.UpdatePoll(pollAnswer.Poll);

            return new NullJsonResult();
        }

        //ValidateAttribute is used to force model validation
        [HttpPost]
        public virtual IActionResult PollAnswerAdd(int pollId, [Validate] PollAnswerModel model)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManagePolls))
                return AccessDeniedView();

            if (!ModelState.IsValid)
                return ErrorJson(ModelState.SerializeErrors());

            //try to get a poll with the specified id
            var poll = _pollService.GetPollById(pollId)
                ?? throw new ArgumentException("No poll found with the specified id", nameof(pollId));

            //fill entity from model
            poll.PollAnswers.Add(model.ToEntity<PollAnswer>());
            _pollService.UpdatePoll(poll);

            return Json(new { Result = true });
        }

        [HttpPost]
        public virtual IActionResult PollAnswerDelete(int id)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManagePolls))
                return AccessDeniedView();

            //try to get a poll answer with the specified id
            var pollAnswer = _pollService.GetPollAnswerById(id)
                ?? throw new ArgumentException("No poll answer found with the specified id", nameof(id));

            _pollService.DeletePollAnswer(pollAnswer);

            return new NullJsonResult();
        }

        #endregion
    }
}