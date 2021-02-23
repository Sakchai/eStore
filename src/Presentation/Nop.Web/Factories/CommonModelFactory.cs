﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Domain;
using Nop.Core.Domain.Blogs;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Forums;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Media;
using Nop.Core.Domain.News;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Security;
using Nop.Core.Domain.Vendors;
using Nop.Core.Infrastructure;
using Nop.Services.Blogs;
using Nop.Services.Catalog;
using Nop.Services.Common;
using Nop.Services.Customers;
using Nop.Services.Directory;
using Nop.Services.Forums;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Services.News;
using Nop.Services.Orders;
using Nop.Services.Security;
using Nop.Services.Seo;
using Nop.Services.Themes;
using Nop.Services.Topics;
using Nop.Web.Framework.Themes;
using Nop.Web.Framework.UI;
using Nop.Web.Infrastructure.Cache;
using Nop.Web.Models.Common;

namespace Nop.Web.Factories
{
    /// <summary>
    /// Represents the common models factory
    /// </summary>
    public partial class CommonModelFactory : ICommonModelFactory
    {
        #region Fields

        private readonly BlogSettings _blogSettings;
        private readonly CaptchaSettings _captchaSettings;
        private readonly CatalogSettings _catalogSettings;
        private readonly CommonSettings _commonSettings;
        private readonly CustomerSettings _customerSettings;
        private readonly DisplayDefaultFooterItemSettings _displayDefaultFooterItemSettings;
        private readonly ForumSettings _forumSettings;
        private readonly IActionContextAccessor _actionContextAccessor;
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;
        private readonly ICurrencyService _currencyService;
        private readonly ICustomerService _customerService;
        private readonly IForumService _forumService;
        private readonly IGenericAttributeService _genericAttributeService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILanguageService _languageService;
        private readonly ILocalizationService _localizationService;
        private readonly IManufacturerService _manufacturerService;
        private readonly INewsService _newsService;
        private readonly INopFileProvider _fileProvider;
        private readonly IPageHeadBuilder _pageHeadBuilder;
        private readonly IPermissionService _permissionService;
        private readonly IPictureService _pictureService;
        private readonly IProductService _productService;
        private readonly IProductTagService _productTagService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly ISitemapGenerator _sitemapGenerator;
        private readonly IStaticCacheManager _staticCacheManager;
        private readonly IStoreContext _storeContext;
        private readonly IThemeContext _themeContext;
        private readonly IThemeProvider _themeProvider;
        private readonly ITopicService _topicService;
        private readonly IUrlHelperFactory _urlHelperFactory;
        private readonly IUrlRecordService _urlRecordService;
        private readonly IWebHelper _webHelper;
        private readonly IWorkContext _workContext;
        private readonly LocalizationSettings _localizationSettings;
        private readonly MediaSettings _mediaSettings;
        private readonly NewsSettings _newsSettings;
        private readonly SitemapSettings _sitemapSettings;
        private readonly SitemapXmlSettings _sitemapXmlSettings;
        private readonly StoreInformationSettings _storeInformationSettings;
        private readonly VendorSettings _vendorSettings;

        #endregion

        #region Ctor

