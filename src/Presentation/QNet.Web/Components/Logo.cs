using Microsoft.AspNetCore.Mvc;
using QNet.Web.Factories;
using QNet.Web.Framework.Components;

namespace QNet.Web.Components
{
    public class LogoViewComponent : QNetViewComponent
    {
        private readonly ICommonModelFactory _commonModelFactory;

        public LogoViewComponent(ICommonModelFactory commonModelFactory)
        {
            _commonModelFactory = commonModelFactory;
        }

        public IViewComponentResult Invoke()
        {
            var model = _commonModelFactory.PrepareLogoModel();
            return View(model);
        }
    }
}
