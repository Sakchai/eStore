using FluentValidation;
using QNet.Web.Areas.Admin.Models.Templates;
using QNet.Services.Localization;
using QNet.Web.Framework.Validators;

namespace QNet.Web.Areas.Admin.Validators.Templates
{
    public partial class ManufacturerTemplateValidator : BaseQNetValidator<ManufacturerTemplateModel>
    {
        public ManufacturerTemplateValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.System.Templates.Manufacturer.Name.Required"));
            RuleFor(x => x.ViewPath).NotEmpty().WithMessage(localizationService.GetResource("Admin.System.Templates.Manufacturer.ViewPath.Required"));
        }
    }
}