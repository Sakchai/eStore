using FluentValidation;
using QNet.Services.Localization;
using QNet.Web.Framework.Validators;
using QNet.Web.Models.Vendors;

namespace QNet.Web.Validators.Vendors
{
    public partial class ApplyVendorValidator : BaseQNetValidator<ApplyVendorModel>
    {
        public ApplyVendorValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Vendors.ApplyAccount.Name.Required"));

            RuleFor(x => x.Email).NotEmpty().WithMessage(localizationService.GetResource("Vendors.ApplyAccount.Email.Required"));
            RuleFor(x => x.Email).EmailAddress().WithMessage(localizationService.GetResource("Common.WrongEmail"));
        }
    }
}