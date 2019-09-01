using FluentValidation;
using QNet.Web.Areas.Admin.Models.Topics;
using QNet.Core.Domain.Topics;
using QNet.Data;
using QNet.Services.Localization;
using QNet.Services.Seo;
using QNet.Web.Framework.Validators;

namespace QNet.Web.Areas.Admin.Validators.Topics
{
    public partial class TopicValidator : BaseQNetValidator<TopicModel>
    {
        public TopicValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.SeName).Length(0, QNetSeoDefaults.ForumTopicLength)
                .WithMessage(string.Format(localizationService.GetResource("Admin.SEO.SeName.MaxLengthValidation"), QNetSeoDefaults.ForumTopicLength));

            SetDatabaseValidationRules<Topic>(dbContext);
        }
    }
}
