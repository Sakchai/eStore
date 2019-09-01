﻿using System.Collections.Generic;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a specification attribute option model
    /// </summary>
    public partial class SpecificationAttributeOptionModel : BaseQNetEntityModel, ILocalizedModel<SpecificationAttributeOptionLocalizedModel>
    {
        #region Ctor

        public SpecificationAttributeOptionModel()
        {
            Locales = new List<SpecificationAttributeOptionLocalizedModel>();
        }

        #endregion

        #region Properties

        public int SpecificationAttributeId { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Attributes.SpecificationAttributes.Options.Fields.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Attributes.SpecificationAttributes.Options.Fields.ColorSquaresRgb")]
        public string ColorSquaresRgb { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Attributes.SpecificationAttributes.Options.Fields.EnableColorSquaresRgb")]
        public bool EnableColorSquaresRgb { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Attributes.SpecificationAttributes.Options.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Attributes.SpecificationAttributes.Options.Fields.NumberOfAssociatedProducts")]
        public int NumberOfAssociatedProducts { get; set; }
        
        public IList<SpecificationAttributeOptionLocalizedModel> Locales { get; set; }

        #endregion
    }

    public partial class SpecificationAttributeOptionLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Attributes.SpecificationAttributes.Options.Fields.Name")]
        public string Name { get; set; }
    }    
}