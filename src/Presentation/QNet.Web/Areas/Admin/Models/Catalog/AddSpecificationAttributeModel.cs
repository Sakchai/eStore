using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a model for adding or editing a specification attribute
    /// </summary>
    public partial class AddSpecificationAttributeModel : BaseQNetEntityModel, ILocalizedModel<AddSpecificationAttributeLocalizedModel>
    {
        #region Ctor

        public AddSpecificationAttributeModel()
        {
            AvailableOptions = new List<SelectListItem>();
            AvailableAttributes = new List<SelectListItem>();
            ShowOnProductPage = true;
            AttributeName = string.Empty;
            AttributeTypeName = string.Empty;
            Value = string.Empty;
            ValueRaw = string.Empty;
            Locales = new List<AddSpecificationAttributeLocalizedModel>();
        }

        #endregion

        #region Properties

        public int SpecificationId { get; set; }

        public int AttributeTypeId { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.SpecificationAttributes.Fields.AttributeType")]
        public string AttributeTypeName { get; set; }

        public int AttributeId { get; set; }

        public int ProductId { get; set; }

        public IList<SelectListItem> AvailableAttributes { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.SpecificationAttributes.Fields.SpecificationAttribute")]
        public string AttributeName { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.SpecificationAttributes.Fields.CustomValue")]
        public string ValueRaw { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.SpecificationAttributes.Fields.CustomValue")]
        public string Value { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.SpecificationAttributes.Fields.AllowFiltering")]
        public bool AllowFiltering { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.SpecificationAttributes.Fields.ShowOnProductPage")]
        public bool ShowOnProductPage { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.SpecificationAttributes.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.SpecificationAttributes.Fields.SpecificationAttributeOption")]
        public int SpecificationAttributeOptionId { get; set; }

        public IList<SelectListItem> AvailableOptions { get; set; }

        public IList<AddSpecificationAttributeLocalizedModel> Locales { get; set; }

        #endregion
    }
}