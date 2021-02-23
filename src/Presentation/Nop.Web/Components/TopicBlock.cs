﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Web.Factories;
using Nop.Web.Framework.Components;

namespace Nop.Web.Components
{
    public class TopicBlockViewComponent : NopViewComponent
    {
        private readonly ITopicModelFactory _topicModelFactory;

        public TopicBlockViewComponent(ITopicModelFactory topicModelFactory)
        {
            _topicModelFactory = topicModelFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string systemName)
        {
            var model = await _topicModelFactory.PrepareTopicModelBySystemNameAsync(systemName);
            if (model == null)
                return Content("");
            return View(model);
        }
    }
}
