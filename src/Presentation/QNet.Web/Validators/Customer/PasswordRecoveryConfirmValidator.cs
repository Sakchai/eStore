using FluentValidation;
using QNet.Core.Domain.Customers;
using QNet.Services.Localization;
using QNet.Web.Framework.Validators;
using QNet.Web.Models.Customer;

namespace QNet.Web.Validators.Customer
{
    public partial class PasswordRecoveryConfirmValidator : BaseQNetValidator<PasswordRecoveryConfirmModel>
    {
        public PasswordRecoveryConfirmValidator(ILocalizationService localizationService, CustomerSettings customerSettings)
        {
            RuleFor(x => x.NewPassword).IsPassword(localizationService, customerSettings);            
            RuleFor(x => x.ConfirmNewPassword).NotEmpty().WithMessage(localizationService.GetResource("Account.PasswordRecovery.ConfirmNewPassword.Required"));
            RuleFor(x => x.ConfirmNewPassword).Equal(x => x.NewPassword).WithMessage(localizationService.GetResource("Account.PasswordRecovery.NewPassword.EnteredPasswordsDoNotMatch"));
        }
    }
}