using FluentValidation;
using QNet.Web.Areas.Admin.Models.Messages;
using QNet.Core.Domain.Messages;
using QNet.Data;
using QNet.Services.Localization;
using QNet.Web.Framework.Validators;

namespace QNet.Web.Areas.Admin.Validators.Messages
{
    public partial class NewsLetterSubscriptionValidator : BaseQNetValidator<NewsletterSubscriptionModel>
    {
        public NewsLetterSubscriptionValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage(localizationService.GetResource("Admin.Promotions.NewsLetterSubscriptions.Fields.Email.Required"));
            RuleFor(x => x.Email).EmailAddress().WithMessage(localizationService.GetResource("Admin.Common.WrongEmail"));

            SetDatabaseValidationRules<NewsLetterSubscription>(dbContext);
        }
    }
}