        public CommonModelFactory(BlogSettings blogSettings,
            CaptchaSettings captchaSettings,
            CatalogSettings catalogSettings,
            CommonSettings commonSettings,
            CustomerSettings customerSettings,
            DisplayDefaultFooterItemSettings displayDefaultFooterItemSettings,
            ForumSettings forumSettings,
            IActionContextAccessor actionContextAccessor,
            IBlogService blogService,
            ICategoryService categoryService,
            ICurrencyService currencyService,
            ICustomerService customerService,
            IForumService forumService,
            IGenericAttributeService genericAttributeService,
            IHttpContextAccessor httpContextAccessor,
            ILanguageService languageService,
            ILocalizationService localizationService,
            IManufacturerService manufacturerService,
            INewsService newsService,
            INopFileProvider fileProvider,
            IPageHeadBuilder pageHeadBuilder,
            IPermissionService permissionService,
            IPictureService pictureService,
            IProductService productService,
            IProductTagService productTagService,
            IShoppingCartService shoppingCartService,
            ISitemapGenerator sitemapGenerator,
            IStaticCacheManager staticCacheManager,
            IStoreContext storeContext,
            IThemeContext themeContext,
            IThemeProvider themeProvider,
            ITopicService topicService,
            IUrlHelperFactory urlHelperFactory,
            IUrlRecordService urlRecordService,
            IWebHelper webHelper,
            IWorkContext workContext,
            LocalizationSettings localizationSettings,
            MediaSettings mediaSettings,
            NewsSettings newsSettings,
            SitemapSettings sitemapSettings,
            SitemapXmlSettings sitemapXmlSettings,
            StoreInformationSettings storeInformationSettings,
            VendorSettings vendorSettings)
        {
            _blogSettings = blogSettings;
            _captchaSettings = captchaSettings;
            _catalogSettings = catalogSettings;
            _commonSettings = commonSettings;
            _customerSettings = customerSettings;
            _displayDefaultFooterItemSettings = displayDefaultFooterItemSettings;
            _forumSettings = forumSettings;
            _actionContextAccessor = actionContextAccessor;
            _blogService = blogService;
            _categoryService = categoryService;
            _currencyService = currencyService;
            _customerService = customerService;
            _forumService = forumService;
            _genericAttributeService = genericAttributeService;
            _httpContextAccessor = httpContextAccessor;
            _languageService = languageService;
            _localizationService = localizationService;
            _manufacturerService = manufacturerService;
            _newsService = newsService;
            _fileProvider = fileProvider;
            _pageHeadBuilder = pageHeadBuilder;
            _permissionService = permissionService;
            _pictureService = pictureService;
            _productService = productService;
            _productTagService = productTagService;
            _shoppingCartService = shoppingCartService;
            _sitemapGenerator = sitemapGenerator;
            _staticCacheManager = staticCacheManager;
            _storeContext = storeContext;
            _themeContext = themeContext;
            _themeProvider = themeProvider;
            _topicService = topicService;
            _urlHelperFactory = urlHelperFactory;
            _urlRecordService = urlRecordService;
            _webHelper = webHelper;
            _workContext = workContext;
            _mediaSettings = mediaSettings;
            _localizationSettings = localizationSettings;
            _newsSettings = newsSettings;
            _sitemapSettings = sitemapSettings;
            _sitemapXmlSettings = sitemapXmlSettings;
            _storeInformationSettings = storeInformationSettings;
            _vendorSettings = vendorSettings;
        }

        #endregion

        #region Utilities

        /// <summary>
        /// Get the number of unread private messages
        /// </summary>
        /// <returns>Number of private messages</returns>
        protected virtual async Task<int> GetUnreadPrivateMessagesAsync()
        {
            var result = 0;
            var customer = await _workContext.GetCurrentCustomerAsync();
            if (_forumSettings.AllowPrivateMessages && !await _customerService.IsGuestAsync(customer))
            {
                var privateMessages = await _forumService.GetAllPrivateMessagesAsync((await _storeContext.GetCurrentStoreAsync()).Id,
                    0, customer.Id, false, null, false, string.Empty, 0, 1);

                if (privateMessages.TotalCount > 0)
                {
                    result = privateMessages.TotalCount;
                }
            }

            return result;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Prepare the logo model
        /// </summary>
        /// <returns>Logo model</returns>
        public virtual async Task<LogoModel> PrepareLogoModelAsync()
        {
            var model = new LogoModel
            {
                StoreName = await _localizationService.GetLocalizedAsync(await _storeContext.GetCurrentStoreAsync(), x => x.Name)
            };

            var cacheKey = _staticCacheManager.PrepareKeyForDefaultCache(NopModelCacheDefaults.StoreLogoPath
                , await _storeContext.GetCurrentStoreAsync(), await _themeContext.GetWorkingThemeNameAsync(), _webHelper.IsCurrentConnectionSecured());
            model.LogoPath = await _staticCacheManager.GetAsync(cacheKey, async () =>
            {
                var logo = string.Empty;
                var logoPictureId = _storeInformationSettings.LogoPictureId;

                if (logoPictureId > 0)
                    logo = await _pictureService.GetPictureUrlAsync(logoPictureId, showDefaultPicture: false);

                if (string.IsNullOrEmpty(logo))
                {
                    //use default logo
                    var pathBase = _httpContextAccessor.HttpContext.Request.PathBase.Value ?? string.Empty;
                    var storeLocation = _mediaSettings.UseAbsoluteImagePath ? _webHelper.GetStoreLocation() : $"{pathBase}/";
                    logo = $"{storeLocation}Themes/{await _themeContext.GetWorkingThemeNameAsync()}/Content/images/logo.png";
                }

                return logo;
            });

            return model;
        }

        /// <summary>
        /// Prepare the language selector model
        /// </summary>
        /// <returns>Language selector model</returns>
        public virtual async Task<LanguageSelectorModel> PrepareLanguageSelectorModelAsync()
        {
            var availableLanguages = (await _languageService
                    .GetAllLanguagesAsync(storeId: (await _storeContext.GetCurrentStoreAsync()).Id))
                    .Select(x => new LanguageModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        FlagImageFileName = x.FlagImageFileName,
                    }).ToList();

            var model = new LanguageSelectorModel
            {
                CurrentLanguageId = (await _workContext.GetWorkingLanguageAsync()).Id,
                AvailableLanguages = availableLanguages,
                UseImages = _localizationSettings.UseImagesForLanguageSelection
            };

            return model;
        }

