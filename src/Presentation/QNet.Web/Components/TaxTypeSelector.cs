using Microsoft.AspNetCore.Mvc;
using QNet.Core.Domain.Tax;
using QNet.Web.Factories;
using QNet.Web.Framework.Components;

namespace QNet.Web.Components
{
    public class TaxTypeSelectorViewComponent : QNetViewComponent
    {
        private readonly ICommonModelFactory _commonModelFactory;
        private readonly TaxSettings _taxSettings;

        public TaxTypeSelectorViewComponent(ICommonModelFactory commonModelFactory,
            TaxSettings taxSettings)
        {
            _commonModelFactory = commonModelFactory;
            _taxSettings = taxSettings;
        }

        public IViewComponentResult Invoke()
        {
            if (!_taxSettings.AllowCustomersToSelectTaxDisplayType)
                return Content("");

            var model = _commonModelFactory.PrepareTaxTypeSelectorModel();
            return View(model);
        }
    }
}
