﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Blogs;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Security;
using Nop.Core.Events;
using Nop.Core.Rss;
using Nop.Services.Blogs;
using Nop.Services.Customers;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Services.Seo;
using Nop.Services.Stores;
using Nop.Web.Factories;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc;
using Nop.Web.Framework.Mvc.Filters;
using Nop.Web.Models.Blogs;

namespace Nop.Web.Controllers
{
    [AutoValidateAntiforgeryToken]
    public partial class BlogController : BasePublicController
    {
        #region Fields

        private readonly BlogSettings _blogSettings;
        private readonly CaptchaSettings _captchaSettings;
        private readonly IBlogModelFactory _blogModelFactory;
        private readonly IBlogService _blogService;
        private readonly ICustomerActivityService _customerActivityService;
        private readonly ICustomerService _customerService;
        private readonly IEventPublisher _eventPublisher;
        private readonly ILocalizationService _localizationService;
        private readonly IPermissionService _permissionService;
        private readonly IStoreContext _storeContext;
        private readonly IStoreMappingService _storeMappingService;
        private readonly IUrlRecordService _urlRecordService;
        private readonly IWebHelper _webHelper;
        private readonly IWorkContext _workContext;
        private readonly IWorkflowMessageService _workflowMessageService;
        private readonly LocalizationSettings _localizationSettings;

        #endregion

        #region Ctor

        public BlogController(BlogSettings blogSettings,
            CaptchaSettings captchaSettings,
            IBlogModelFactory blogModelFactory,
            IBlogService blogService,
            ICustomerActivityService customerActivityService,
            ICustomerService customerService,
            IEventPublisher eventPublisher,
            ILocalizationService localizationService,
            IPermissionService permissionService,
            IStoreContext storeContext,
            IStoreMappingService storeMappingService,
            IUrlRecordService urlRecordService,
            IWebHelper webHelper,
            IWorkContext workContext,
            IWorkflowMessageService workflowMessageService,
            LocalizationSettings localizationSettings)
        {
            _blogSettings = blogSettings;
            _captchaSettings = captchaSettings;
            _blogModelFactory = blogModelFactory;
            _blogService = blogService;
            _customerActivityService = customerActivityService;
            _customerService = customerService;
            _eventPublisher = eventPublisher;
            _localizationService = localizationService;
            _permissionService = permissionService;
            _storeContext = storeContext;
            _storeMappingService = storeMappingService;
            _urlRecordService = urlRecordService;
            _webHelper = webHelper;
            _workContext = workContext;
            _workflowMessageService = workflowMessageService;
            _localizationSettings = localizationSettings;
        }

        #endregion

        #region Methods

        public virtual async Task<IActionResult> List(BlogPagingFilteringModel command)
        {
            if (!_blogSettings.Enabled)
                return RedirectToRoute("Homepage");

            var model = await _blogModelFactory.PrepareBlogPostListModelAsync(command);
            return View("List", model);
        }

        public virtual async Task<IActionResult> BlogByTag(BlogPagingFilteringModel command)
        {
            if (!_blogSettings.Enabled)
                return RedirectToRoute("Homepage");

            var model = await _blogModelFactory.PrepareBlogPostListModelAsync(command);
            return View("List", model);
        }

        public virtual async Task<IActionResult> BlogByMonth(BlogPagingFilteringModel command)
        {
            if (!_blogSettings.Enabled)
                return RedirectToRoute("Homepage");

            var model = await _blogModelFactory.PrepareBlogPostListModelAsync(command);
            return View("List", model);
        }

        [CheckLanguageSeoCode(true)]
        public virtual async Task<IActionResult> ListRss(int languageId)
        {
            var feed = new RssFeed(
                $"{await _localizationService.GetLocalizedAsync(await _storeContext.GetCurrentStoreAsync(), x => x.Name)}: Blog",
                "Blog",
                new Uri(_webHelper.GetStoreLocation()),
                DateTime.UtcNow);

            if (!_blogSettings.Enabled)
                return new RssActionResult(feed, _webHelper.GetThisPageUrl(false));

            var items = new List<RssItem>();
            var blogPosts = await _blogService.GetAllBlogPostsAsync((await _storeContext.GetCurrentStoreAsync()).Id, languageId);
            foreach (var blogPost in blogPosts)
            {
                var blogPostUrl = Url.RouteUrl("BlogPost", new { SeName = await _urlRecordService.GetSeNameAsync(blogPost, blogPost.LanguageId, ensureTwoPublishedLanguages: false) }, _webHelper.GetCurrentRequestProtocol());
                items.Add(new RssItem(blogPost.Title, blogPost.Body, new Uri(blogPostUrl),
                    $"urn:store:{(await _storeContext.GetCurrentStoreAsync()).Id}:blog:post:{blogPost.Id}", blogPost.CreatedOnUtc));
            }
            feed.Items = items;
            return new RssActionResult(feed, _webHelper.GetThisPageUrl(false));
        }

