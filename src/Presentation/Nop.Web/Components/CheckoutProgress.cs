﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Web.Factories;
using Nop.Web.Framework.Components;
using Nop.Web.Models.Checkout;

namespace Nop.Web.Components
{
    public class CheckoutProgressViewComponent : NopViewComponent
    {
        private readonly ICheckoutModelFactory _checkoutModelFactory;

        public CheckoutProgressViewComponent(ICheckoutModelFactory checkoutModelFactory)
        {
            _checkoutModelFactory = checkoutModelFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(CheckoutProgressStep step)
        {
            var model = await _checkoutModelFactory.PrepareCheckoutProgressModelAsync(step);
            return View(model);
        }
    }
}
