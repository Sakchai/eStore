using FluentValidation;
using QNet.Web.Areas.Admin.Models.Forums;
using QNet.Core.Domain.Forums;
using QNet.Data;
using QNet.Services.Localization;
using QNet.Web.Framework.Validators;

namespace QNet.Web.Areas.Admin.Validators.Forums
{
    public partial class ForumGroupValidator : BaseQNetValidator<ForumGroupModel>
    {
        public ForumGroupValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.ContentManagement.Forums.ForumGroup.Fields.Name.Required"));

            SetDatabaseValidationRules<ForumGroup>(dbContext);
        }
    }
}