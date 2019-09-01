using Microsoft.AspNetCore.Mvc;
using QNet.Core.Domain.Customers;
using QNet.Services.Customers;
using QNet.Services.Security;
using QNet.Web.Factories;
using QNet.Web.Framework;
using QNet.Web.Framework.Mvc.Filters;
using QNet.Web.Framework.Security;

namespace QNet.Web.Controllers
{
    [HttpsRequirement(SslRequirement.No)]
    public partial class ProfileController : BasePublicController
    {
        private readonly CustomerSettings _customerSettings;
        private readonly ICustomerService _customerService;
        private readonly IPermissionService _permissionService;
        private readonly IProfileModelFactory _profileModelFactory;

        public ProfileController(CustomerSettings customerSettings,
            ICustomerService customerService,
            IPermissionService permissionService,
            IProfileModelFactory profileModelFactory)
        {
            _customerSettings = customerSettings;
            _customerService = customerService;
            _permissionService = permissionService;
            _profileModelFactory = profileModelFactory;
        }

        public virtual IActionResult Index(int? id, int? pageNumber)
        {
            if (!_customerSettings.AllowViewingProfiles)
            {
                return RedirectToRoute("Homepage");
            }

            var customerId = 0;
            if (id.HasValue)
            {
                customerId = id.Value;
            }

            var customer = _customerService.GetCustomerById(customerId);
            if (customer == null || customer.IsGuest())
            {
                return RedirectToRoute("Homepage");
            }

            //display "edit" (manage) link
            if (_permissionService.Authorize(StandardPermissionProvider.AccessAdminPanel) && _permissionService.Authorize(StandardPermissionProvider.ManageCustomers))
                DisplayEditLink(Url.Action("Edit", "Customer", new { id = customer.Id, area = AreaNames.Admin }));

            var model = _profileModelFactory.PrepareProfileIndexModel(customer, pageNumber);
            return View(model);
        }
    }
}