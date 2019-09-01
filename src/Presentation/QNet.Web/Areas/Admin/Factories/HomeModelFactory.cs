using System;
using System.Linq;
using QNet.Core;
using QNet.Core.Caching;
using QNet.Core.Domain.Common;
using QNet.Services.Common;
using QNet.Services.Configuration;
using QNet.Web.Areas.Admin.Infrastructure.Cache;
using QNet.Web.Areas.Admin.Models.Home;

namespace QNet.Web.Areas.Admin.Factories
{
    /// <summary>
    /// Represents the home models factory implementation
    /// </summary>
    public partial class HomeModelFactory : IHomeModelFactory
    {
        #region Fields

        private readonly AdminAreaSettings _adminAreaSettings;
        private readonly ICommonModelFactory _commonModelFactory;
        private readonly IOrderModelFactory _orderModelFactory;
        private readonly ISettingService _settingService;
        private readonly IStaticCacheManager _cacheManager;
        private readonly IWorkContext _workContext;
        private readonly QNetHttpClient _nopHttpClient;

        #endregion

        #region Ctor

        public HomeModelFactory(AdminAreaSettings adminAreaSettings,
            ICommonModelFactory commonModelFactory,
            IOrderModelFactory orderModelFactory,
            ISettingService settingService,
            IStaticCacheManager cacheManager,
            IWorkContext workContext,
            QNetHttpClient nopHttpClient)
        {
            _adminAreaSettings = adminAreaSettings;
            _commonModelFactory = commonModelFactory;
            _orderModelFactory = orderModelFactory;
            _settingService = settingService;
            _cacheManager = cacheManager;
            _workContext = workContext;
            _nopHttpClient = nopHttpClient;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Prepare dashboard model
        /// </summary>
        /// <param name="model">Dashboard model</param>
        /// <returns>Dashboard model</returns>
        public virtual DashboardModel PrepareDashboardModel(DashboardModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            model.IsLoggedInAsVendor = _workContext.CurrentVendor != null;

            //prepare nested search models
            _commonModelFactory.PreparePopularSearchTermSearchModel(model.PopularSearchTerms);
            _orderModelFactory.PrepareBestsellerBriefSearchModel(model.BestsellersByAmount);
            _orderModelFactory.PrepareBestsellerBriefSearchModel(model.BestsellersByQuantity);

            return model;
        }

        /// <summary>
        /// Prepare QNet news model
        /// </summary>
        /// <returns>QNet news model</returns>
        public virtual QNetCommerceNewsModel PrepareQNetCommerceNewsModel()
        {
            var model = new QNetCommerceNewsModel
            {
                HideAdvertisements = _adminAreaSettings.HideAdvertisementsOnAdminArea
            };

            var rssData = _cacheManager.Get(QNetModelCacheDefaults.OfficialNewsModelKey, () => _nopHttpClient.GetNewsRssAsync().Result);

            for (var i = 0; i < rssData.Items.Count; i++)
            {
                var item = rssData.Items.ElementAt(i);
                var newsItem = new QNetCommerceNewsDetailsModel
                {
                    Title = item.TitleText,
                    Summary = item.ContentText,
                    Url = item.Url.OriginalString,
                    PublishDate = item.PublishDate
                };
                model.Items.Add(newsItem);

                //has new items?
                if (i == 0)
                {
                    var firstRequest = string.IsNullOrEmpty(_adminAreaSettings.LastNewsTitleAdminArea);
                    if (_adminAreaSettings.LastNewsTitleAdminArea != newsItem.Title)
                    {
                        _adminAreaSettings.LastNewsTitleAdminArea = newsItem.Title;
                        _settingService.SaveSetting(_adminAreaSettings);

                        if (!firstRequest)
                        {
                            //new item
                            model.HasNewItems = true;
                        }
                    }
                }
            }

            return model;
        }

        #endregion
    }
}