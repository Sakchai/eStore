using Microsoft.AspNetCore.Mvc;
using QNet.Web.Factories;
using QNet.Web.Framework.Components;

namespace QNet.Web.Components
{
    public class CustomerNavigationViewComponent : QNetViewComponent
    {
        private readonly ICustomerModelFactory _customerModelFactory;

        public CustomerNavigationViewComponent(ICustomerModelFactory customerModelFactory)
        {
            _customerModelFactory = customerModelFactory;
        }

        public IViewComponentResult Invoke(int selectedTabId = 0)
        {
            var model = _customerModelFactory.PrepareCustomerNavigationModel(selectedTabId);
            return View(model);
        }
    }
}