        public virtual async Task<IActionResult> BlogPost(int blogPostId)
        {
            if (!_blogSettings.Enabled)
                return RedirectToRoute("Homepage");

            var blogPost = await _blogService.GetBlogPostByIdAsync(blogPostId);
            if (blogPost == null)
                return InvokeHttp404();

            var notAvailable =
                //availability dates
                !_blogService.BlogPostIsAvailable(blogPost) ||
                //Store mapping
                !await _storeMappingService.AuthorizeAsync(blogPost);
            //Check whether the current user has a "Manage blog" permission (usually a store owner)
            //We should allows him (her) to use "Preview" functionality
            var hasAdminAccess = await _permissionService.AuthorizeAsync(StandardPermissionProvider.AccessAdminPanel) && await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageBlog);
            if (notAvailable && !hasAdminAccess)
                return InvokeHttp404();

            //display "edit" (manage) link
            if (hasAdminAccess)
                DisplayEditLink(Url.Action("BlogPostEdit", "Blog", new { id = blogPost.Id, area = AreaNames.Admin }));

            var model = new BlogPostModel();
            await _blogModelFactory.PrepareBlogPostModelAsync(model, blogPost, true);

            return View(model);
        }

        [HttpPost, ActionName("BlogPost")]        
        [FormValueRequired("add-comment")]
        [ValidateCaptcha]
        public virtual async Task<IActionResult> BlogCommentAdd(int blogPostId, BlogPostModel model, bool captchaValid)
        {
            if (!_blogSettings.Enabled)
                return RedirectToRoute("Homepage");

            var blogPost = await _blogService.GetBlogPostByIdAsync(blogPostId);
            if (blogPost == null || !blogPost.AllowComments)
                return RedirectToRoute("Homepage");

            if (await _customerService.IsGuestAsync(await _workContext.GetCurrentCustomerAsync()) && !_blogSettings.AllowNotRegisteredUsersToLeaveComments)
            {
                ModelState.AddModelError("", await _localizationService.GetResourceAsync("Blog.Comments.OnlyRegisteredUsersLeaveComments"));
            }

            //validate CAPTCHA
            if (_captchaSettings.Enabled && _captchaSettings.ShowOnBlogCommentPage && !captchaValid)
            {
                ModelState.AddModelError("", await _localizationService.GetResourceAsync("Common.WrongCaptchaMessage"));
            }

            if (ModelState.IsValid)
            {
                var comment = new BlogComment
                {
                    BlogPostId = blogPost.Id,
                    CustomerId = (await _workContext.GetCurrentCustomerAsync()).Id,
                    CommentText = model.AddNewComment.CommentText,
                    IsApproved = !_blogSettings.BlogCommentsMustBeApproved,
                    StoreId = (await _storeContext.GetCurrentStoreAsync()).Id,
                    CreatedOnUtc = DateTime.UtcNow,
                };

                await _blogService.InsertBlogCommentAsync(comment);

                //notify a store owner
                if (_blogSettings.NotifyAboutNewBlogComments)
                    await _workflowMessageService.SendBlogCommentNotificationMessageAsync(comment, _localizationSettings.DefaultAdminLanguageId);

                //activity log
                await _customerActivityService.InsertActivityAsync("PublicStore.AddBlogComment",
                    await _localizationService.GetResourceAsync("ActivityLog.PublicStore.AddBlogComment"), comment);

                //raise event
                if (comment.IsApproved)
                    await _eventPublisher.PublishAsync(new BlogCommentApprovedEvent(comment));

                //The text boxes should be cleared after a comment has been posted
                //That' why we reload the page
                TempData["nop.blog.addcomment.result"] = comment.IsApproved
                    ? await _localizationService.GetResourceAsync("Blog.Comments.SuccessfullyAdded")
                    : await _localizationService.GetResourceAsync("Blog.Comments.SeeAfterApproving");
                return RedirectToRoute("BlogPost", new { SeName = await _urlRecordService.GetSeNameAsync(blogPost, blogPost.LanguageId, ensureTwoPublishedLanguages: false) });
            }

            //If we got this far, something failed, redisplay form
            await _blogModelFactory.PrepareBlogPostModelAsync(model, blogPost, true);
            
            return View(model);
        }

        #endregion
    }
}