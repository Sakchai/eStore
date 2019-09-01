using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a product search model
    /// </summary>
    public partial class ProductSearchModel : BaseSearchModel
    {
        #region Ctor

        public ProductSearchModel()
        {
            AvailableCategories = new List<SelectListItem>();
            AvailableManufacturers = new List<SelectListItem>();
            AvailableStores = new List<SelectListItem>();
            AvailableWarehouses = new List<SelectListItem>();
            AvailableVendors = new List<SelectListItem>();
            AvailableProductTypes = new List<SelectListItem>();
            AvailablePublishedOptions = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        [QNetResourceDisplayName("Admin.Catalog.Products.List.SearchProductName")]
        public string SearchProductName { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.List.SearchCategory")]
        public int SearchCategoryId { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.List.SearchIncludeSubCategories")]
        public bool SearchIncludeSubCategories { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.List.SearchManufacturer")]
        public int SearchManufacturerId { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.List.SearchStore")]
        public int SearchStoreId { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.List.SearchVendor")]
        public int SearchVendorId { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.List.SearchWarehouse")]
        public int SearchWarehouseId { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.List.SearchProductType")]
        public int SearchProductTypeId { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.List.SearchPublished")]
        public int SearchPublishedId { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.List.GoDirectlyToSku")]
        public string GoDirectlyToSku { get; set; }

        public bool IsLoggedInAsVendor { get; set; }

        public bool AllowVendorsToImportProducts { get; set; }

        public bool HideStoresList { get; set; }

        public IList<SelectListItem> AvailableCategories { get; set; }

        public IList<SelectListItem> AvailableManufacturers { get; set; }

        public IList<SelectListItem> AvailableStores { get; set; }

        public IList<SelectListItem> AvailableWarehouses { get; set; }

        public IList<SelectListItem> AvailableVendors { get; set; }

        public IList<SelectListItem> AvailableProductTypes { get; set; }

        public IList<SelectListItem> AvailablePublishedOptions { get; set; }

        #endregion
    }
}