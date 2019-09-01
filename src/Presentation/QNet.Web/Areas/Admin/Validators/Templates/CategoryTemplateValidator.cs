using FluentValidation;
using QNet.Web.Areas.Admin.Models.Templates;
using QNet.Services.Localization;
using QNet.Web.Framework.Validators;

namespace QNet.Web.Areas.Admin.Validators.Templates
{
    public partial class CategoryTemplateValidator : BaseQNetValidator<CategoryTemplateModel>
    {
        public CategoryTemplateValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.System.Templates.Category.Name.Required"));
            RuleFor(x => x.ViewPath).NotEmpty().WithMessage(localizationService.GetResource("Admin.System.Templates.Category.ViewPath.Required"));
        }
    }
}