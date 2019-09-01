using System;
using Microsoft.AspNetCore.Mvc;
using QNet.Core;
using QNet.Core.Domain;
using QNet.Core.Domain.Customers;
using QNet.Core.Http;
using QNet.Services.Common;
using QNet.Web.Framework.Components;

namespace QNet.Web.Components
{
    public class EuCookieLawViewComponent : QNetViewComponent
    {
        private readonly IGenericAttributeService _genericAttributeService;
        private readonly IStoreContext _storeContext;
        private readonly IWorkContext _workContext;
        private readonly StoreInformationSettings _storeInformationSettings;

        public EuCookieLawViewComponent(IGenericAttributeService genericAttributeService,
            IStoreContext storeContext,
            IWorkContext workContext,
            StoreInformationSettings storeInformationSettings)
        {
            _genericAttributeService = genericAttributeService;
            _storeContext = storeContext;
            _workContext = workContext;
            _storeInformationSettings = storeInformationSettings;
        }

        public IViewComponentResult Invoke()
        {
            if (!_storeInformationSettings.DisplayEuCookieLawWarning)
                //disabled
                return Content("");

            //ignore search engines because some pages could be indexed with the EU cookie as description
            if (_workContext.CurrentCustomer.IsSearchEngineAccount())
                return Content("");

            if (_genericAttributeService.GetAttribute<bool>(_workContext.CurrentCustomer, QNetCustomerDefaults.EuCookieLawAcceptedAttribute, _storeContext.CurrentStore.Id))
                //already accepted
                return Content("");

            //ignore notification?
            //right now it's used during logout so popup window is not displayed twice
            if (TempData[$"{QNetCookieDefaults.Prefix}{QNetCookieDefaults.IgnoreEuCookieLawWarning}"] != null && Convert.ToBoolean(TempData[$"{QNetCookieDefaults.Prefix}{QNetCookieDefaults.IgnoreEuCookieLawWarning}"]))
                return Content("");

            return View();
        }
    }
}