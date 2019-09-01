using FluentValidation;
using QNet.Web.Areas.Admin.Models.Messages;
using QNet.Core.Domain.Messages;
using QNet.Data;
using QNet.Services.Localization;
using QNet.Web.Framework.Validators;

namespace QNet.Web.Areas.Admin.Validators.Messages
{
    public partial class EmailAccountValidator : BaseQNetValidator<EmailAccountModel>
    {
        public EmailAccountValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Email).EmailAddress().WithMessage(localizationService.GetResource("Admin.Common.WrongEmail"));
            
            RuleFor(x => x.DisplayName).NotEmpty();

            SetDatabaseValidationRules<EmailAccount>(dbContext);
        }
    }
}