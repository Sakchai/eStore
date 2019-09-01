using FluentValidation;
using QNet.Core.Domain.Catalog;
using QNet.Data;
using QNet.Services.Localization;
using QNet.Web.Areas.Admin.Models.Catalog;
using QNet.Web.Framework.Validators;

namespace QNet.Web.Areas.Admin.Validators.Catalog
{
    /// <summary>
    /// Represent a review type validator
    /// </summary>
    public partial class ReviewTypeValidator : BaseQNetValidator<ReviewTypeModel>
    {
        public ReviewTypeValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Settings.ReviewType.Fields.Name.Required"));
            RuleFor(x => x.Description).NotEmpty().WithMessage(localizationService.GetResource("Admin.Settings.ReviewType.Fields.Description.Required"));

            SetDatabaseValidationRules<ReviewType>(dbContext);
        }
    }
}
