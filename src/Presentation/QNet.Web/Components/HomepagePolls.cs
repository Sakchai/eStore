using System.Linq;
using Microsoft.AspNetCore.Mvc;
using QNet.Web.Factories;
using QNet.Web.Framework.Components;

namespace QNet.Web.Components
{
    public class HomepagePollsViewComponent : QNetViewComponent
    {
        private readonly IPollModelFactory _pollModelFactory;

        public HomepagePollsViewComponent(IPollModelFactory pollModelFactory)
        {
            _pollModelFactory = pollModelFactory;
        }

        public IViewComponentResult Invoke()
        {
            var model = _pollModelFactory.PrepareHomepagePollModels();
            if (!model.Any())
                return Content("");

            return View(model);
        }
    }
}
