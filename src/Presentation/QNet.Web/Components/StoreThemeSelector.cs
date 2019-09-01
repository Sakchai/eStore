using Microsoft.AspNetCore.Mvc;
using QNet.Core.Domain;
using QNet.Web.Factories;
using QNet.Web.Framework.Components;

namespace QNet.Web.Components
{
    public class StoreThemeSelectorViewComponent : QNetViewComponent
    {
        private readonly ICommonModelFactory _commonModelFactory;
        private readonly StoreInformationSettings _storeInformationSettings;

        public StoreThemeSelectorViewComponent(ICommonModelFactory commonModelFactory,
            StoreInformationSettings storeInformationSettings)
        {
            _commonModelFactory = commonModelFactory;
            _storeInformationSettings = storeInformationSettings;
        }

        public IViewComponentResult Invoke()
        {
            if (!_storeInformationSettings.AllowCustomerToSelectTheme)
                return Content("");

            var model = _commonModelFactory.PrepareStoreThemeSelectorModel();
            return View(model);
        }
    }
}
