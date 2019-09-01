using FluentValidation;
using QNet.Web.Areas.Admin.Models.Discounts;
using QNet.Core.Domain.Discounts;
using QNet.Data;
using QNet.Services.Localization;
using QNet.Web.Framework.Validators;

namespace QNet.Web.Areas.Admin.Validators.Discounts
{
    public partial class DiscountValidator : BaseQNetValidator<DiscountModel>
    {
        public DiscountValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Promotions.Discounts.Fields.Name.Required"));

            SetDatabaseValidationRules<Discount>(dbContext);
        }
    }
}