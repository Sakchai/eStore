using FluentValidation;
using QNet.Core.Domain.Customers;
using QNet.Services.Localization;
using QNet.Web.Framework.Validators;
using QNet.Web.Models.Customer;

namespace QNet.Web.Validators.Customer
{
    public partial class LoginValidator : BaseQNetValidator<LoginModel>
    {
        public LoginValidator(ILocalizationService localizationService, CustomerSettings customerSettings)
        {
            if (!customerSettings.UsernamesEnabled)
            {
                //login by email
                RuleFor(x => x.Email).NotEmpty().WithMessage(localizationService.GetResource("Account.Login.Fields.Email.Required"));
                RuleFor(x => x.Email).EmailAddress().WithMessage(localizationService.GetResource("Common.WrongEmail"));
            }
        }
    }
}