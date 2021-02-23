﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Directory;
using Nop.Core.Domain.Orders;
using Nop.Services.Directory;
using Nop.Services.Localization;
using Nop.Services.Orders;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Orders;
using Nop.Web.Framework.Factories;
using Nop.Web.Framework.Models.Extensions;

namespace Nop.Web.Areas.Admin.Factories
{
    /// <summary>
    /// Represents the checkout attribute model factory implementation
    /// </summary>
    public partial class CheckoutAttributeModelFactory : ICheckoutAttributeModelFactory
    {
        #region Fields

        private readonly CurrencySettings _currencySettings;
        private readonly IBaseAdminModelFactory _baseAdminModelFactory;
        private readonly ICheckoutAttributeParser _checkoutAttributeParser;
        private readonly ICheckoutAttributeService _checkoutAttributeService;
        private readonly ICurrencyService _currencyService;
        private readonly ILocalizationService _localizationService;
        private readonly ILocalizedModelFactory _localizedModelFactory;
        private readonly IMeasureService _measureService;
        private readonly IStoreMappingSupportedModelFactory _storeMappingSupportedModelFactory;
        private readonly MeasureSettings _measureSettings;

        #endregion

        #region Ctor

        public CheckoutAttributeModelFactory(CurrencySettings currencySettings,
            IBaseAdminModelFactory baseAdminModelFactory,
            ICheckoutAttributeParser checkoutAttributeParser,
            ICheckoutAttributeService checkoutAttributeService,
            ICurrencyService currencyService,
            ILocalizationService localizationService,
            ILocalizedModelFactory localizedModelFactory,
            IMeasureService measureService,
            IStoreMappingSupportedModelFactory storeMappingSupportedModelFactory,
            MeasureSettings measureSettings)
        {
            _currencySettings = currencySettings;
            _baseAdminModelFactory = baseAdminModelFactory;
            _checkoutAttributeParser = checkoutAttributeParser;
            _checkoutAttributeService = checkoutAttributeService;
            _currencyService = currencyService;
            _localizationService = localizationService;
            _localizedModelFactory = localizedModelFactory;
            _measureService = measureService;
            _storeMappingSupportedModelFactory = storeMappingSupportedModelFactory;
            _measureSettings = measureSettings;
        }

        #endregion

        #region Utilities

        /// <summary>
        /// Prepare condition attributes model
        /// </summary>
        /// <param name="model">Condition attributes model</param>
        /// <param name="checkoutAttribute">Checkout attribute</param>
        protected virtual async Task PrepareConditionAttributesModelAsync(ConditionModel model, CheckoutAttribute checkoutAttribute)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            if (checkoutAttribute == null)
                throw new ArgumentNullException(nameof(checkoutAttribute));

            model.EnableCondition = !string.IsNullOrEmpty(checkoutAttribute.ConditionAttributeXml);

            //get selected checkout attribute
            var selectedAttribute = (await _checkoutAttributeParser.ParseCheckoutAttributesAsync(checkoutAttribute.ConditionAttributeXml)).FirstOrDefault();
            model.SelectedAttributeId = selectedAttribute?.Id ?? 0;

            //get selected checkout attribute values identifiers
            var selectedValuesIds = await _checkoutAttributeParser
                .ParseCheckoutAttributeValues(checkoutAttribute.ConditionAttributeXml).SelectMany(ta => ta.values.Select(v => v.Id)).ToListAsync();

            //get available condition checkout attributes (ignore this attribute and non-combinable attributes)
            var availableConditionAttributes = (await _checkoutAttributeService.GetAllCheckoutAttributesAsync())
                .Where(attribute => attribute.Id != checkoutAttribute.Id && attribute.CanBeUsedAsCondition());

            model.ConditionAttributes = await availableConditionAttributes.SelectAwait(async attribute => new AttributeConditionModel
            {
                Id = attribute.Id,
                Name = attribute.Name,
                AttributeControlType = attribute.AttributeControlType,
                Values = (await _checkoutAttributeService.GetCheckoutAttributeValuesAsync(attribute.Id)).Select(value => new SelectListItem
                {
                    Text = value.Name,
                    Value = value.Id.ToString(),
                    Selected = selectedAttribute?.Id == attribute.Id && selectedValuesIds.Contains(value.Id)
                }).ToList()
            }).ToListAsync();
        }

