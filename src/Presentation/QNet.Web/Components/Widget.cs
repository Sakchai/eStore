using System.Linq;
using Microsoft.AspNetCore.Mvc;
using QNet.Web.Factories;
using QNet.Web.Framework.Components;

namespace QNet.Web.Components
{
    public class WidgetViewComponent : QNetViewComponent
    {
        private readonly IWidgetModelFactory _widgetModelFactory;

        public WidgetViewComponent(IWidgetModelFactory widgetModelFactory)
        {
            _widgetModelFactory = widgetModelFactory;
        }

        public IViewComponentResult Invoke(string widgetZone, object additionalData = null)
        {
            var model = _widgetModelFactory.PrepareRenderWidgetModel(widgetZone, additionalData);

            //no data?
            if (!model.Any())
                return Content("");

            return View(model);
        }
    }
}