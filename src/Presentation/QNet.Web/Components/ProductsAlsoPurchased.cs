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
    public class ProductsAlsoPurchasedViewComponent : QNetViewComponent
    {
        private readonly CatalogSettings _catalogSettings;
        private readonly IAclService _aclService;
        private readonly IOrderReportService _orderReportService;
        private readonly IProductModelFactory _productModelFactory;
        private readonly IProductService _productService;
        private readonly IStaticCacheManager _cacheManager;
        private readonly IStoreContext _storeContext;
        private readonly IStoreMappingService _storeMappingService;

        public ProductsAlsoPurchasedViewComponent(CatalogSettings catalogSettings,
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

        public IViewComponentResult Invoke(int productId, int? productThumbPictureSize)
        {
            if (!_catalogSettings.ProductsAlsoPurchasedEnabled)
                return Content("");

            //load and cache report
            var productIds = _cacheManager.Get(string.Format(QNetModelCacheDefaults.ProductsAlsoPurchasedIdsKey, productId, _storeContext.CurrentStore.Id),
                () => _orderReportService.GetAlsoPurchasedProductsIds(_storeContext.CurrentStore.Id, productId, _catalogSettings.ProductsAlsoPurchasedNumber)
            );

            //load products
            var products = _productService.GetProductsByIds(productIds);
            //ACL and store mapping
            products = products.Where(p => _aclService.Authorize(p) && _storeMappingService.Authorize(p)).ToList();
            //availability dates
            products = products.Where(p => _productService.ProductIsAvailable(p)).ToList();

            if (!products.Any())
                return Content("");

            var model = _productModelFactory.PrepareProductOverviewModels(products, true, true, productThumbPictureSize).ToList();
            return View(model);
        }
    }
}