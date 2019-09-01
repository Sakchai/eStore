using Microsoft.AspNetCore.Mvc;
using QNet.Web.Factories;
using QNet.Web.Framework.Components;

namespace QNet.Web.Components
{
    public class HeaderLinksViewComponent : QNetViewComponent
    {
        private readonly ICommonModelFactory _commonModelFactory;

        public HeaderLinksViewComponent(ICommonModelFactory commonModelFactory)
        {
            _commonModelFactory = commonModelFactory;
        }

        public IViewComponentResult Invoke()
        {
            var model = _commonModelFactory.PrepareHeaderLinksModel();
            return View(model);
        }
    }
}
