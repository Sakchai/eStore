﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Shipping;
using Nop.Services.Common;
using Nop.Services.Directory;
using Nop.Services.Localization;
using Nop.Services.Shipping;
using Nop.Services.Shipping.Date;
using Nop.Services.Shipping.Pickup;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Common;
using Nop.Web.Areas.Admin.Models.Directory;
using Nop.Web.Areas.Admin.Models.Shipping;
using Nop.Web.Framework.Factories;
using Nop.Web.Framework.Models.Extensions;

namespace Nop.Web.Areas.Admin.Factories
{
    /// <summary>
    /// Represents the shipping model factory implementation
    /// </summary>
    public partial class ShippingModelFactory : IShippingModelFactory
    {
        #region Fields

        private readonly IAddressService _addressService;
        private readonly IBaseAdminModelFactory _baseAdminModelFactory;
        private readonly ICountryService _countryService;
        private readonly IDateRangeService _dateRangeService;
        private readonly ILocalizationService _localizationService;
        private readonly ILocalizedModelFactory _localizedModelFactory;
        private readonly IPickupPluginManager _pickupPluginManager;
        private readonly IShippingPluginManager _shippingPluginManager;
        private readonly IShippingService _shippingService;
        private readonly IStateProvinceService _stateProvinceService;

        #endregion

        #region Ctor

        public ShippingModelFactory(IAddressService addressService,
            IBaseAdminModelFactory baseAdminModelFactory,
            ICountryService countryService,
            IDateRangeService dateRangeService,
            ILocalizationService localizationService,
            ILocalizedModelFactory localizedModelFactory,
            IPickupPluginManager pickupPluginManager,
            IShippingPluginManager shippingPluginManager,
            IShippingService shippingService,
            IStateProvinceService stateProvinceService)
        {
            _addressService = addressService;
            _baseAdminModelFactory = baseAdminModelFactory;
            _countryService = countryService;
            _dateRangeService = dateRangeService;
            _localizationService = localizationService;
            _localizedModelFactory = localizedModelFactory;
            _pickupPluginManager = pickupPluginManager;
            _shippingPluginManager = shippingPluginManager;
            _shippingService = shippingService;
            _stateProvinceService = stateProvinceService;
        }

        #endregion

        #region Utilities
        
        /// <summary>
        /// Prepare delivery date search model
        /// </summary>
        /// <param name="searchModel">Delivery date search model</param>
        /// <returns>Delivery date search model</returns>
        protected virtual DeliveryDateSearchModel PrepareDeliveryDateSearchModel(DeliveryDateSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //prepare page parameters
            searchModel.SetGridPageSize();

            return searchModel;
        }

