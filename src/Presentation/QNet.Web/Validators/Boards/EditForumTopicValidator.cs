using FluentValidation;
using QNet.Services.Localization;
using QNet.Web.Framework.Validators;
using QNet.Web.Models.Boards;

namespace QNet.Web.Validators.Boards
{
    public partial class EditForumTopicValidator : BaseQNetValidator<EditForumTopicModel>
    {
        public EditForumTopicValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Subject).NotEmpty().WithMessage(localizationService.GetResource("Forum.TopicSubjectCannotBeEmpty"));
            RuleFor(x => x.Text).NotEmpty().WithMessage(localizationService.GetResource("Forum.TextCannotBeEmpty"));
        }
    }
}