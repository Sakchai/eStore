﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Nop.Core;
using Nop.Data;
using Nop.Services.Customers;

namespace Nop.Web.Framework.Mvc.Filters
{
    /// <summary>
    /// Represents filter attribute that validates customer password expiration
    /// </summary>
    public sealed class ValidatePasswordAttribute : TypeFilterAttribute
    {
        #region Ctor

        /// <summary>
        /// Create instance of the filter attribute
        /// </summary>
        public ValidatePasswordAttribute() : base(typeof(ValidatePasswordFilter))
        {
        }

        #endregion

        #region Nested filter

        /// <summary>
        /// Represents a filter that validates customer password expiration
        /// </summary>
        private class ValidatePasswordFilter : IAsyncActionFilter
        {
            #region Fields

            private readonly ICustomerService _customerService;
            private readonly IWorkContext _workContext;

            #endregion

            #region Ctor

            public ValidatePasswordFilter(ICustomerService customerService,
                IWorkContext workContext)
            {
                _customerService = customerService;
                _workContext = workContext;
            }

            #endregion

            #region Utilities

            /// <summary>
            /// Called asynchronously before the action, after model binding is complete.
            /// </summary>
            /// <param name="context">A context for action filters</param>
            /// <returns>A task that on completion indicates the necessary filter actions have been executed</returns>
            private async Task ValidatePasswordAsync(ActionExecutingContext context)
            {
                if (context == null)
                    throw new ArgumentNullException(nameof(context));

                if (context.HttpContext.Request == null)
                    return;

                if (!await DataSettingsManager.IsDatabaseInstalledAsync())
                    return;

                //get action and controller names
                var actionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
                var actionName = actionDescriptor?.ActionName;
                var controllerName = actionDescriptor?.ControllerName;

                if (string.IsNullOrEmpty(actionName) || string.IsNullOrEmpty(controllerName))
                    return;

                //don't validate on the 'Change Password' page
                if (controllerName.Equals("Customer", StringComparison.InvariantCultureIgnoreCase) &&
                    actionName.Equals("ChangePassword", StringComparison.InvariantCultureIgnoreCase))
                    return;

                //check password expiration
                var customer = await _workContext.GetCurrentCustomerAsync();
                if (!await _customerService.PasswordIsExpiredAsync(customer))
                    return;

                //redirect to ChangePassword page if expires
                context.Result = new RedirectToRouteResult("CustomerChangePassword", null);
            }

            #endregion

            #region Methods

            /// <summary>
            /// Called asynchronously before the action, after model binding is complete.
            /// </summary>
            /// <param name="context">A context for action filters</param>
            /// <param name="next">A delegate invoked to execute the next action filter or the action itself</param>
            /// <returns>A task that on completion indicates the filter has executed</returns>
            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                await ValidatePasswordAsync(context);
                if (context.Result == null)
                    await next();
            }

            #endregion
        }

        #endregion
    }
}