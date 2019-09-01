using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a product review and review type mapping model
    /// </summary>
    public class ProductReviewReviewTypeMappingModel : BaseQNetEntityModel
    {
        #region Properties

        public int ProductReviewId { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.ProductReviewsExt.Fields.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.ProductReviewsExt.Fields.Description")]
        public string Description { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.ProductReviewsExt.Fields.VisibleToAllCustomers")]
        public bool VisibleToAllCustomers { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.ProductReviewsExt.Fields.Rating")]
        public int Rating { get; set; }

        #endregion
    }
}
