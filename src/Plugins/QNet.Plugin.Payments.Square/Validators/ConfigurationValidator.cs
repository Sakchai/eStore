using System;
using FluentValidation;
using QNet.Plugin.Payments.Square.Models;
using QNet.Web.Framework.Validators;

namespace QNet.Plugin.Payments.Square.Validators
{
    /// <summary>
    /// Represents validator of configuration model
    /// </summary>
    public class ConfigurationModelValidator : BaseQNetValidator<ConfigurationModel>
    {
        #region Ctor

        public ConfigurationModelValidator()
        {
            //rules for sandbox credentials
            RuleFor(model => model.SandboxAccessToken)
                .Must((model, name) => !string.IsNullOrEmpty(model.SandboxAccessToken))
                .WithMessage("Sandbox access token should not be empty")
                .When(model => model.UseSandbox);

            RuleFor(model => model.SandboxApplicationId)
                .Must((model, name) => model.SandboxApplicationId?.StartsWith(SquarePaymentDefaults.SandboxCredentialsPrefix, StringComparison.InvariantCultureIgnoreCase) ?? false)
                .WithMessage($"Sandbox application ID should start with '{SquarePaymentDefaults.SandboxCredentialsPrefix}'")
                .When(model => model.UseSandbox);
        }

        #endregion
    }
}