using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using QNet.Core.Domain.Catalog;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Orders
{
    /// <summary>
    /// Represents a checkout attribute model
    /// </summary>
    public partial class CheckoutAttributeModel : BaseQNetEntityModel, 
        ILocalizedModel<CheckoutAttributeLocalizedModel>, IStoreMappingSupportedModel
    {
        #region Ctor

        public CheckoutAttributeModel()
        {
            Locales = new List<CheckoutAttributeLocalizedModel>();
            AvailableTaxCategories = new List<SelectListItem>();
            ConditionModel = new ConditionModel();
            SelectedStoreIds = new List<int>();
            AvailableStores = new List<SelectListItem>();
            CheckoutAttributeValueSearchModel = new CheckoutAttributeValueSearchModel();
        }

        #endregion

        #region Properties

        [QNetResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Fields.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Fields.TextPrompt")]
        public string TextPrompt { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Fields.IsRequired")]
        public bool IsRequired { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Fields.ShippableProductRequired")]
        public bool ShippableProductRequired { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Fields.IsTaxExempt")]
        public bool IsTaxExempt { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Fields.TaxCategory")]
        public int TaxCategoryId { get; set; }
        public IList<SelectListItem> AvailableTaxCategories { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Fields.AttributeControlType")]
        public int AttributeControlTypeId { get; set; }
        [QNetResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Fields.AttributeControlType")]
        public string AttributeControlTypeName { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Fields.MinLength")]
        [UIHint("Int32Nullable")]
        public int? ValidationMinLength { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Fields.MaxLength")]
        [UIHint("Int32Nullable")]
        public int? ValidationMaxLength { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Fields.FileAllowedExtensions")]
        public string ValidationFileAllowedExtensions { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Fields.FileMaximumSize")]
        [UIHint("Int32Nullable")]
        public int? ValidationFileMaximumSize { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Fields.DefaultValue")]
        public string DefaultValue { get; set; }

        public IList<CheckoutAttributeLocalizedModel> Locales { get; set; }

        //condition
        public bool ConditionAllowed { get; set; }
        public ConditionModel ConditionModel { get; set; }

        //store mapping
        [QNetResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Fields.LimitedToStores")]
        public IList<int> SelectedStoreIds { get; set; }
        public IList<SelectListItem> AvailableStores { get; set; }

        public CheckoutAttributeValueSearchModel CheckoutAttributeValueSearchModel { get; set; }

        #endregion
    }

    public partial class ConditionModel : BaseQNetEntityModel
    {
        public ConditionModel()
        {
            ConditionAttributes = new List<AttributeConditionModel>();
        }

        [QNetResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Condition.EnableCondition")]
        public bool EnableCondition { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Condition.Attributes")]
        public int SelectedAttributeId { get; set; }

        public IList<AttributeConditionModel> ConditionAttributes { get; set; }
    }

    public partial class AttributeConditionModel : BaseQNetEntityModel
    {
        public string Name { get; set; }

        public AttributeControlType AttributeControlType { get; set; }

        public IList<SelectListItem> Values { get; set; }

        public string SelectedValueId { get; set; }
    }

    public partial class CheckoutAttributeLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Fields.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Fields.TextPrompt")]
        public string TextPrompt { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Fields.DefaultValue")]
        public string DefaultValue { get; set; }
    }
}