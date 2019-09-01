using FluentValidation;
using QNet.Services.Localization;
using QNet.Web.Areas.Admin.Models.Polls;
using QNet.Web.Framework.Validators;

namespace QNet.Web.Areas.Admin.Validators.Polls
{
    public partial class PollAnswerValidator : BaseQNetValidator<PollAnswerModel>
    {
        public PollAnswerValidator(ILocalizationService localizationService)
        {
            //if validation without this set rule is applied, in this case nothing will be validated
            //it's used to prevent auto-validation of child models
            RuleSet(QNetValidatorDefaults.ValidationRuleSet, () =>
            {
                RuleFor(model => model.Name)
                    .NotEmpty()
                    .WithMessage(localizationService.GetResource("Admin.ContentManagement.Polls.Answers.Fields.Name.Required"));
            });
        }
    }
}