        /// <summary>
        /// Prepare checkout attribute value search model
        /// </summary>
        /// <param name="searchModel">Checkout attribute value search model</param>
        /// <param name="checkoutAttribute">Checkout attribute</param>
        /// <returns>Checkout attribute value search model</returns>
        protected virtual CheckoutAttributeValueSearchModel PrepareCheckoutAttributeValueSearchModel(CheckoutAttributeValueSearchModel searchModel,
            CheckoutAttribute checkoutAttribute)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            if (checkoutAttribute == null)
                throw new ArgumentNullException(nameof(checkoutAttribute));

            searchModel.CheckoutAttributeId = checkoutAttribute.Id;

            //prepare page parameters
            searchModel.SetGridPageSize();

            return searchModel;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Prepare checkout attribute search model
        /// </summary>
        /// <param name="searchModel">Checkout attribute search model</param>
        /// <returns>Checkout attribute search model</returns>
        public virtual Task<CheckoutAttributeSearchModel> PrepareCheckoutAttributeSearchModelAsync(CheckoutAttributeSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //prepare page parameters
            searchModel.SetGridPageSize();

            return Task.FromResult(searchModel);
        }

        /// <summary>
        /// Prepare paged checkout attribute list model
        /// </summary>
        /// <param name="searchModel">Checkout attribute search model</param>
        /// <returns>Checkout attribute list model</returns>
        public virtual async Task<CheckoutAttributeListModel> PrepareCheckoutAttributeListModelAsync(CheckoutAttributeSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //get checkout attributes
            var checkoutAttributes = (await _checkoutAttributeService.GetAllCheckoutAttributesAsync()).ToPagedList(searchModel);

            //prepare list model
            var model = await new CheckoutAttributeListModel().PrepareToGridAsync(searchModel, checkoutAttributes, () =>
            {
                return checkoutAttributes.SelectAwait(async attribute =>
                {
                    //fill in model values from the entity
                    var attributeModel = attribute.ToModel<CheckoutAttributeModel>();

                    //fill in additional values (not existing in the entity)
                    attributeModel.AttributeControlTypeName = await _localizationService.GetLocalizedEnumAsync(attribute.AttributeControlType);

                    return attributeModel;
                });
            });

            return model;
        }

        /// <summary>
        /// Prepare checkout attribute model
        /// </summary>
        /// <param name="model">Checkout attribute model</param>
        /// <param name="checkoutAttribute">Checkout attribute</param>
        /// <param name="excludeProperties">Whether to exclude populating of some properties of model</param>
        /// <returns>Checkout attribute model</returns>
        public virtual async Task<CheckoutAttributeModel> PrepareCheckoutAttributeModelAsync(CheckoutAttributeModel model,
            CheckoutAttribute checkoutAttribute, bool excludeProperties = false)
        {
            Action<CheckoutAttributeLocalizedModel, int> localizedModelConfiguration = null;

            if (checkoutAttribute != null)
            {
                //fill in model values from the entity
                model ??= checkoutAttribute.ToModel<CheckoutAttributeModel>();

                //prepare nested search model
                PrepareCheckoutAttributeValueSearchModel(model.CheckoutAttributeValueSearchModel, checkoutAttribute);

                //define localized model configuration action
                localizedModelConfiguration = async (locale, languageId) =>
                {
                    locale.Name = await _localizationService.GetLocalizedAsync(checkoutAttribute, entity => entity.Name, languageId, false, false);
                    locale.TextPrompt = await _localizationService.GetLocalizedAsync(checkoutAttribute, entity => entity.TextPrompt, languageId, false, false);
                    locale.DefaultValue = await _localizationService.GetLocalizedAsync(checkoutAttribute, entity => entity.DefaultValue, languageId, false, false);
                };

                //whether to fill in some of properties
                if (!excludeProperties)
                    model.TaxCategoryId = checkoutAttribute.TaxCategoryId;

                //prepare condition attributes model
                await PrepareConditionAttributesModelAsync(model.ConditionModel, checkoutAttribute);
            }

            //currently any checkout attribute can have condition
            model.ConditionAllowed = true;

            //prepare localized models
            if (!excludeProperties)
                model.Locales = await _localizedModelFactory.PrepareLocalizedModelsAsync(localizedModelConfiguration);

            //prepare available tax categories
            await _baseAdminModelFactory.PrepareTaxCategoriesAsync(model.AvailableTaxCategories);

            //prepare model stores
            await _storeMappingSupportedModelFactory.PrepareModelStoresAsync(model, checkoutAttribute, excludeProperties);

            return model;
        }

