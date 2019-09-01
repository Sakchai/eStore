using System.Collections.Generic;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a specification attribute model
    /// </summary>
    public partial class SpecificationAttributeModel : BaseQNetEntityModel, ILocalizedModel<SpecificationAttributeLocalizedModel>
    {
        #region Ctor

        public SpecificationAttributeModel()
        {
            Locales = new List<SpecificationAttributeLocalizedModel>();
            SpecificationAttributeOptionSearchModel = new SpecificationAttributeOptionSearchModel();
            SpecificationAttributeProductSearchModel = new SpecificationAttributeProductSearchModel();
        }

        #endregion

        #region Properties

        [QNetResourceDisplayName("Admin.Catalog.Attributes.SpecificationAttributes.Fields.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Attributes.SpecificationAttributes.Fields.DisplayOrder")]
        public int DisplayOrder {get;set;}

        public IList<SpecificationAttributeLocalizedModel> Locales { get; set; }

        public SpecificationAttributeOptionSearchModel SpecificationAttributeOptionSearchModel { get; set; }

        public SpecificationAttributeProductSearchModel SpecificationAttributeProductSearchModel { get; set; }

        #endregion
    }
}