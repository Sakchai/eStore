using System.Linq;
using Microsoft.AspNetCore.Mvc;
using QNet.Core;
using QNet.Core.Caching;
using QNet.Services.Catalog;
using QNet.Services.Security;
using QNet.Services.Stores;
using QNet.Web.Factories;
using QNet.Web.Framework.Components;
using QNet.Web.Infrastructure.Cache;

namespace QNet.Web.Components
{
    public class RelatedProductsViewComponent : QNetViewComponent
    {
        private readonly IAclService _aclService;
        private readonly IProductModelFactory _productModelFactory;
        private readonly IProductService _productService;
        private readonly IStaticCacheManager _cacheManager;
        private readonly IStoreContext _storeContext;
        private readonly IStoreMappingService _storeMappingService;

        public RelatedProductsViewComponent(IAclService aclService,
            IProductModelFactory productModelFactory,
            IProductService productService,
            IStaticCacheManager cacheManager,
            IStoreContext storeContext,
            IStoreMappingService storeMappingService)
        {
            _aclService = aclService;
            _productModelFactory = productModelFactory;
            _productService = productService;
            _cacheManager = cacheManager;
            _storeContext = storeContext;
            _storeMappingService = storeMappingService;
        }

        public IViewComponentResult Invoke(int productId, int? productThumbPictureSize)
        {
            //load and cache report
            var productIds = _cacheManager.Get(string.Format(QNetModelCacheDefaults.ProductsRelatedIdsKey, productId, _storeContext.CurrentStore.Id),
                () => _productService.GetRelatedProductsByProductId1(productId).Select(x => x.ProductId2).ToArray());

            //load products
            var products = _productService.GetProductsByIds(productIds);
            //ACL and store mapping
            products = products.Where(p => _aclService.Authorize(p) && _storeMappingService.Authorize(p)).ToList();
            //availability dates
            products = products.Where(p => _productService.ProductIsAvailable(p)).ToList();
            //visible individually
            products = products.Where(p => p.VisibleIndividually).ToList();

            if (!products.Any())
                return Content("");

            var model = _productModelFactory.PrepareProductOverviewModels(products, true, true, productThumbPictureSize).ToList();
            return View(model);
        }
    }
}