        /// <summary>
        /// Prepare product availability range search model
        /// </summary>
        /// <param name="searchModel">Product availability range search model</param>
        /// <returns>Product availability range search model</returns>
        protected virtual ProductAvailabilityRangeSearchModel PrepareProductAvailabilityRangeSearchModel(ProductAvailabilityRangeSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //prepare page parameters
            searchModel.SetGridPageSize();

            return searchModel;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Prepare shipping provider search model
        /// </summary>
        /// <param name="searchModel">Shipping provider search model</param>
        /// <returns>Shipping provider search model</returns>
        public virtual Task<ShippingProviderSearchModel> PrepareShippingProviderSearchModelAsync(ShippingProviderSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //prepare page parameters
            searchModel.SetGridPageSize();

            return Task.FromResult(searchModel);
        }

        /// <summary>
        /// Prepare paged shipping provider list model
        /// </summary>
        /// <param name="searchModel">Shipping provider search model</param>
        /// <returns>Shipping provider list model</returns>
        public virtual async Task<ShippingProviderListModel> PrepareShippingProviderListModelAsync(ShippingProviderSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //get shipping providers
            var shippingProviders = (await _shippingPluginManager.LoadAllPluginsAsync()).ToPagedList(searchModel);

            //prepare grid model
            var model = await new ShippingProviderListModel().PrepareToGridAsync(searchModel, shippingProviders, () =>
            {
                return shippingProviders.SelectAwait(async provider =>
                {
                    //fill in model values from the entity
                    var shippingProviderModel = provider.ToPluginModel<ShippingProviderModel>();

                    //fill in additional values (not existing in the entity)
                    shippingProviderModel.IsActive = _shippingPluginManager.IsPluginActive(provider);
                    shippingProviderModel.ConfigurationUrl = provider.GetConfigurationPageUrl();

                    shippingProviderModel.LogoUrl = await _shippingPluginManager.GetPluginLogoUrlAsync(provider);

                    return shippingProviderModel;
                });
            });

            return model;
        }

        /// <summary>
        /// Prepare pickup point provider search model
        /// </summary>
        /// <param name="searchModel">Pickup point provider search model</param>
        /// <returns>Pickup point provider search model</returns>
        public virtual Task<PickupPointProviderSearchModel> PreparePickupPointProviderSearchModelAsync(PickupPointProviderSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //prepare page parameters
            searchModel.SetGridPageSize();

            return Task.FromResult(searchModel);
        }

        /// <summary>
        /// Prepare paged pickup point provider list model
        /// </summary>
        /// <param name="searchModel">Pickup point provider search model</param>
        /// <returns>Pickup point provider list model</returns>
        public virtual async Task<PickupPointProviderListModel> PreparePickupPointProviderListModelAsync(PickupPointProviderSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //get pickup point providers
            var pickupPointProviders = (await _pickupPluginManager.LoadAllPluginsAsync()).ToPagedList(searchModel);

            //prepare grid model
            var model = await new PickupPointProviderListModel().PrepareToGridAsync(searchModel, pickupPointProviders, () =>
            {
                return pickupPointProviders.SelectAwait(async provider =>
                {
                    //fill in model values from the entity
                    var pickupPointProviderModel = provider.ToPluginModel<PickupPointProviderModel>();

                    //fill in additional values (not existing in the entity)
                    pickupPointProviderModel.IsActive = _pickupPluginManager.IsPluginActive(provider);
                    pickupPointProviderModel.ConfigurationUrl = provider.GetConfigurationPageUrl();

                    pickupPointProviderModel.LogoUrl = await _pickupPluginManager.GetPluginLogoUrlAsync(provider);

                    return pickupPointProviderModel;
                });
            });

            return model;
        }

        /// <summary>
        /// Prepare shipping method search model
        /// </summary>
        /// <param name="searchModel">Shipping method search model</param>
        /// <returns>Shipping method search model</returns>
        public virtual Task<ShippingMethodSearchModel> PrepareShippingMethodSearchModelAsync(ShippingMethodSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //prepare page parameters
            searchModel.SetGridPageSize();

            return Task.FromResult(searchModel);
        }

        /// <summary>
        /// Prepare paged shipping method list model
        /// </summary>
        /// <param name="searchModel">Shipping method search model</param>
        /// <returns>Shipping method list model</returns>
        public virtual async Task<ShippingMethodListModel> PrepareShippingMethodListModelAsync(ShippingMethodSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //get shipping methods
            var shippingMethods = (await _shippingService.GetAllShippingMethodsAsync()).ToPagedList(searchModel);

            //prepare grid model
            var model = new ShippingMethodListModel().PrepareToGrid(searchModel, shippingMethods, () =>
            {
                return shippingMethods.Select(method => method.ToModel<ShippingMethodModel>());
            });

            return model;
        }

        /// <summary>
        /// Prepare shipping method model
        /// </summary>
        /// <param name="model">Shipping method model</param>
        /// <param name="shippingMethod">Shipping method</param>
        /// <param name="excludeProperties">Whether to exclude populating of some properties of model</param>
        /// <returns>Shipping method model</returns>
        public virtual async Task<ShippingMethodModel> PrepareShippingMethodModelAsync(ShippingMethodModel model,
            ShippingMethod shippingMethod, bool excludeProperties = false)
        {
            Action<ShippingMethodLocalizedModel, int> localizedModelConfiguration = null;

            if (shippingMethod != null)
            {
                //fill in model values from the entity
                model ??= shippingMethod.ToModel<ShippingMethodModel>();

                //define localized model configuration action
                localizedModelConfiguration = async (locale, languageId) =>
                {
                    locale.Name = await _localizationService.GetLocalizedAsync(shippingMethod, entity => entity.Name, languageId, false, false);
                    locale.Description = await _localizationService.GetLocalizedAsync(shippingMethod, entity => entity.Description, languageId, false, false);
                };
            }

            //prepare localized models
            if (!excludeProperties)
                model.Locales = await _localizedModelFactory.PrepareLocalizedModelsAsync(localizedModelConfiguration);

            return model;
        }

        /// <summary>
        /// Prepare dates and ranges search model
        /// </summary>
        /// <param name="searchModel">Dates and ranges search model</param>
        /// <returns>Dates and ranges search model</returns>
        public virtual Task<DatesRangesSearchModel> PrepareDatesRangesSearchModelAsync(DatesRangesSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //prepare nested search models
            PrepareDeliveryDateSearchModel(searchModel.DeliveryDateSearchModel);
            PrepareProductAvailabilityRangeSearchModel(searchModel.ProductAvailabilityRangeSearchModel);

            return Task.FromResult(searchModel);
        }

        /// <summary>
        /// Prepare paged delivery date list model
        /// </summary>
        /// <param name="searchModel">Delivery date search model</param>
        /// <returns>Delivery date list model</returns>
        public virtual async Task<DeliveryDateListModel> PrepareDeliveryDateListModelAsync(DeliveryDateSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //get delivery dates
            var deliveryDates = (await _dateRangeService.GetAllDeliveryDatesAsync()).ToPagedList(searchModel);

            //prepare grid model
            var model = new DeliveryDateListModel().PrepareToGrid(searchModel, deliveryDates, () =>
            {
                //fill in model values from the entity
                return deliveryDates.Select(date => date.ToModel<DeliveryDateModel>());
            });

            return model;
        }

        /// <summary>
        /// Prepare delivery date model
        /// </summary>
        /// <param name="model">Delivery date model</param>
        /// <param name="deliveryDate">Delivery date</param>
        /// <param name="excludeProperties">Whether to exclude populating of some properties of model</param>
        /// <returns>Delivery date model</returns>
        public virtual async Task<DeliveryDateModel> PrepareDeliveryDateModelAsync(DeliveryDateModel model, DeliveryDate deliveryDate, bool excludeProperties = false)
        {
            Action<DeliveryDateLocalizedModel, int> localizedModelConfiguration = null;

            if (deliveryDate != null)
            {
                //fill in model values from the entity
                model ??= deliveryDate.ToModel<DeliveryDateModel>();

                //define localized model configuration action
                localizedModelConfiguration = async (locale, languageId) =>
                {
                    locale.Name = await _localizationService.GetLocalizedAsync(deliveryDate, entity => entity.Name, languageId, false, false);
                };
            }

            //prepare localized models
            if (!excludeProperties)
                model.Locales = await _localizedModelFactory.PrepareLocalizedModelsAsync(localizedModelConfiguration);

            return model;
        }

        /// <summary>
        /// Prepare paged product availability range list model
        /// </summary>
        /// <param name="searchModel">Product availability range search model</param>
        /// <returns>Product availability range list model</returns>
        public virtual async Task<ProductAvailabilityRangeListModel> PrepareProductAvailabilityRangeListModelAsync(ProductAvailabilityRangeSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //get product availability ranges
            var productAvailabilityRanges = (await _dateRangeService.GetAllProductAvailabilityRangesAsync()).ToPagedList(searchModel);

            //prepare grid model
            var model = new ProductAvailabilityRangeListModel().PrepareToGrid(searchModel, productAvailabilityRanges, () =>
            {
                //fill in model values from the entity
                return productAvailabilityRanges.Select(range => range.ToModel<ProductAvailabilityRangeModel>());
            });

            return model;
        }

        /// <summary>
        /// Prepare product availability range model
        /// </summary>
        /// <param name="model">Product availability range model</param>
        /// <param name="productAvailabilityRange">Product availability range</param>
        /// <param name="excludeProperties">Whether to exclude populating of some properties of model</param>
        /// <returns>Product availability range model</returns>
        public virtual async Task<ProductAvailabilityRangeModel> PrepareProductAvailabilityRangeModelAsync(ProductAvailabilityRangeModel model,
            ProductAvailabilityRange productAvailabilityRange, bool excludeProperties = false)
        {
            Action<ProductAvailabilityRangeLocalizedModel, int> localizedModelConfiguration = null;

            if (productAvailabilityRange != null)
            {
                //fill in model values from the entity
                model ??= productAvailabilityRange.ToModel<ProductAvailabilityRangeModel>();

                //define localized model configuration action
                localizedModelConfiguration = async (locale, languageId) =>
                {
                    locale.Name = await _localizationService.GetLocalizedAsync(productAvailabilityRange, entity => entity.Name, languageId, false, false);
                };
            }

            //prepare localized models
            if (!excludeProperties)
                model.Locales = await _localizedModelFactory.PrepareLocalizedModelsAsync(localizedModelConfiguration);

            return model;
        }

        /// <summary>
        /// Prepare warehouse search model
        /// </summary>
        /// <param name="searchModel">Warehouse search model</param>
        /// <returns>Warehouse search model</returns>
        public virtual Task<WarehouseSearchModel> PrepareWarehouseSearchModelAsync(WarehouseSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //prepare page parameters
            searchModel.SetGridPageSize();

            return Task.FromResult(searchModel);
        }

        /// <summary>
        /// Prepare paged warehouse list model
        /// </summary>
        /// <param name="searchModel">Warehouse search model</param>
        /// <returns>Warehouse list model</returns>
        public virtual async Task<WarehouseListModel> PrepareWarehouseListModelAsync(WarehouseSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //get warehouses
            var warehouses = (await _shippingService.GetAllWarehousesAsync(
                name: searchModel.SearchName))
                .ToPagedList(searchModel);

            //prepare list model
            var model = new WarehouseListModel().PrepareToGrid(searchModel, warehouses, () =>
            {
                //fill in model values from the entity
                return warehouses.Select(warehouse => warehouse.ToModel<WarehouseModel>());
            });

            return model;
        }

        /// <summary>
        /// Prepare warehouse model
        /// </summary>
        /// <param name="model">Warehouse model</param>
        /// <param name="warehouse">Warehouse</param>
        /// <param name="excludeProperties">Whether to exclude populating of some properties of model</param>
        /// <returns>Warehouse model</returns>
        public virtual async Task<WarehouseModel> PrepareWarehouseModelAsync(WarehouseModel model, Warehouse warehouse, bool excludeProperties = false)
        {
            if (warehouse != null)
            {
                //fill in model values from the entity
                if (model == null)
                {
                    model = warehouse.ToModel<WarehouseModel>();
                }
            }

            //prepare address model
            var address = await _addressService.GetAddressByIdAsync(warehouse?.AddressId ?? 0);
            if (!excludeProperties && address != null)
                model.Address = address.ToModel(model.Address);
            await _baseAdminModelFactory.PrepareAddressModelAsync(model.Address, address);

            return model;
        }

        /// <summary>
        /// Prepare shipping method restriction model
        /// </summary>
        /// <param name="model">Shipping method restriction model</param>
        /// <returns>Shipping method restriction model</returns>
        public virtual async Task<ShippingMethodRestrictionModel> PrepareShippingMethodRestrictionModelAsync(ShippingMethodRestrictionModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            var countries = await _countryService.GetAllCountriesAsync(showHidden: true);
            model.AvailableCountries = await countries.SelectAwait(async country =>
            {
                var countryModel = country.ToModel<CountryModel>();
                countryModel.NumberOfStates = (await _stateProvinceService.GetStateProvincesByCountryIdAsync(country.Id))?.Count ?? 0;

                return countryModel;
            }).ToListAsync();

            foreach (var shippingMethod in await _shippingService.GetAllShippingMethodsAsync())
            {
                model.AvailableShippingMethods.Add(shippingMethod.ToModel<ShippingMethodModel>());
                foreach (var country in countries)
                {
                    if (!model.Restricted.ContainsKey(country.Id))
                        model.Restricted[country.Id] = new Dictionary<int, bool>();

                    model.Restricted[country.Id][shippingMethod.Id] = await _shippingService.CountryRestrictionExistsAsync(shippingMethod, country.Id);
                }
            }

            return model;
        }

        #endregion
    }
}