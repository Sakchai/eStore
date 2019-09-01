using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Models.Catalog
{
    public partial class SearchModel : BaseQNetModel
    {
        public SearchModel()
        {
            PagingFilteringContext = new CatalogPagingFilteringModel();
            Products = new List<ProductOverviewModel>();

            AvailableCategories = new List<SelectListItem>();
            AvailableManufacturers = new List<SelectListItem>();
            AvailableVendors = new List<SelectListItem>();
        }

        public string Warning { get; set; }

        public bool NoResults { get; set; }

        /// <summary>
        /// Query string
        /// </summary>
        [QNetResourceDisplayName("Search.SearchTerm")]
        public string q { get; set; }

        /// <summary>
        /// Category ID
        /// </summary>
        [QNetResourceDisplayName("Search.Category")]
        public int cid { get; set; }

        [QNetResourceDisplayName("Search.IncludeSubCategories")]
        public bool isc { get; set; }

        /// <summary>
        /// Manufacturer ID
        /// </summary>
        [QNetResourceDisplayName("Search.Manufacturer")]
        public int mid { get; set; }

        /// <summary>
        /// Vendor ID
        /// </summary>
        [QNetResourceDisplayName("Search.Vendor")]
        public int vid { get; set; }

        /// <summary>
        /// Price - From 
        /// </summary>
        public string pf { get; set; }

        /// <summary>
        /// Price - To
        /// </summary>
        public string pt { get; set; }

        /// <summary>
        /// A value indicating whether to search in descriptions
        /// </summary>
        [QNetResourceDisplayName("Search.SearchInDescriptions")]
        public bool sid { get; set; }

        /// <summary>
        /// A value indicating whether "advanced search" is enabled
        /// </summary>
        [QNetResourceDisplayName("Search.AdvancedSearch")]
        public bool adv { get; set; }

        /// <summary>
        /// A value indicating whether "allow search by vendor" is enabled
        /// </summary>
        public bool asv { get; set; }

        public IList<SelectListItem> AvailableCategories { get; set; }
        public IList<SelectListItem> AvailableManufacturers { get; set; }
        public IList<SelectListItem> AvailableVendors { get; set; }


        public CatalogPagingFilteringModel PagingFilteringContext { get; set; }
        public IList<ProductOverviewModel> Products { get; set; }

        #region Nested classes

        public class CategoryModel : BaseQNetEntityModel
        {
            public string Breadcrumb { get; set; }
        }

        #endregion
    }
}