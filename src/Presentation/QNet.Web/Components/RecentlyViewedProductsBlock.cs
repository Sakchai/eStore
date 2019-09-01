using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using QNet.Core.Domain.Catalog;
using QNet.Services.Catalog;
using QNet.Services.Security;
using QNet.Services.Stores;
using QNet.Web.Factories;
using QNet.Web.Framework.Components;
using QNet.Web.Models.Catalog;

namespace QNet.Web.Components
{
    public class RecentlyViewedProductsBlockViewComponent : QNetViewComponent
    {
        private readonly CatalogSettings _catalogSettings;
        private readonly IAclService _aclService;
        private readonly IProductModelFactory _productModelFactory;
        private readonly IProductService _productService;
        private readonly IRecentlyViewedProductsService _recentlyViewedProductsService;
        private readonly IStoreMappingService _storeMappingService;

        public RecentlyViewedProductsBlockViewComponent(CatalogSettings catalogSettings,
            IAclService aclService,
            IProductModelFactory productModelFactory,
            IProductService productService,
            IRecentlyViewedProductsService recentlyViewedProductsService,
            IStoreMappingService storeMappingService)
        {
            _catalogSettings = catalogSettings;
            _aclService = aclService;
            _productModelFactory = productModelFactory;
            _productService = productService;
            _recentlyViewedProductsService = recentlyViewedProductsService;
            _storeMappingService = storeMappingService;
        }

        public IViewComponentResult Invoke(int? productThumbPictureSize, bool? preparePriceModel)
        {
            if (!_catalogSettings.RecentlyViewedProductsEnabled)
                return Content("");

            var preparePictureModel = productThumbPictureSize.HasValue;
            var products = _recentlyViewedProductsService.GetRecentlyViewedProducts(_catalogSettings.RecentlyViewedProductsNumber);

            //ACL and store mapping
            products = products.Where(p => _aclService.Authorize(p) && _storeMappingService.Authorize(p)).ToList();
            //availability dates
            products = products.Where(p => _productService.ProductIsAvailable(p)).ToList();

            if (!products.Any())
                return Content("");

            //prepare model
            var model = new List<ProductOverviewModel>();
            model.AddRange(_productModelFactory.PrepareProductOverviewModels(products,
                preparePriceModel.GetValueOrDefault(),
                preparePictureModel,
                productThumbPictureSize));

            return View(model);
        }
    }
}