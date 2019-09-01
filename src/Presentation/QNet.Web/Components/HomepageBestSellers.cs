using System.Linq;
using Microsoft.AspNetCore.Mvc;
using QNet.Core;
using QNet.Core.Caching;
using QNet.Core.Domain.Catalog;
using QNet.Services.Catalog;
using QNet.Services.Orders;
using QNet.Services.Security;
using QNet.Services.Stores;
using QNet.Web.Factories;
using QNet.Web.Framework.Components;
using QNet.Web.Infrastructure.Cache;

namespace QNet.Web.Components
{
    public class HomepageBestSellersViewComponent : QNetViewComponent
    {
        private readonly CatalogSettings _catalogSettings;
        private readonly IAclService _aclService;
        private readonly IOrderReportService _orderReportService;
        private readonly IProductModelFactory _productModelFactory;
        private readonly IProductService _productService;
        private readonly IStaticCacheManager _cacheManager;
        private readonly IStoreContext _storeContext;
        private readonly IStoreMappingService _storeMappingService;

        public HomepageBestSellersViewComponent(CatalogSettings catalogSettings,
            IAclService aclService,
            IOrderReportService orderReportService,
            IProductModelFactory productModelFactory,
            IProductService productService,
            IStaticCacheManager cacheManager,
            IStoreContext storeContext,
            IStoreMappingService storeMappingService)
        {
            _catalogSettings = catalogSettings;
            _aclService = aclService;
            _orderReportService = orderReportService;
            _productModelFactory = productModelFactory;
            _productService = productService;
            _cacheManager = cacheManager;
            _storeContext = storeContext;
            _storeMappingService = storeMappingService;
        }

        public IViewComponentResult Invoke(int? productThumbPictureSize)
        {
            if (!_catalogSettings.ShowBestsellersOnHomepage || _catalogSettings.NumberOfBestsellersOnHomepage == 0)
                return Content("");

            //load and cache report
            var report = _cacheManager.Get(string.Format(QNetModelCacheDefaults.HomepageBestsellersIdsKey, _storeContext.CurrentStore.Id),
                () => _orderReportService.BestSellersReport(
                        storeId: _storeContext.CurrentStore.Id,
                        pageSize: _catalogSettings.NumberOfBestsellersOnHomepage)
                    .ToList());

            //load products
            var products = _productService.GetProductsByIds(report.Select(x => x.ProductId).ToArray());
            //ACL and store mapping
            products = products.Where(p => _aclService.Authorize(p) && _storeMappingService.Authorize(p)).ToList();
            //availability dates
            products = products.Where(p => _productService.ProductIsAvailable(p)).ToList();

            if (!products.Any())
                return Content("");

            //prepare model
            var model = _productModelFactory.PrepareProductOverviewModels(products, true, true, productThumbPictureSize).ToList();
            return View(model);
        }
    }
}