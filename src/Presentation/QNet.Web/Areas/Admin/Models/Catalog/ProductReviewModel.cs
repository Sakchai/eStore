using System;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a product review model
    /// </summary>
    public partial class ProductReviewModel : BaseQNetEntityModel
    {
        #region Ctor

        public ProductReviewModel()
        {
            ProductReviewReviewTypeMappingSearchModel = new ProductReviewReviewTypeMappingSearchModel();            
        }

        #endregion

        #region Properties

        [QNetResourceDisplayName("Admin.Catalog.ProductReviews.Fields.Store")]
        public string StoreName { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.ProductReviews.Fields.Product")]
        public int ProductId { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.ProductReviews.Fields.Product")]
        public string ProductName { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.ProductReviews.Fields.Customer")]
        public int CustomerId { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.ProductReviews.Fields.Customer")]
        public string CustomerInfo { get; set; }
        
        [QNetResourceDisplayName("Admin.Catalog.ProductReviews.Fields.Title")]
        public string Title { get; set; }
        
        [QNetResourceDisplayName("Admin.Catalog.ProductReviews.Fields.ReviewText")]
        public string ReviewText { get; set; }
        
        [QNetResourceDisplayName("Admin.Catalog.ProductReviews.Fields.ReplyText")]
        public string ReplyText { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.ProductReviews.Fields.Rating")]
        public int Rating { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.ProductReviews.Fields.IsApproved")]
        public bool IsApproved { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.ProductReviews.Fields.CreatedOn")]
        public DateTime CreatedOn { get; set; }

        //vendor
        public bool IsLoggedInAsVendor { get; set; }

        public ProductReviewReviewTypeMappingSearchModel ProductReviewReviewTypeMappingSearchModel { get; set; }

        #endregion
    }
}