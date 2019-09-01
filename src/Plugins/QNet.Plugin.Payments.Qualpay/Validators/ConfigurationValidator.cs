using FluentValidation;
using QNet.Plugin.Payments.Qualpay.Models;
using QNet.Services.Localization;
using QNet.Web.Framework.Validators;

namespace QNet.Plugin.Payments.Qualpay.Validators
{
    /// <summary>
    /// Represents configuration model validator
    /// </summary>
    public class ConfigurationValidator : BaseQNetValidator<ConfigurationModel>
    {
        #region Ctor

        public ConfigurationValidator(ILocalizationService localizationService)
        {
            //set validation rules
            RuleFor(model => model.MerchantId)
                .NotEmpty()
                .WithMessage(localizationService.GetResource("Plugins.Payments.Qualpay.Fields.MerchantId.Required"))
                .When(model => !string.IsNullOrEmpty(model.SecurityKey));

            RuleFor(model => model.SecurityKey)
                .NotEmpty()
                .WithMessage(localizationService.GetResource("Plugins.Payments.Qualpay.Fields.SecurityKey.Required"))
                .When(model => !string.IsNullOrEmpty(model.MerchantId));

            RuleFor(model => model.ProfileId)
                .NotEmpty()
                .WithMessage(localizationService.GetResource("Plugins.Payments.Qualpay.Fields.ProfileId.Required"))
                .When(model => model.UseRecurringBilling);
        }

        #endregion
    }
}