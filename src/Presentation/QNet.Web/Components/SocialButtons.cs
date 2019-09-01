using Microsoft.AspNetCore.Mvc;
using QNet.Web.Factories;
using QNet.Web.Framework.Components;

namespace QNet.Web.Components
{
    public class SocialButtonsViewComponent : QNetViewComponent
    {
        private readonly ICommonModelFactory _commonModelFactory;

        public SocialButtonsViewComponent(ICommonModelFactory commonModelFactory)
        {
            _commonModelFactory = commonModelFactory;
        }

        public IViewComponentResult Invoke()
        {
            var model = _commonModelFactory.PrepareSocialModel();
            return View(model);
        }
    }
}
