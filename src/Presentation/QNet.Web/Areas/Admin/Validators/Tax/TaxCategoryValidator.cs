using FluentValidation;
using QNet.Web.Areas.Admin.Models.Tax;
using QNet.Core.Domain.Tax;
using QNet.Data;
using QNet.Services.Localization;
using QNet.Web.Framework.Validators;

namespace QNet.Web.Areas.Admin.Validators.Tax
{
    public partial class TaxCategoryValidator : BaseQNetValidator<TaxCategoryModel>
    {
        public TaxCategoryValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Tax.Categories.Fields.Name.Required"));

            SetDatabaseValidationRules<TaxCategory>(dbContext);
        }
    }
}