        /// <summary>
        /// Prepare paged checkout attribute value list model
        /// </summary>
        /// <param name="searchModel">Checkout attribute value search model</param>
        /// <param name="checkoutAttribute">Checkout attribute</param>
        /// <returns>Checkout attribute value list model</returns>
        public virtual async Task<CheckoutAttributeValueListModel> PrepareCheckoutAttributeValueListModelAsync(CheckoutAttributeValueSearchModel searchModel,
            CheckoutAttribute checkoutAttribute)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            if (checkoutAttribute == null)
                throw new ArgumentNullException(nameof(checkoutAttribute));

            //get checkout attribute values
            var checkoutAttributeValues = (await _checkoutAttributeService
                .GetCheckoutAttributeValuesAsync(checkoutAttribute.Id)).ToPagedList(searchModel);

            //prepare list model
            var model = new CheckoutAttributeValueListModel().PrepareToGrid(searchModel, checkoutAttributeValues, () =>
            {
                return checkoutAttributeValues.Select(value =>
                {
                    //fill in model values from the entity
                    var checkoutAttributeValueModel = value.ToModel<CheckoutAttributeValueModel>();

                    //fill in additional values (not existing in the entity)
                    checkoutAttributeValueModel.Name =
                        checkoutAttribute.AttributeControlType != AttributeControlType.ColorSquares
                            ? value.Name
                            : $"{value.Name} - {value.ColorSquaresRgb}";

                    return checkoutAttributeValueModel;
                });
            });

            return model;
        }

        /// <summary>
        /// Prepare checkout attribute value model
        /// </summary>
        /// <param name="model">Checkout attribute value model</param>
        /// <param name="checkoutAttribute">Checkout attribute</param>
        /// <param name="checkoutAttributeValue">Checkout attribute value</param>
        /// <param name="excludeProperties">Whether to exclude populating of some properties of model</param>
        /// <returns>Checkout attribute value model</returns>
        public virtual async Task<CheckoutAttributeValueModel> PrepareCheckoutAttributeValueModelAsync(CheckoutAttributeValueModel model,
            CheckoutAttribute checkoutAttribute, CheckoutAttributeValue checkoutAttributeValue, bool excludeProperties = false)
        {
            if (checkoutAttribute == null)
                throw new ArgumentNullException(nameof(checkoutAttribute));

            Action<CheckoutAttributeValueLocalizedModel, int> localizedModelConfiguration = null;

            if (checkoutAttributeValue != null)
            {
                //fill in model values from the entity
                model ??= checkoutAttributeValue.ToModel<CheckoutAttributeValueModel>();

                //define localized model configuration action
                localizedModelConfiguration = async (locale, languageId) =>
                {
                    locale.Name = await _localizationService.GetLocalizedAsync(checkoutAttributeValue, entity => entity.Name, languageId, false, false);
                };
            }

            model.CheckoutAttributeId = checkoutAttribute.Id;
            model.PrimaryStoreCurrencyCode = (await _currencyService.GetCurrencyByIdAsync(_currencySettings.PrimaryStoreCurrencyId)).CurrencyCode;
            model.BaseWeightIn = (await _measureService.GetMeasureWeightByIdAsync(_measureSettings.BaseWeightId)).Name;
            model.DisplayColorSquaresRgb = checkoutAttribute.AttributeControlType == AttributeControlType.ColorSquares;

            //prepare localized models
            if (!excludeProperties)
                model.Locales = await _localizedModelFactory.PrepareLocalizedModelsAsync(localizedModelConfiguration);

            return model;
        }

        #endregion
    }
}