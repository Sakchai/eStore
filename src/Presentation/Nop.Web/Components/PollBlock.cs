﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Web.Factories;
using Nop.Web.Framework.Components;

namespace Nop.Web.Components
{
    public class PollBlockViewComponent : NopViewComponent
    {
        private readonly IPollModelFactory _pollModelFactory;

        public PollBlockViewComponent(IPollModelFactory pollModelFactory)
        {
            _pollModelFactory = pollModelFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string systemKeyword)
        {

            if (string.IsNullOrWhiteSpace(systemKeyword))
                return Content("");

            var model = await _pollModelFactory.PreparePollModelBySystemNameAsync(systemKeyword);
            if (model == null)
                return Content("");

            return View(model);
        }
    }
}