        /// <summary>
        /// Prepare the currency selector model
        /// </summary>
        /// <returns>Currency selector model</returns>
        public virtual async Task<CurrencySelectorModel> PrepareCurrencySelectorModelAsync()
        {
            var availableCurrencies = await (await _currencyService
                .GetAllCurrenciesAsync(storeId: (await _storeContext.GetCurrentStoreAsync()).Id))
                .SelectAwait(async x =>
                {
                    //currency char
                    var currencySymbol = !string.IsNullOrEmpty(x.DisplayLocale)
                        ? new RegionInfo(x.DisplayLocale).CurrencySymbol
                        : x.CurrencyCode;

                    //model
                    var currencyModel = new CurrencyModel
                    {
                        Id = x.Id,
                        Name = await _localizationService.GetLocalizedAsync(x, y => y.Name),
                        CurrencySymbol = currencySymbol
                    };

                    return currencyModel;
                }).ToListAsync();

            var model = new CurrencySelectorModel
            {
                CurrentCurrencyId = (await _workContext.GetWorkingCurrencyAsync()).Id,
                AvailableCurrencies = availableCurrencies
            };

            return model;
        }

        /// <summary>
        /// Prepare the tax type selector model
        /// </summary>
        /// <returns>Tax type selector model</returns>
        public virtual async Task<TaxTypeSelectorModel> PrepareTaxTypeSelectorModelAsync()
        {
            var model = new TaxTypeSelectorModel
            {
                CurrentTaxType = await _workContext.GetTaxDisplayTypeAsync()
            };

            return model;
        }

        /// <summary>
        /// Prepare the header links model
        /// </summary>
        /// <returns>Header links model</returns>
        public virtual async Task<HeaderLinksModel> PrepareHeaderLinksModelAsync()
        {
            var customer = await _workContext.GetCurrentCustomerAsync();

            var unreadMessageCount = await GetUnreadPrivateMessagesAsync();
            var unreadMessage = string.Empty;
            var alertMessage = string.Empty;
            if (unreadMessageCount > 0)
            {
                unreadMessage = string.Format(await _localizationService.GetResourceAsync("PrivateMessages.TotalUnread"), unreadMessageCount);

                //notifications here
                if (_forumSettings.ShowAlertForPM &&
                    !await _genericAttributeService.GetAttributeAsync<bool>(customer, NopCustomerDefaults.NotifiedAboutNewPrivateMessagesAttribute, (await _storeContext.GetCurrentStoreAsync()).Id))
                {
                    await _genericAttributeService.SaveAttributeAsync(customer, NopCustomerDefaults.NotifiedAboutNewPrivateMessagesAttribute, true, (await _storeContext.GetCurrentStoreAsync()).Id);
                    alertMessage = string.Format(await _localizationService.GetResourceAsync("PrivateMessages.YouHaveUnreadPM"), unreadMessageCount);
                }
            }

            var model = new HeaderLinksModel
            {
                RegistrationType = _customerSettings.UserRegistrationType,
                IsAuthenticated = await _customerService.IsRegisteredAsync(customer),
                CustomerName = await _customerService.IsRegisteredAsync(customer) ? await _customerService.FormatUsernameAsync(customer) : string.Empty,
                ShoppingCartEnabled = await _permissionService.AuthorizeAsync(StandardPermissionProvider.EnableShoppingCart),
                WishlistEnabled = await _permissionService.AuthorizeAsync(StandardPermissionProvider.EnableWishlist),
                AllowPrivateMessages = await _customerService.IsRegisteredAsync(customer) && _forumSettings.AllowPrivateMessages,
                UnreadPrivateMessages = unreadMessage,
                AlertMessage = alertMessage,
            };
            //performance optimization (use "HasShoppingCartItems" property)
            if (customer.HasShoppingCartItems)
            {
                model.ShoppingCartItems = (await _shoppingCartService.GetShoppingCartAsync(customer, ShoppingCartType.ShoppingCart, (await _storeContext.GetCurrentStoreAsync()).Id))
                    .Sum(item => item.Quantity);

                model.WishlistItems = (await _shoppingCartService.GetShoppingCartAsync(customer, ShoppingCartType.Wishlist, (await _storeContext.GetCurrentStoreAsync()).Id))
                    .Sum(item => item.Quantity);
            }

            return model;
        }

        /// <summary>
        /// Prepare the admin header links model
        /// </summary>
        /// <returns>Admin header links model</returns>
        public virtual async Task<AdminHeaderLinksModel> PrepareAdminHeaderLinksModelAsync()
        {
            var customer = await _workContext.GetCurrentCustomerAsync();

            var model = new AdminHeaderLinksModel
            {
                ImpersonatedCustomerName = await _customerService.IsRegisteredAsync(customer) ? await _customerService.FormatUsernameAsync(customer) : string.Empty,
                IsCustomerImpersonated = _workContext.OriginalCustomerIfImpersonated != null,
                DisplayAdminLink = await _permissionService.AuthorizeAsync(StandardPermissionProvider.AccessAdminPanel),
                EditPageUrl = _pageHeadBuilder.GetEditPageUrl()
            };

            return model;
        }

