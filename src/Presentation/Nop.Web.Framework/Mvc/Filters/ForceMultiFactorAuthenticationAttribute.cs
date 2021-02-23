﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Nop.Core;
using Nop.Core.Domain.Customers;
using Nop.Data;
using Nop.Services.Authentication.MultiFactor;
using Nop.Services.Common;
using Nop.Services.Customers;

namespace Nop.Web.Framework.Mvc.Filters
{
    /// <summary>
    /// Represents filter attribute that validates force of the multi-factor authentication
    /// </summary>
    public sealed class ForceMultiFactorAuthenticationAttribute : TypeFilterAttribute
    {

        #region Ctor

        /// <summary>
        /// Create instance of the filter attribute
        /// </summary>
        public ForceMultiFactorAuthenticationAttribute() : base(typeof(ForceMultiFactorAuthenticationFilter))
        {
        }

        #endregion

        #region Nested filter

        private class ForceMultiFactorAuthenticationFilter : IAsyncActionFilter
        {
            #region Fields

            private readonly ICustomerService _customerService;
            private readonly IGenericAttributeService _genericAttributeService;
            private readonly IMultiFactorAuthenticationPluginManager _multiFactorAuthenticationPluginManager;
            private readonly IWorkContext _workContext;
            private readonly MultiFactorAuthenticationSettings _multiFactorAuthenticationSettings;

            #endregion

            #region Ctor

            public ForceMultiFactorAuthenticationFilter(ICustomerService customerService,
                IGenericAttributeService genericAttributeService,
                IMultiFactorAuthenticationPluginManager multiFactorAuthenticationPluginManager,
                IWorkContext workContext,
                MultiFactorAuthenticationSettings multiFactorAuthenticationSettings)
            {
                _customerService = customerService;
                _genericAttributeService = genericAttributeService;
                _multiFactorAuthenticationPluginManager = multiFactorAuthenticationPluginManager;
                _workContext = workContext;
                _multiFactorAuthenticationSettings = multiFactorAuthenticationSettings;
            }

            #endregion

            #region Utilities

            /// <summary>
            /// Called asynchronously before the action, after model binding is complete.
            /// </summary>
            /// <param name="context">A context for action filters</param>
            /// <returns>A task that on completion indicates the necessary filter actions have been executed</returns>
            private async Task ValidateAuthenticationForceAsync(ActionExecutingContext context)
            {
                if (context == null)
                    throw new ArgumentNullException(nameof(context));

                if (context.HttpContext.Request == null)
                    return;

                if (!await DataSettingsManager.IsDatabaseInstalledAsync())
                    return;

                //validate only for registered customers
                var customer = await _workContext.GetCurrentCustomerAsync();
                if (!await _customerService.IsRegisteredAsync(customer))
                    return;

                //don't validate on the 'Multi-factor authentication settings' page
                var actionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
                var actionName = actionDescriptor?.ActionName;
                var controllerName = actionDescriptor?.ControllerName;
                if (string.IsNullOrEmpty(actionName) || string.IsNullOrEmpty(controllerName))
                    return;

                if (controllerName.Equals("Customer", StringComparison.InvariantCultureIgnoreCase) &&
                    actionName.Equals("MultiFactorAuthentication", StringComparison.InvariantCultureIgnoreCase))
                {
                    return;
                }

                //whether the feature is enabled
                if (!_multiFactorAuthenticationSettings.ForceMultifactorAuthentication ||
                    !await _multiFactorAuthenticationPluginManager.HasActivePluginsAsync())
                {
                    return;
                }

                //check selected provider of MFA
                var selectedProvider = await _genericAttributeService
                    .GetAttributeAsync<string>(customer, NopCustomerDefaults.SelectedMultiFactorAuthenticationProviderAttribute);
                if (!string.IsNullOrEmpty(selectedProvider))
                    return;

                //redirect to MultiFactorAuthenticationSettings page if force is enabled
                context.Result = new RedirectToRouteResult("MultiFactorAuthenticationSettings", null);
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
                await ValidateAuthenticationForceAsync(context);
                if (context.Result == null)
                    await next();
            }

            #endregion
        }

        #endregion
    }
}
