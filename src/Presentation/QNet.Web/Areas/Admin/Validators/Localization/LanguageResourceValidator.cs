using FluentValidation;
using QNet.Services.Localization;
using QNet.Web.Areas.Admin.Models.Localization;
using QNet.Web.Framework.Validators;

namespace QNet.Web.Areas.Admin.Validators.Localization
{
    public partial class LanguageResourceValidator : BaseQNetValidator<LocaleResourceModel>
    {
        public LanguageResourceValidator(ILocalizationService localizationService)
        {
            //if validation without this set rule is applied, in this case nothing will be validated
            //it's used to prevent auto-validation of child models
            RuleSet(QNetValidatorDefaults.ValidationRuleSet, () =>
            {
                RuleFor(model => model.ResourceName)
                    .NotEmpty()
                    .WithMessage(localizationService.GetResource("Admin.Configuration.Languages.Resources.Fields.Name.Required"));

                RuleFor(model => model.ResourceValue)
                    .NotEmpty()
                    .WithMessage(localizationService.GetResource("Admin.Configuration.Languages.Resources.Fields.Value.Required"));
            });
        }
    }
}