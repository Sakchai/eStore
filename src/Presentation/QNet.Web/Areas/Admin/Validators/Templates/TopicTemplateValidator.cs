using FluentValidation;
using QNet.Web.Areas.Admin.Models.Templates;
using QNet.Services.Localization;
using QNet.Web.Framework.Validators;

namespace QNet.Web.Areas.Admin.Validators.Templates
{
    public partial class TopicTemplateValidator : BaseQNetValidator<TopicTemplateModel>
    {
        public TopicTemplateValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.System.Templates.Topic.Name.Required"));
            RuleFor(x => x.ViewPath).NotEmpty().WithMessage(localizationService.GetResource("Admin.System.Templates.Topic.ViewPath.Required"));
        }
    }
}