        /// <summary>
        /// Prepare the social model
        /// </summary>
        /// <returns>Social model</returns>
        public virtual async Task<SocialModel> PrepareSocialModelAsync()
        {
            var model = new SocialModel
            {
                FacebookLink = _storeInformationSettings.FacebookLink,
                TwitterLink = _storeInformationSettings.TwitterLink,
                YoutubeLink = _storeInformationSettings.YoutubeLink,
                WorkingLanguageId = (await _workContext.GetWorkingLanguageAsync()).Id,
                NewsEnabled = _newsSettings.Enabled,
            };

            return model;
        }

        /// <summary>
        /// Prepare the footer model
        /// </summary>
        /// <returns>Footer model</returns>
        public virtual async Task<FooterModel> PrepareFooterModelAsync()
        {
            //footer topics
            var topicModels = await (await _topicService.GetAllTopicsAsync((await _storeContext.GetCurrentStoreAsync()).Id))
                    .Where(t => t.IncludeInFooterColumn1 || t.IncludeInFooterColumn2 || t.IncludeInFooterColumn3)
                    .SelectAwait(async t => new FooterModel.FooterTopicModel
                    {
                        Id = t.Id,
                        Name = await _localizationService.GetLocalizedAsync(t, x => x.Title),
                        SeName = await _urlRecordService.GetSeNameAsync(t),
                        IncludeInFooterColumn1 = t.IncludeInFooterColumn1,
                        IncludeInFooterColumn2 = t.IncludeInFooterColumn2,
                        IncludeInFooterColumn3 = t.IncludeInFooterColumn3
                    }).ToListAsync();

            //model
            var model = new FooterModel
            {
                StoreName = await _localizationService.GetLocalizedAsync(await _storeContext.GetCurrentStoreAsync(), x => x.Name),
                WishlistEnabled = await _permissionService.AuthorizeAsync(StandardPermissionProvider.EnableWishlist),
                ShoppingCartEnabled = await _permissionService.AuthorizeAsync(StandardPermissionProvider.EnableShoppingCart),
                SitemapEnabled = _sitemapSettings.SitemapEnabled,
                WorkingLanguageId = (await _workContext.GetWorkingLanguageAsync()).Id,
                BlogEnabled = _blogSettings.Enabled,
                CompareProductsEnabled = _catalogSettings.CompareProductsEnabled,
                ForumEnabled = _forumSettings.ForumsEnabled,
                NewsEnabled = _newsSettings.Enabled,
                RecentlyViewedProductsEnabled = _catalogSettings.RecentlyViewedProductsEnabled,
                NewProductsEnabled = _catalogSettings.NewProductsEnabled,
                DisplayTaxShippingInfoFooter = _catalogSettings.DisplayTaxShippingInfoFooter,
                HidePoweredByNopCommerce = _storeInformationSettings.HidePoweredByNopCommerce,
                AllowCustomersToApplyForVendorAccount = _vendorSettings.AllowCustomersToApplyForVendorAccount,
                AllowCustomersToCheckGiftCardBalance = _customerSettings.AllowCustomersToCheckGiftCardBalance && _captchaSettings.Enabled,
                Topics = topicModels,
                DisplaySitemapFooterItem = _displayDefaultFooterItemSettings.DisplaySitemapFooterItem,
                DisplayContactUsFooterItem = _displayDefaultFooterItemSettings.DisplayContactUsFooterItem,
                DisplayProductSearchFooterItem = _displayDefaultFooterItemSettings.DisplayProductSearchFooterItem,
                DisplayNewsFooterItem = _displayDefaultFooterItemSettings.DisplayNewsFooterItem,
                DisplayBlogFooterItem = _displayDefaultFooterItemSettings.DisplayBlogFooterItem,
                DisplayForumsFooterItem = _displayDefaultFooterItemSettings.DisplayForumsFooterItem,
                DisplayRecentlyViewedProductsFooterItem = _displayDefaultFooterItemSettings.DisplayRecentlyViewedProductsFooterItem,
                DisplayCompareProductsFooterItem = _displayDefaultFooterItemSettings.DisplayCompareProductsFooterItem,
                DisplayNewProductsFooterItem = _displayDefaultFooterItemSettings.DisplayNewProductsFooterItem,
                DisplayCustomerInfoFooterItem = _displayDefaultFooterItemSettings.DisplayCustomerInfoFooterItem,
                DisplayCustomerOrdersFooterItem = _displayDefaultFooterItemSettings.DisplayCustomerOrdersFooterItem,
                DisplayCustomerAddressesFooterItem = _displayDefaultFooterItemSettings.DisplayCustomerAddressesFooterItem,
                DisplayShoppingCartFooterItem = _displayDefaultFooterItemSettings.DisplayShoppingCartFooterItem,
                DisplayWishlistFooterItem = _displayDefaultFooterItemSettings.DisplayWishlistFooterItem,
                DisplayApplyVendorAccountFooterItem = _displayDefaultFooterItemSettings.DisplayApplyVendorAccountFooterItem
            };

            return model;
        }

