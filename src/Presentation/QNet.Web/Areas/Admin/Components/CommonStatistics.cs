using Microsoft.AspNetCore.Mvc;
using QNet.Core;
using QNet.Services.Security;
using QNet.Web.Areas.Admin.Factories;
using QNet.Web.Framework.Components;

namespace QNet.Web.Areas.Admin.Components
{
    /// <summary>
    /// Represents a view component that displays common statistics
    /// </summary>
    public class CommonStatisticsViewComponent : QNetViewComponent
    {
        #region Fields

        private readonly ICommonModelFactory _commonModelFactory;
        private readonly IPermissionService _permissionService;
        private readonly IWorkContext _workContext;

        #endregion

        #region Ctor

        public CommonStatisticsViewComponent(ICommonModelFactory commonModelFactory,
            IPermissionService permissionService,
            IWorkContext workContext)
        {
            _commonModelFactory = commonModelFactory;
            _permissionService = permissionService;
            _workContext = workContext;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invoke view component
        /// </summary>
        /// <returns>View component result</returns>
        public IViewComponentResult Invoke()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageCustomers) ||
                !_permissionService.Authorize(StandardPermissionProvider.ManageOrders) ||
                !_permissionService.Authorize(StandardPermissionProvider.ManageReturnRequests) ||
                !_permissionService.Authorize(StandardPermissionProvider.ManageProducts))
            {
                return Content(string.Empty);
            }

            //a vendor doesn't have access to this report
            if (_workContext.CurrentVendor != null)
                return Content(string.Empty);

            //prepare model
            var model = _commonModelFactory.PrepareCommonStatisticsModel();

            return View(model);
        }

        #endregion
    }
}