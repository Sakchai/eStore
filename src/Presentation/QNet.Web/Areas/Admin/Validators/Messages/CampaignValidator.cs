using FluentValidation;
using QNet.Web.Areas.Admin.Models.Messages;
using QNet.Services.Localization;
using QNet.Web.Framework.Validators;

namespace QNet.Web.Areas.Admin.Validators.Messages
{
    public partial class CampaignValidator : BaseQNetValidator<CampaignModel>
    {
        public CampaignValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Promotions.Campaigns.Fields.Name.Required"));

            RuleFor(x => x.Subject).NotEmpty().WithMessage(localizationService.GetResource("Admin.Promotions.Campaigns.Fields.Subject.Required"));

            RuleFor(x => x.Body).NotEmpty().WithMessage(localizationService.GetResource("Admin.Promotions.Campaigns.Fields.Body.Required"));
        }
    }
}