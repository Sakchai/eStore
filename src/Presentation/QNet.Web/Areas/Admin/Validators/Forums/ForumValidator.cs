using FluentValidation;
using QNet.Web.Areas.Admin.Models.Forums;
using QNet.Core.Domain.Forums;
using QNet.Data;
using QNet.Services.Localization;
using QNet.Web.Framework.Validators;

namespace QNet.Web.Areas.Admin.Validators.Forums
{
    public partial class ForumValidator : BaseQNetValidator<ForumModel>
    {
        public ForumValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.ContentManagement.Forums.Forum.Fields.Name.Required"));
            RuleFor(x => x.ForumGroupId).NotEmpty().WithMessage(localizationService.GetResource("Admin.ContentManagement.Forums.Forum.Fields.ForumGroupId.Required"));

            SetDatabaseValidationRules<Forum>(dbContext);
        }
    }
}