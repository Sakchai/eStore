﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Tax;
using Nop.Services.Common;
using Nop.Services.Customers;
using Nop.Web.Framework.Controllers;

namespace Nop.Plugin.Tax.Avalara.Controllers
{
    public class AddressValidationController : BaseController
    {
        #region Fields

        private readonly IAddressService _addressService;
        private readonly ICustomerService _customerService;
        private readonly IWorkContext _workContext;
        private readonly TaxSettings _taxSettings;

        #endregion

        #region Ctor

        public AddressValidationController(IAddressService addressService,
            ICustomerService customerService,
            IWorkContext workContext,
            TaxSettings taxSettings)
        {
            _addressService = addressService;
            _customerService = customerService;
            _workContext = workContext;
            _taxSettings = taxSettings;
        }

        #endregion

        #region Methods

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> UseValidatedAddress(int addressId, bool isNewAddress)
        {
            //try to get an address by the passed identifier
            var address = await _addressService.GetAddressByIdAsync(addressId);
            if (address != null)
            {
                //add address to customer collection if it's a new
                if (isNewAddress) await _customerService.InsertCustomerAddressAsync(await _workContext.GetCurrentCustomerAsync(), address);

                //and update appropriate customer address
                if (_taxSettings.TaxBasedOn == TaxBasedOn.BillingAddress)
                    (await _workContext.GetCurrentCustomerAsync()).BillingAddressId = address.Id;
                if (_taxSettings.TaxBasedOn == TaxBasedOn.ShippingAddress)
                    (await _workContext.GetCurrentCustomerAsync()).ShippingAddressId = address.Id;
                await _customerService.UpdateCustomerAsync(await _workContext.GetCurrentCustomerAsync());
            }

            //nothing to return
            return Content(string.Empty);
        }

        #endregion
    }
}