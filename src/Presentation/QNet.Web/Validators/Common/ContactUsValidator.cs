using FluentValidation;
using QNet.Core.Domain.Common;
using QNet.Services.Localization;
using QNet.Web.Framework.Validators;
using QNet.Web.Models.Common;

namespace QNet.Web.Validators.Common
{
    public partial class ContactUsValidator : BaseQNetValidator<ContactUsModel>
    {
        public ContactUsValidator(ILocalizationService localizationService, CommonSettings commonSettings)
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage(localizationService.GetResource("ContactUs.Email.Required"));
            RuleFor(x => x.Email).EmailAddress().WithMessage(localizationService.GetResource("Common.WrongEmail"));
            RuleFor(x => x.FullName).NotEmpty().WithMessage(localizationService.GetResource("ContactUs.FullName.Required"));
            if (commonSettings.SubjectFieldOnContactUsForm)
            {
                RuleFor(x => x.Subject).NotEmpty().WithMessage(localizationService.GetResource("ContactUs.Subject.Required"));
            }
            RuleFor(x => x.Enquiry).NotEmpty().WithMessage(localizationService.GetResource("ContactUs.Enquiry.Required"));
        }
    }
}