using System;
using Microsoft.AspNetCore.Mvc;
using QNet.Services.Customers;
using QNet.Web.Factories;
using QNet.Web.Framework.Components;

namespace QNet.Web.Components
{
    public class ProfilePostsViewComponent : QNetViewComponent
    {
        private readonly ICustomerService _customerService;
        private readonly IProfileModelFactory _profileModelFactory;

        public ProfilePostsViewComponent(ICustomerService customerService, IProfileModelFactory profileModelFactory)
        {
            _customerService = customerService;
            _profileModelFactory = profileModelFactory;
        }

        public IViewComponentResult Invoke(int customerProfileId, int pageNumber)
        {
            var customer = _customerService.GetCustomerById(customerProfileId);
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            var model = _profileModelFactory.PrepareProfilePostsModel(customer, pageNumber);
            return View(model);
        }
    }
}