        /// <summary>
        /// Prepare the contact us model
        /// </summary>
        /// <param name="model">Contact us model</param>
        /// <param name="excludeProperties">Whether to exclude populating of model properties from the entity</param>
        /// <returns>Contact us model</returns>
        public virtual async Task<ContactUsModel> PrepareContactUsModelAsync(ContactUsModel model, bool excludeProperties)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            if (!excludeProperties)
            {
                model.Email = (await _workContext.GetCurrentCustomerAsync()).Email;
                model.FullName = await _customerService.GetCustomerFullNameAsync(await _workContext.GetCurrentCustomerAsync());
            }

            model.SubjectEnabled = _commonSettings.SubjectFieldOnContactUsForm;
            model.DisplayCaptcha = _captchaSettings.Enabled && _captchaSettings.ShowOnContactUsPage;

            return model;
        }

        /// <summary>
        /// Prepare the contact vendor model
        /// </summary>
        /// <param name="model">Contact vendor model</param>
        /// <param name="vendor">Vendor</param>
        /// <param name="excludeProperties">Whether to exclude populating of model properties from the entity</param>
        /// <returns>Contact vendor model</returns>
        public virtual async Task<ContactVendorModel> PrepareContactVendorModelAsync(ContactVendorModel model, Vendor vendor, bool excludeProperties)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            if (vendor == null)
                throw new ArgumentNullException(nameof(vendor));

            if (!excludeProperties)
            {
                model.Email = (await _workContext.GetCurrentCustomerAsync()).Email;
                model.FullName = await _customerService.GetCustomerFullNameAsync(await _workContext.GetCurrentCustomerAsync());
            }

            model.SubjectEnabled = _commonSettings.SubjectFieldOnContactUsForm;
            model.DisplayCaptcha = _captchaSettings.Enabled && _captchaSettings.ShowOnContactUsPage;
            model.VendorId = vendor.Id;
            model.VendorName = await _localizationService.GetLocalizedAsync(vendor, x => x.Name);

