using Microsoft.AspNetCore.Mvc;
using QNet.Web.Factories;
using QNet.Web.Framework.Components;

namespace QNet.Web.Components
{
    public class PollBlockViewComponent : QNetViewComponent
    {
        private readonly IPollModelFactory _pollModelFactory;

        public PollBlockViewComponent(IPollModelFactory pollModelFactory)
        {
            _pollModelFactory = pollModelFactory;
        }

        public IViewComponentResult Invoke(string systemKeyword)
        {

            if (string.IsNullOrWhiteSpace(systemKeyword))
                return Content("");

            var model = _pollModelFactory.PreparePollModelBySystemName(systemKeyword);
            if (model == null)
                return Content("");

            return View(model);
        }
    }
}
