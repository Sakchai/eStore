﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Services.Customers;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Misc.Sendinblue.Components
{
    /// <summary>
    /// Represents view component to embed tracking script on pages
    /// </summary>
    [ViewComponent(Name = SendinblueDefaults.TRACKING_VIEW_COMPONENT_NAME)]
    public class WidgetsSendinblueViewComponent : NopViewComponent
    {
        #region Fields

        private readonly ICustomerService _customerService;
        private readonly IWorkContext _workContext;
        private readonly SendinblueSettings _sendinblueSettings;

        #endregion

        #region Ctor

        public WidgetsSendinblueViewComponent(ICustomerService customerService,
            IWorkContext workContext,
            SendinblueSettings sendinblueSettings)
        {
            _customerService = customerService;
            _workContext = workContext;
            _sendinblueSettings = sendinblueSettings;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invoke view component
        /// </summary>
        /// <param name="widgetZone">Widget zone name</param>
        /// <param name="additionalData">Additional data</param>
        /// <returns>View component result</returns>
        public async Task<IViewComponentResult> InvokeAsync(string widgetZone, object additionalData)
        {
            var trackingScript = string.Empty;

            //ensure Marketing Automation is enabled
            if (!_sendinblueSettings.UseMarketingAutomation)
                return Content(trackingScript);

            //get customer email
            var customerEmail = !await _customerService.IsGuestAsync(await _workContext.GetCurrentCustomerAsync())
                ? (await _workContext.GetCurrentCustomerAsync()).Email?.Replace("'", "\\'")
                : string.Empty;

            //prepare tracking script
            trackingScript = $"{_sendinblueSettings.TrackingScript}{Environment.NewLine}"
                .Replace(SendinblueDefaults.TrackingScriptId, _sendinblueSettings.MarketingAutomationKey)
                .Replace(SendinblueDefaults.TrackingScriptCustomerEmail, customerEmail);

            return View("~/Plugins/Misc.Sendinblue/Views/PublicInfo.cshtml", trackingScript);
        }

        #endregion
    }
}