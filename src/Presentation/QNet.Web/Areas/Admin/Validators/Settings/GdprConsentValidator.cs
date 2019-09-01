using FluentValidation;
using QNet.Core.Domain.Gdpr;
using QNet.Data;
using QNet.Services.Localization;
using QNet.Web.Areas.Admin.Models.Settings;
using QNet.Web.Framework.Validators;

namespace QNet.Web.Areas.Admin.Validators.Settings
{
    public partial class GdprConsentValidator : BaseQNetValidator<GdprConsentModel>
    {
        public GdprConsentValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Message).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Settings.Gdpr.Consent.Message.Required"));
            RuleFor(x => x.RequiredMessage)
                .NotEmpty()
                .WithMessage(localizationService.GetResource("Admin.Configuration.Settings.Gdpr.Consent.RequiredMessage.Required"))
                .When(x => x.IsRequired);

            SetDatabaseValidationRules<GdprConsent>(dbContext);
        }
    }
}