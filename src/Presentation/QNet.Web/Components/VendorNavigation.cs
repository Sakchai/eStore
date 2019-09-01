using System.Linq;
using Microsoft.AspNetCore.Mvc;
using QNet.Core.Domain.Vendors;
using QNet.Web.Factories;
using QNet.Web.Framework.Components;

namespace QNet.Web.Components
{
    public class VendorNavigationViewComponent : QNetViewComponent
    {
        private readonly ICatalogModelFactory _catalogModelFactory;
        private readonly VendorSettings _vendorSettings;

        public VendorNavigationViewComponent(ICatalogModelFactory catalogModelFactory,
            VendorSettings vendorSettings)
        {
            _catalogModelFactory = catalogModelFactory;
            _vendorSettings = vendorSettings;
        }

        public IViewComponentResult Invoke()
        {
            if (_vendorSettings.VendorsBlockItemsToDisplay == 0)
                return Content("");

            var model = _catalogModelFactory.PrepareVendorNavigationModel();
            if (!model.Vendors.Any())
                return Content("");

            return View(model);
        }
    }
}
