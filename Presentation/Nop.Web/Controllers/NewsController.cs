﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.News;
using Nop.Core.Domain.Security;
using Nop.Services.Events;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Services.News;
using Nop.Services.Security;
using Nop.Services.Seo;
using Nop.Web.Factories;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc;
using Nop.Web.Framework.Mvc.Filters;
using Nop.Web.Framework.Mvc.Rss;
using Nop.Web.Framework.Security;
using Nop.Web.Framework.Security.Captcha;
using Nop.Web.Models.News;

namespace Nop.Web.Controllers
{
    [HttpsRequirement(SslRequirement.No)]
    public partial class NewsController : BasePublicController
    {
        #region Fields

        private readonly CaptchaSettings _captchaSettings;
        private readonly ICustomerActivityService _customerActivityService;
        private readonly IEventPublisher _eventPublisher;
        private readonly ILocalizationService _localizationService;
        private readonly INewsModelFactory _newsModelFactory;
        private readonly INewsService _newsService;
        private readonly IPermissionService _permissionService;
        private readonly IStoreContext _storeContext;
        private readonly IUrlRecordService _urlRecordService;
        private readonly IWebHelper _webHelper;
        private readonly IWorkContext _workContext;
        private readonly IWorkflowMessageService _workflowMessageService;
        private readonly LocalizationSettings _localizationSettings;
        private readonly NewsSettings _newsSettings;

        #endregion

        #region Ctor

        public NewsController(CaptchaSettings captchaSettings,
            ICustomerActivityService customerActivityService,
            IEventPublisher eventPublisher,
            ILocalizationService localizationService,
            INewsModelFactory newsModelFactory,
            INewsService newsService,
            IPermissionService permissionService,
            IStoreContext storeContext,
            IUrlRecordService urlRecordService,
            IWebHelper webHelper,
            IWorkContext workContext,
            IWorkflowMessageService workflowMessageService,
            LocalizationSettings localizationSettings,
            NewsSettings newsSettings)
        {
            _captchaSettings = captchaSettings;
            _customerActivityService = customerActivityService;
            _eventPublisher = eventPublisher;
            _localizationService = localizationService;
            _newsModelFactory = newsModelFactory;
            _newsService = newsService;
            _permissionService = permissionService;
            _storeContext = storeContext;
            _urlRecordService = urlRecordService;
            _webHelper = webHelper;
            _workContext = workContext;
            _workflowMessageService = workflowMessageService;
            _localizationSettings = localizationSettings;
            _newsSettings = newsSettings;
        }

        #endregion

        #region Methods

        public virtual IActionResult List(NewsPagingFilteringModel command)
        {
            if (!_newsSettings.Enabled)
                return RedirectToRoute("HomePage");

            var model = _newsModelFactory.PrepareNewsItemListModel(command);
            return View(model);
        }

        public virtual IActionResult ListRss(int languageId)
        {
            var feed = new RssFeed(
                $"{_localizationService.GetLocalized(_storeContext.CurrentStore, x => x.Name)}: News",
                "News",
                new Uri(_webHelper.GetStoreLocation()),
                DateTime.UtcNow);

            if (!_newsSettings.Enabled)
                return new RssActionResult(feed, _webHelper.GetThisPageUrl(false));

            var items = new List<RssItem>();
            var newsItems = _newsService.GetAllNews(languageId, _storeContext.CurrentStore.Id);
            foreach (var n in newsItems)
            {
                var newsUrl = Url.RouteUrl("NewsItem", new { SeName = _urlRecordService.GetSeName(n, n.LanguageId, ensureTwoPublishedLanguages: false) }, _webHelper.CurrentRequestProtocol);
                items.Add(new RssItem(n.Title, n.Short, new Uri(newsUrl), $"urn:store:{_storeContext.CurrentStore.Id}:news:blog:{n.Id}", n.CreatedOnUtc));
            }
            feed.Items = items;
            return new RssActionResult(feed, _webHelper.GetThisPageUrl(false));
        }

