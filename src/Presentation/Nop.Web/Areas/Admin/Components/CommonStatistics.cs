﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Services.Security;
using Nop.Web.Areas.Admin.Factories;
using Nop.Web.Framework.Components;

namespace Nop.Web.Areas.Admin.Components
{
    /// <summary>
    /// Represents a view component that displays common statistics
    /// </summary>
    public class CommonStatisticsViewComponent : NopViewComponent
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
        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCustomers) ||
                !await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageOrders) ||
                !await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageReturnRequests) ||
                !await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageProducts))
            {
                return Content(string.Empty);
            }

            //a vendor doesn't have access to this report
            if (await _workContext.GetCurrentVendorAsync() != null)
                return Content(string.Empty);

            //prepare model
            var model = await _commonModelFactory.PrepareCommonStatisticsModelAsync();

            return View(model);
        }

        #endregion
    }
}