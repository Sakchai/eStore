using FluentValidation;
using QNet.Web.Areas.Admin.Models.Directory;
using QNet.Core.Domain.Directory;
using QNet.Data;
using QNet.Services.Localization;
using QNet.Web.Framework.Validators;

namespace QNet.Web.Areas.Admin.Validators.Directory
{
    public partial class MeasureWeightValidator : BaseQNetValidator<MeasureWeightModel>
    {
        public MeasureWeightValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Shipping.Measures.Weights.Fields.Name.Required"));
            RuleFor(x => x.SystemKeyword).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Shipping.Measures.Weights.Fields.SystemKeyword.Required"));

            SetDatabaseValidationRules<MeasureWeight>(dbContext);
        }
    }
}