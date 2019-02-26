﻿using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Core;
using Nop.Plugin.Shipping.UPS.Domain;
using Nop.Plugin.Shipping.UPS.Models;
using Nop.Services;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Shipping.UPS.Controllers
{
    [AuthorizeAdmin]
    [Area(AreaNames.Admin)]
    public class ShippingUPSController : BasePluginController
    {
        #region Fields

        private readonly ILocalizationService _localizationService;
        private readonly INotificationService _notificationService;
        private readonly IPermissionService _permissionService;
        private readonly ISettingService _settingService;
        private readonly UPSSettings _upsSettings;

        #endregion

        #region Ctor

        public ShippingUPSController(ILocalizationService localizationService,
            INotificationService notificationService,
            IPermissionService permissionService,
            ISettingService settingService,
            UPSSettings upsSettings)
        {
            _localizationService = localizationService;
            _notificationService = notificationService;
            _permissionService = permissionService;
            _settingService = settingService;
            _upsSettings = upsSettings;
        }

        #endregion

        #region Methods

        public IActionResult Configure()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageShippingSettings))
                return AccessDeniedView();

            var model = new UPSShippingModel
            {
                Url = _upsSettings.Url,
                AccountNumber = _upsSettings.AccountNumber,
                AccessKey = _upsSettings.AccessKey,
                Username = _upsSettings.Username,
                Password = _upsSettings.Password,
                AdditionalHandlingCharge = _upsSettings.AdditionalHandlingCharge,
                InsurePackage = _upsSettings.InsurePackage,
                PackingPackageVolume = _upsSettings.PackingPackageVolume,
                PackingType = (int)_upsSettings.PackingType,
                PackingTypeValues = _upsSettings.PackingType.ToSelectList(),
                PassDimensions = _upsSettings.PassDimensions
            };
            foreach (UPSCustomerClassification customerClassification in Enum.GetValues(typeof(UPSCustomerClassification)))
            {
                model.AvailableCustomerClassifications.Add(new SelectListItem
                {
                    Text = CommonHelper.ConvertEnum(customerClassification.ToString()),
                    Value = customerClassification.ToString(),
                    Selected = customerClassification == _upsSettings.CustomerClassification
                });
            }
            foreach (UPSPickupType pickupType in Enum.GetValues(typeof(UPSPickupType)))
            {
                model.AvailablePickupTypes.Add(new SelectListItem
                {
                    Text = CommonHelper.ConvertEnum(pickupType.ToString()),
                    Value = pickupType.ToString(),
                    Selected = pickupType == _upsSettings.PickupType
                });
            }
            foreach (UPSPackagingType packagingType in Enum.GetValues(typeof(UPSPackagingType)))
            {
                model.AvailablePackagingTypes.Add(new SelectListItem
                {
                    Text = CommonHelper.ConvertEnum(packagingType.ToString()),
                    Value = packagingType.ToString(),
                    Selected = packagingType == _upsSettings.PackagingType
                });
            }

            // Load Domestic service names
            var carrierServicesOfferedDomestic = _upsSettings.CarrierServicesOffered;
            foreach (var service in UPSServices.Services)
                model.AvailableCarrierServices.Add(service);

            if (!string.IsNullOrEmpty(carrierServicesOfferedDomestic))
                foreach (var service in UPSServices.Services)
                {
                    var serviceId = UPSServices.GetServiceId(service);
                    if (!string.IsNullOrEmpty(serviceId))
                    {
                        // Add delimiters [] so that single digit IDs aren't found in multi-digit IDs
                        if (carrierServicesOfferedDomestic.Contains($"[{serviceId}]"))
                            model.CarrierServicesOffered.Add(service);
                    }
                }

            return View("~/Plugins/Shipping.UPS/Views/Configure.cshtml", model);
        }

        [HttpPost]
        [AdminAntiForgery]
        public IActionResult Configure(UPSShippingModel model)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageShippingSettings))
                return AccessDeniedView();

            if (!ModelState.IsValid)
                return Configure();

            //save settings
            _upsSettings.Url = model.Url;
            _upsSettings.AccountNumber = model.AccountNumber;
            _upsSettings.AccessKey = model.AccessKey;
            _upsSettings.Username = model.Username;
            _upsSettings.Password = model.Password;
            _upsSettings.AdditionalHandlingCharge = model.AdditionalHandlingCharge;
            _upsSettings.InsurePackage = model.InsurePackage;
            _upsSettings.CustomerClassification = (UPSCustomerClassification)Enum.Parse(typeof(UPSCustomerClassification), model.CustomerClassification);
            _upsSettings.PickupType = (UPSPickupType)Enum.Parse(typeof(UPSPickupType), model.PickupType);
            _upsSettings.PackagingType = (UPSPackagingType)Enum.Parse(typeof(UPSPackagingType), model.PackagingType);
            _upsSettings.PackingPackageVolume = model.PackingPackageVolume;
            _upsSettings.PackingType = (PackingType)model.PackingType;
            _upsSettings.PassDimensions = model.PassDimensions;
            _upsSettings.Tracing = model.Tracing;


            // Save selected services
            var carrierServicesOfferedDomestic = new StringBuilder();
            var carrierServicesDomesticSelectedCount = 0;
            if (model.CheckedCarrierServices != null)
            {
                foreach (var cs in model.CheckedCarrierServices)
                {
                    carrierServicesDomesticSelectedCount++;
                    var serviceId = UPSServices.GetServiceId(cs);
                    if (!string.IsNullOrEmpty(serviceId))
                    {
                        // Add delimiters [] so that single digit IDs aren't found in multi-digit IDs
                        carrierServicesOfferedDomestic.AppendFormat("[{0}]:", serviceId);
                    }
                }
            }
            // Add default options if no services were selected
            if (carrierServicesDomesticSelectedCount == 0)
                _upsSettings.CarrierServicesOffered = "[03]:[12]:[11]:[08]:";
            else
                _upsSettings.CarrierServicesOffered = carrierServicesOfferedDomestic.ToString();

            _settingService.SaveSetting(_upsSettings);

            _notificationService.SuccessNotification(_localizationService.GetResource("Admin.Plugins.Saved"));

            return Configure();
        }

        #endregion
    }
}