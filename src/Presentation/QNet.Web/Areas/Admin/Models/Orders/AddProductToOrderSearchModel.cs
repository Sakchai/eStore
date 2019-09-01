using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Orders
{
    /// <summary>
    /// Represents a product search model to add to the order
    /// </summary>
    public partial class AddProductToOrderSearchModel : BaseSearchModel
    {
        #region Ctor

        public AddProductToOrderSearchModel()
        {
            AvailableCategories = new List<SelectListItem>();
            AvailableManufacturers = new List<SelectListItem>();
            AvailableProductTypes = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        [QNetResourceDisplayName("Admin.Catalog.Products.List.SearchProductName")]
        public string SearchProductName { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.List.SearchCategory")]
        public int SearchCategoryId { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.List.SearchManufacturer")]
        public int SearchManufacturerId { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.List.SearchProductType")]
        public int SearchProductTypeId { get; set; }

        public IList<SelectListItem> AvailableCategories { get; set; }

        public IList<SelectListItem> AvailableManufacturers { get; set; }

        public IList<SelectListItem> AvailableProductTypes { get; set; }

        public int OrderId { get; set; }

        #endregion
    }
}