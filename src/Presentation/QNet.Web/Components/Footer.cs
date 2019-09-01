using Microsoft.AspNetCore.Mvc;
using QNet.Web.Factories;
using QNet.Web.Framework.Components;

namespace QNet.Web.Components
{
    public class FooterViewComponent : QNetViewComponent
    {
        private readonly ICommonModelFactory _commonModelFactory;

        public FooterViewComponent(ICommonModelFactory commonModelFactory)
        {
            _commonModelFactory = commonModelFactory;
        }

        public IViewComponentResult Invoke()
        {
            var model = _commonModelFactory.PrepareFooterModel();
            return View(model);
        }
    }
}
