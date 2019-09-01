using FluentValidation;
using QNet.Web.Areas.Admin.Models.Catalog;
using QNet.Core;
using QNet.Core.Domain.Catalog;
using QNet.Data;
using QNet.Services.Localization;
using QNet.Web.Framework.Validators;

namespace QNet.Web.Areas.Admin.Validators.Catalog
{
    public partial class ProductReviewValidator : BaseQNetValidator<ProductReviewModel>
    {
        public ProductReviewValidator(ILocalizationService localizationService, IDbContext dbContext, IWorkContext workContext)
        {
            var isLoggedInAsVendor = workContext.CurrentVendor != null;
            //vendor can edit "Reply text" only
            if (!isLoggedInAsVendor)
            {
                RuleFor(x => x.Title).NotEmpty().WithMessage(localizationService.GetResource("Admin.Catalog.ProductReviews.Fields.Title.Required"));
                RuleFor(x => x.ReviewText).NotEmpty().WithMessage(localizationService.GetResource("Admin.Catalog.ProductReviews.Fields.ReviewText.Required"));
            }

            SetDatabaseValidationRules<ProductReview>(dbContext);
        }
    }
}