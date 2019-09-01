using FluentValidation;
using QNet.Web.Areas.Admin.Models.Messages;
using QNet.Core.Domain.Messages;
using QNet.Data;
using QNet.Services.Localization;
using QNet.Web.Framework.Validators;

namespace QNet.Web.Areas.Admin.Validators.Messages
{
    public partial class MessageTemplateValidator : BaseQNetValidator<MessageTemplateModel>
    {
        public MessageTemplateValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Subject).NotEmpty().WithMessage(localizationService.GetResource("Admin.ContentManagement.MessageTemplates.Fields.Subject.Required"));
            RuleFor(x => x.Body).NotEmpty().WithMessage(localizationService.GetResource("Admin.ContentManagement.MessageTemplates.Fields.Body.Required"));

            SetDatabaseValidationRules<MessageTemplate>(dbContext);
        }
    }
}