using FluentValidation;
using QNet.Web.Areas.Admin.Models.Polls;
using QNet.Services.Localization;
using QNet.Web.Framework.Validators;

namespace QNet.Web.Areas.Admin.Validators.Polls
{
    public partial class PollValidator : BaseQNetValidator<PollModel>
    {
        public PollValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.ContentManagement.Polls.Fields.Name.Required"));
        }
    }
}