        public virtual IActionResult NewsItem(int newsItemId)
        {
            if (!_newsSettings.Enabled)
                return RedirectToRoute("HomePage");

            var newsItem = _newsService.GetNewsById(newsItemId);
            if (newsItem == null)
                return RedirectToRoute("HomePage");

            var hasAdminAccess = _permissionService.Authorize(StandardPermissionProvider.AccessAdminPanel) && _permissionService.Authorize(StandardPermissionProvider.ManageNews);
            //access to News preview
            if ((!newsItem.Published || !_newsService.IsNewsAvailable(newsItem)) && !hasAdminAccess)
                return RedirectToRoute("HomePage");

            var model = new NewsItemModel();
            model = _newsModelFactory.PrepareNewsItemModel(model, newsItem, true);

            //display "edit" (manage) link
            if (hasAdminAccess)
                DisplayEditLink(Url.Action("NewsItemEdit", "News", new { id = newsItem.Id, area = AreaNames.Admin }));

            return View(model);
        }

        [HttpPost, ActionName("NewsItem")]
        [PublicAntiForgery]
        [FormValueRequired("add-comment")]
        [ValidateCaptcha]
        public virtual IActionResult NewsCommentAdd(int newsItemId, NewsItemModel model, bool captchaValid)
        {
            if (!_newsSettings.Enabled)
                return RedirectToRoute("HomePage");

            var newsItem = _newsService.GetNewsById(newsItemId);
            if (newsItem == null || !newsItem.Published || !newsItem.AllowComments)
                return RedirectToRoute("HomePage");

            //validate CAPTCHA
            if (_captchaSettings.Enabled && _captchaSettings.ShowOnNewsCommentPage && !captchaValid)
            {
                ModelState.AddModelError("", _captchaSettings.GetWrongCaptchaMessage(_localizationService));
            }

            if (_workContext.CurrentCustomer.IsGuest() && !_newsSettings.AllowNotRegisteredUsersToLeaveComments)
            {
                ModelState.AddModelError("", _localizationService.GetResource("News.Comments.OnlyRegisteredUsersLeaveComments"));
            }

            if (ModelState.IsValid)
            {
                var comment = new NewsComment
                {
                    NewsItemId = newsItem.Id,
                    CustomerId = _workContext.CurrentCustomer.Id,
                    CommentTitle = model.AddNewComment.CommentTitle,
                    CommentText = model.AddNewComment.CommentText,
                    IsApproved = !_newsSettings.NewsCommentsMustBeApproved,
                    StoreId = _storeContext.CurrentStore.Id,
                    CreatedOnUtc = DateTime.UtcNow,
                };
                newsItem.NewsComments.Add(comment);
                _newsService.UpdateNews(newsItem);

                //notify a store owner;
                if (_newsSettings.NotifyAboutNewNewsComments)
                    _workflowMessageService.SendNewsCommentNotificationMessage(comment, _localizationSettings.DefaultAdminLanguageId);

                //activity log
                _customerActivityService.InsertActivity("PublicStore.AddNewsComment",
                    _localizationService.GetResource("ActivityLog.PublicStore.AddNewsComment"), comment);

                //raise event
                if (comment.IsApproved)
                    _eventPublisher.Publish(new NewsCommentApprovedEvent(comment));

                //The text boxes should be cleared after a comment has been posted
                //That' why we reload the page
                TempData["nop.news.addcomment.result"] = comment.IsApproved
                    ? _localizationService.GetResource("News.Comments.SuccessfullyAdded")
                    : _localizationService.GetResource("News.Comments.SeeAfterApproving");

                return RedirectToRoute("NewsItem", new { SeName = _urlRecordService.GetSeName(newsItem, newsItem.LanguageId, ensureTwoPublishedLanguages: false) });
            }

            //If we got this far, something failed, redisplay form
            model = _newsModelFactory.PrepareNewsItemModel(model, newsItem, true);
            return View(model);
        }

        #endregion
    }
}