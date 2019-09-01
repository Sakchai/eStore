using FluentValidation;
using QNet.Services.Localization;
using QNet.Web.Framework.Validators;
using QNet.Web.Models.Vendors;

namespace QNet.Web.Validators.Vendors
{
    public partial class VendorInfoValidator : BaseQNetValidator<VendorInfoModel>
    {
        public VendorInfoValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Account.VendorInfo.Name.Required"));

            RuleFor(x => x.Email).NotEmpty().WithMessage(localizationService.GetResource("Account.VendorInfo.Email.Required"));
            RuleFor(x => x.Email).EmailAddress().WithMessage(localizationService.GetResource("Common.WrongEmail"));
        }
    }
}