            return model;
        }

        /// <summary>
        /// Prepare the sitemap model
        /// </summary>
        /// <param name="pageModel">Sitemap page model</param>
        /// <returns>Sitemap model</returns>
        public virtual async Task<SitemapModel> PrepareSitemapModelAsync(SitemapPageModel pageModel)
        {
            if (pageModel == null)
                throw new ArgumentNullException(nameof(pageModel));

            var language = await _workContext.GetWorkingLanguageAsync();
            var customer = await _workContext.GetCurrentCustomerAsync();
            var customerRoleIds = await _customerService.GetCustomerRoleIdsAsync(customer);
            var store = await _storeContext.GetCurrentStoreAsync();
            var cacheKey = _staticCacheManager.PrepareKeyForDefaultCache(NopModelCacheDefaults.SitemapPageModelKey,
                language, customerRoleIds, store);

            var cachedModel = await _staticCacheManager.GetAsync(cacheKey, async () =>
            {
                //get URL helper
                var urlHelper = _urlHelperFactory.GetUrlHelper(_actionContextAccessor.ActionContext);

                var model = new SitemapModel();

                //prepare common items
                var commonGroupTitle = await _localizationService.GetResourceAsync("Sitemap.General");

                //home page
                model.Items.Add(new SitemapModel.SitemapItemModel
                {
                    GroupTitle = commonGroupTitle,
                    Name = await _localizationService.GetResourceAsync("Homepage"),
                    Url = urlHelper.RouteUrl("Homepage")
                });

                //search
                model.Items.Add(new SitemapModel.SitemapItemModel
                {
                    GroupTitle = commonGroupTitle,
                    Name = await _localizationService.GetResourceAsync("Search"),
                    Url = urlHelper.RouteUrl("ProductSearch")
                });

                //news
                if (_newsSettings.Enabled)
                {
                    model.Items.Add(new SitemapModel.SitemapItemModel
                    {
                        GroupTitle = commonGroupTitle,
                        Name = await _localizationService.GetResourceAsync("News"),
                        Url = urlHelper.RouteUrl("NewsArchive")
                    });
                }

                //blog
                if (_blogSettings.Enabled)
                {
                    model.Items.Add(new SitemapModel.SitemapItemModel
                    {
                        GroupTitle = commonGroupTitle,
                        Name = await _localizationService.GetResourceAsync("Blog"),
                        Url = urlHelper.RouteUrl("Blog")
                    });
                }

                //forums
                if (_forumSettings.ForumsEnabled)
                {
                    model.Items.Add(new SitemapModel.SitemapItemModel
                    {
                        GroupTitle = commonGroupTitle,
                        Name = await _localizationService.GetResourceAsync("Forum.Forums"),
                        Url = urlHelper.RouteUrl("Boards")
                    });
                }

                //contact us
                model.Items.Add(new SitemapModel.SitemapItemModel
                {
                    GroupTitle = commonGroupTitle,
                    Name = await _localizationService.GetResourceAsync("ContactUs"),
                    Url = urlHelper.RouteUrl("ContactUs")
                });

                //customer info
                model.Items.Add(new SitemapModel.SitemapItemModel
                {
                    GroupTitle = commonGroupTitle,
                    Name = await _localizationService.GetResourceAsync("Account.MyAccount"),
                    Url = urlHelper.RouteUrl("CustomerInfo")
                });

                //at the moment topics are in general category too
                if (_sitemapSettings.SitemapIncludeTopics)
                {
                    var topics = (await _topicService.GetAllTopicsAsync(storeId: store.Id))
                        .Where(topic => topic.IncludeInSitemap);

                    model.Items.AddRange(await topics.SelectAwait(async topic => new SitemapModel.SitemapItemModel
                    {
                        GroupTitle = commonGroupTitle,
                        Name = await _localizationService.GetLocalizedAsync(topic, x => x.Title),
                        Url = urlHelper.RouteUrl("Topic", new { SeName = await _urlRecordService.GetSeNameAsync(topic) })
                    }).ToListAsync());
                }

                //blog posts
                if (_sitemapSettings.SitemapIncludeBlogPosts && _blogSettings.Enabled)
                {
                    var blogPostsGroupTitle = await _localizationService.GetResourceAsync("Sitemap.BlogPosts");
                    var blogPosts = (await _blogService.GetAllBlogPostsAsync(storeId: store.Id))
                        .Where(p => p.IncludeInSitemap);

                    model.Items.AddRange(await blogPosts.SelectAwait(async post => new SitemapModel.SitemapItemModel
                    {
                        GroupTitle = blogPostsGroupTitle,
                        Name = post.Title,
                        Url = urlHelper.RouteUrl("BlogPost",
                            new { SeName = await _urlRecordService.GetSeNameAsync(post, post.LanguageId, ensureTwoPublishedLanguages: false) })
                    }).ToListAsync());
                }

                //news
                if (_sitemapSettings.SitemapIncludeNews && _newsSettings.Enabled)
                {
                    var newsGroupTitle = await _localizationService.GetResourceAsync("Sitemap.News");
                    var news = await _newsService.GetAllNewsAsync(storeId: store.Id);
                    model.Items.AddRange(await news.SelectAwait(async newsItem => new SitemapModel.SitemapItemModel
                    {
                        GroupTitle = newsGroupTitle,
                        Name = newsItem.Title,
                        Url = urlHelper.RouteUrl("NewsItem",
                            new { SeName = await _urlRecordService.GetSeNameAsync(newsItem, newsItem.LanguageId, ensureTwoPublishedLanguages: false) })
                    }).ToListAsync());
                }

                //categories
                if (_sitemapSettings.SitemapIncludeCategories)
                {
                    var categoriesGroupTitle = await _localizationService.GetResourceAsync("Sitemap.Categories");
                    var categories = await _categoryService.GetAllCategoriesAsync(storeId: store.Id);
                    model.Items.AddRange(await categories.SelectAwait(async category => new SitemapModel.SitemapItemModel
                    {
                        GroupTitle = categoriesGroupTitle,
                        Name = await _localizationService.GetLocalizedAsync(category, x => x.Name),
                        Url = urlHelper.RouteUrl("Category", new { SeName = await _urlRecordService.GetSeNameAsync(category) })
                    }).ToListAsync());
                }

                //manufacturers
                if (_sitemapSettings.SitemapIncludeManufacturers)
                {
                    var manufacturersGroupTitle = await _localizationService.GetResourceAsync("Sitemap.Manufacturers");
                    var manufacturers = await _manufacturerService.GetAllManufacturersAsync(storeId: store.Id);
                    model.Items.AddRange(await manufacturers.SelectAwait(async manufacturer => new SitemapModel.SitemapItemModel
                    {
                        GroupTitle = manufacturersGroupTitle,
                        Name = await _localizationService.GetLocalizedAsync(manufacturer, x => x.Name),
                        Url = urlHelper.RouteUrl("Manufacturer", new { SeName = await _urlRecordService.GetSeNameAsync(manufacturer) })
                    }).ToListAsync());
                }

                //products
                if (_sitemapSettings.SitemapIncludeProducts)
                {
                    var productsGroupTitle = await _localizationService.GetResourceAsync("Sitemap.Products");
                    var products = await _productService.SearchProductsAsync(0, storeId: store.Id, visibleIndividuallyOnly: true);
                    model.Items.AddRange(await products.SelectAwait(async product => new SitemapModel.SitemapItemModel
                    {
                        GroupTitle = productsGroupTitle,
                        Name = await _localizationService.GetLocalizedAsync(product, x => x.Name),
                        Url = urlHelper.RouteUrl("Product", new { SeName = await _urlRecordService.GetSeNameAsync(product) })
                    }).ToListAsync());
                }

                //product tags
                if (_sitemapSettings.SitemapIncludeProductTags)
                {
                    var productTagsGroupTitle = await _localizationService.GetResourceAsync("Sitemap.ProductTags");
                    var productTags = await _productTagService.GetAllProductTagsAsync();
                    model.Items.AddRange(await productTags.SelectAwait(async productTag => new SitemapModel.SitemapItemModel
                    {
                        GroupTitle = productTagsGroupTitle,
                        Name = await _localizationService.GetLocalizedAsync(productTag, x => x.Name),
                        Url = urlHelper.RouteUrl("ProductsByTag", new { SeName = await _urlRecordService.GetSeNameAsync(productTag) })
                    }).ToListAsync());
                }

                return model;
            });

            //prepare model with pagination
            pageModel.PageSize = Math.Max(pageModel.PageSize, _sitemapSettings.SitemapPageSize);
            pageModel.PageNumber = Math.Max(pageModel.PageNumber, 1);

            var pagedItems = new PagedList<SitemapModel.SitemapItemModel>(cachedModel.Items, pageModel.PageNumber - 1, pageModel.PageSize);
            var sitemapModel = new SitemapModel { Items = pagedItems };
            sitemapModel.PageModel.LoadPagedList(pagedItems);

            return sitemapModel;
        }

        /// <summary>
        /// Get the sitemap in XML format
        /// </summary>
        /// <param name="id">Sitemap identifier; pass null to load the first sitemap or sitemap index file</param>
        /// <returns>Sitemap as string in XML format</returns>
        public virtual async Task<string> PrepareSitemapXmlAsync(int? id)
        {
            var language = await _workContext.GetWorkingLanguageAsync();
            var customer = await _workContext.GetCurrentCustomerAsync();
            var customerRoleIds = await _customerService.GetCustomerRoleIdsAsync(customer);
            var store = await _storeContext.GetCurrentStoreAsync();
            var cacheKey = _staticCacheManager.PrepareKeyForDefaultCache(NopModelCacheDefaults.SitemapSeoModelKey,
                id, language, customerRoleIds, store);

            var siteMap = await _staticCacheManager.GetAsync(cacheKey, async () => await _sitemapGenerator.GenerateAsync(id));

            return siteMap;
        }

        /// <summary>
        /// Prepare the store theme selector model
        /// </summary>
        /// <returns>Store theme selector model</returns>
        public virtual async Task<StoreThemeSelectorModel> PrepareStoreThemeSelectorModelAsync()
        {
            var model = new StoreThemeSelectorModel();

            var currentTheme = await _themeProvider.GetThemeBySystemNameAsync(await _themeContext.GetWorkingThemeNameAsync());
            model.CurrentStoreTheme = new StoreThemeModel
            {
                Name = currentTheme?.SystemName,
                Title = currentTheme?.FriendlyName
            };

            model.AvailableStoreThemes = (await _themeProvider.GetThemesAsync()).Select(x => new StoreThemeModel
            {
                Name = x.SystemName,
                Title = x.FriendlyName
            }).ToList();

            return model;
        }

        /// <summary>
        /// Prepare the favicon model
        /// </summary>
        /// <returns>Favicon model</returns>
        public virtual Task<FaviconAndAppIconsModel> PrepareFaviconAndAppIconsModelAsync()
        {
            var model = new FaviconAndAppIconsModel
            {
                HeadCode = _commonSettings.FaviconAndAppIconsHeadCode
            };

            return Task.FromResult(model);
        }

        /// <summary>
        /// Get robots.txt file
        /// </summary>
        /// <returns>Robots.txt file as string</returns>
        public virtual async Task<string> PrepareRobotsTextFileAsync()
        {
            var sb = new StringBuilder();

            //if robots.custom.txt exists, let's use it instead of hard-coded data below
            var robotsFilePath = _fileProvider.Combine(_fileProvider.MapPath("~/"), "robots.custom.txt");
            if (_fileProvider.FileExists(robotsFilePath))
            {
                //the robots.txt file exists
                var robotsFileContent = await _fileProvider.ReadAllTextAsync(robotsFilePath, Encoding.UTF8);
                sb.Append(robotsFileContent);
            }
            else
            {
                //doesn't exist. Let's generate it (default behavior)

                var disallowPaths = new List<string>
                {
                    "/admin",
                    "/bin/",
                    "/files/",
                    "/files/exportimport/",
                    "/country/getstatesbycountryid",
                    "/install",
                    "/setproductreviewhelpfulness",
                };
                var localizableDisallowPaths = new List<string>
                {
                    "/addproducttocart/catalog/",
                    "/addproducttocart/details/",
                    "/backinstocksubscriptions/manage",
                    "/boards/forumsubscriptions",
                    "/boards/forumwatch",
                    "/boards/postedit",
                    "/boards/postdelete",
                    "/boards/postcreate",
                    "/boards/topicedit",
                    "/boards/topicdelete",
                    "/boards/topiccreate",
                    "/boards/topicmove",
                    "/boards/topicwatch",
                    "/cart$",
                    "/changecurrency",
                    "/changelanguage",
                    "/changetaxtype",
                    "/checkout",
                    "/checkout/billingaddress",
                    "/checkout/completed",
                    "/checkout/confirm",
                    "/checkout/shippingaddress",
                    "/checkout/shippingmethod",
                    "/checkout/paymentinfo",
                    "/checkout/paymentmethod",
                    "/clearcomparelist",
                    "/compareproducts",
                    "/compareproducts/add/*",
                    "/customer/avatar",
                    "/customer/activation",
                    "/customer/addresses",
                    "/customer/changepassword",
                    "/customer/checkusernameavailability",
                    "/customer/downloadableproducts",
                    "/customer/info",
                    "/customer/productreviews",
                    "/deletepm",
                    "/emailwishlist",
                    "/eucookielawaccept",
                    "/inboxupdate",
                    "/newsletter/subscriptionactivation",
                    "/onepagecheckout",
                    "/order/history",
                    "/orderdetails",
                    "/passwordrecovery/confirm",
                    "/poll/vote",
                    "/privatemessages",
                    "/recentlyviewedproducts",
                    "/returnrequest",
                    "/returnrequest/history",
                    "/rewardpoints/history",
                    "/search?",
                    "/sendpm",
                    "/sentupdate",
                    "/shoppingcart/*",
                    "/storeclosed",
                    "/subscribenewsletter",
                    "/topic/authenticate",
                    "/viewpm",
                    "/uploadfilecheckoutattribute",
                    "/uploadfileproductattribute",
                    "/uploadfilereturnrequest",
                    "/wishlist",
                };

                const string newLine = "\r\n"; //Environment.NewLine
                sb.Append("User-agent: *");
                sb.Append(newLine);
                //sitemaps
                if (_sitemapXmlSettings.SitemapXmlEnabled)
                {
                    if (_localizationSettings.SeoFriendlyUrlsForLanguagesEnabled)
                    {
                        //URLs are localizable. Append SEO code
                        foreach (var language in await _languageService.GetAllLanguagesAsync(storeId: (await _storeContext.GetCurrentStoreAsync()).Id))
                        {
                            sb.AppendFormat("Sitemap: {0}{1}/sitemap.xml", _webHelper.GetStoreLocation(), language.UniqueSeoCode);
                            sb.Append(newLine);
                        }
                    }
                    else
                    {
                        //localizable paths (without SEO code)
                        sb.AppendFormat("Sitemap: {0}sitemap.xml", _webHelper.GetStoreLocation());
                        sb.Append(newLine);
                    }
                }
                //host
                sb.AppendFormat("Host: {0}", _webHelper.GetStoreLocation());
                sb.Append(newLine);

                //usual paths
                foreach (var path in disallowPaths)
                {
                    sb.AppendFormat("Disallow: {0}", path);
                    sb.Append(newLine);
                }
                //localizable paths (without SEO code)
                foreach (var path in localizableDisallowPaths)
                {
                    sb.AppendFormat("Disallow: {0}", path);
                    sb.Append(newLine);
                }

                if (_localizationSettings.SeoFriendlyUrlsForLanguagesEnabled)
                {
                    //URLs are localizable. Append SEO code
                    foreach (var language in await _languageService.GetAllLanguagesAsync(storeId: (await _storeContext.GetCurrentStoreAsync()).Id))
                    {
                        foreach (var path in localizableDisallowPaths)
                        {
                            sb.AppendFormat("Disallow: /{0}{1}", language.UniqueSeoCode, path);
                            sb.Append(newLine);
                        }
                    }
                }

                //load and add robots.txt additions to the end of file.
                var robotsAdditionsFile = _fileProvider.Combine(_fileProvider.MapPath("~/"), "robots.additions.txt");
                if (_fileProvider.FileExists(robotsAdditionsFile))
                {
                    var robotsFileContent = await _fileProvider.ReadAllTextAsync(robotsAdditionsFile, Encoding.UTF8);
                    sb.Append(robotsFileContent);
                }
            }

            return sb.ToString();
        }

        #endregion
    }
}