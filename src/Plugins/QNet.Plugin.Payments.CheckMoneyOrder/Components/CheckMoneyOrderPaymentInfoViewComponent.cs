using Microsoft.AspNetCore.Mvc;
using QNet.Core;
using QNet.Plugin.Payments.CheckMoneyOrder.Models;
using QNet.Services.Localization;
using QNet.Web.Framework.Components;

namespace QNet.Plugin.Payments.CheckMoneyOrder.Components
{
    [ViewComponent(Name = "CheckMoneyOrder")]
    public class CheckMoneyOrderViewComponent : QNetViewComponent
    {
        private readonly CheckMoneyOrderPaymentSettings _checkMoneyOrderPaymentSettings;
        private readonly ILocalizationService _localizationService;
        private readonly IStoreContext _storeContext;
        private readonly IWorkContext _workContext;

        public CheckMoneyOrderViewComponent(CheckMoneyOrderPaymentSettings checkMoneyOrderPaymentSettings,
            ILocalizationService localizationService,
            IStoreContext storeContext,
            IWorkContext workContext)
        {
            _checkMoneyOrderPaymentSettings = checkMoneyOrderPaymentSettings;
            _localizationService = localizationService;
            _storeContext = storeContext;
            _workContext = workContext;
        }

        public IViewComponentResult Invoke()
        {
            var model = new PaymentInfoModel
            {
                DescriptionText = _localizationService.GetLocalizedSetting(_checkMoneyOrderPaymentSettings,
                    x => x.DescriptionText, _workContext.WorkingLanguage.Id, _storeContext.CurrentStore.Id)
            };

            return View("~/Plugins/Payments.CheckMoneyOrder/Views/PaymentInfo.cshtml", model);
        }
    }
}