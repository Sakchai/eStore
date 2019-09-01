using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a manufacturer model
    /// </summary>
    public partial class ManufacturerModel : BaseQNetEntityModel, IAclSupportedModel, IDiscountSupportedModel,
        ILocalizedModel<ManufacturerLocalizedModel>, IStoreMappingSupportedModel
    {
        #region Ctor

        public ManufacturerModel()
        {
            if (PageSize < 1)
            {
                PageSize = 5;
            }
            Locales = new List<ManufacturerLocalizedModel>();
            AvailableManufacturerTemplates = new List<SelectListItem>();

            AvailableDiscounts = new List<SelectListItem>();
            SelectedDiscountIds = new List<int>();

            SelectedCustomerRoleIds = new List<int>();
            AvailableCustomerRoles = new List<SelectListItem>();

            SelectedStoreIds = new List<int>();
            AvailableStores = new List<SelectListItem>();

            ManufacturerProductSearchModel = new ManufacturerProductSearchModel();
        }

        #endregion

        #region Properties

        [QNetResourceDisplayName("Admin.Catalog.Manufacturers.Fields.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Manufacturers.Fields.Description")]
        public string Description { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Manufacturers.Fields.ManufacturerTemplate")]
        public int ManufacturerTemplateId { get; set; }

        public IList<SelectListItem> AvailableManufacturerTemplates { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Manufacturers.Fields.MetaKeywords")]
        public string MetaKeywords { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Manufacturers.Fields.MetaDescription")]
        public string MetaDescription { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Manufacturers.Fields.MetaTitle")]
        public string MetaTitle { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Manufacturers.Fields.SeName")]
        public string SeName { get; set; }

        [UIHint("Picture")]
        [QNetResourceDisplayName("Admin.Catalog.Manufacturers.Fields.Picture")]
        public int PictureId { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Manufacturers.Fields.PageSize")]
        public int PageSize { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Manufacturers.Fields.AllowCustomersToSelectPageSize")]
        public bool AllowCustomersToSelectPageSize { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Manufacturers.Fields.PageSizeOptions")]
        public string PageSizeOptions { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Manufacturers.Fields.PriceRanges")]
        public string PriceRanges { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Manufacturers.Fields.Published")]
        public bool Published { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Manufacturers.Fields.Deleted")]
        public bool Deleted { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Manufacturers.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }
        
        public IList<ManufacturerLocalizedModel> Locales { get; set; }

        //ACL (customer roles)
        [QNetResourceDisplayName("Admin.Catalog.Manufacturers.Fields.AclCustomerRoles")]
        public IList<int> SelectedCustomerRoleIds { get; set; }
        public IList<SelectListItem> AvailableCustomerRoles { get; set; }
        
        //store mapping
        [QNetResourceDisplayName("Admin.Catalog.Manufacturers.Fields.LimitedToStores")]
        public IList<int> SelectedStoreIds { get; set; }
        public IList<SelectListItem> AvailableStores { get; set; }

        //discounts
        [QNetResourceDisplayName("Admin.Catalog.Manufacturers.Fields.Discounts")]
        public IList<int> SelectedDiscountIds { get; set; }
        public IList<SelectListItem> AvailableDiscounts { get; set; }

        public ManufacturerProductSearchModel ManufacturerProductSearchModel { get; set; }

        #endregion
    }

    public partial class ManufacturerLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Manufacturers.Fields.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Manufacturers.Fields.Description")]
        public string Description {get;set;}

        [QNetResourceDisplayName("Admin.Catalog.Manufacturers.Fields.MetaKeywords")]
        public string MetaKeywords { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Manufacturers.Fields.MetaDescription")]
        public string MetaDescription { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Manufacturers.Fields.MetaTitle")]
        public string MetaTitle { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Manufacturers.Fields.SeName")]
        public string SeName { get; set; }
    }
}