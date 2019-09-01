using FluentValidation;
using QNet.Web.Areas.Admin.Models.News;
using QNet.Core.Domain.News;
using QNet.Data;
using QNet.Services.Localization;
using QNet.Services.Seo;
using QNet.Web.Framework.Validators;

namespace QNet.Web.Areas.Admin.Validators.News
{
    public partial class NewsItemValidator : BaseQNetValidator<NewsItemModel>
    {
        public NewsItemValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage(localizationService.GetResource("Admin.ContentManagement.News.NewsItems.Fields.Title.Required"));

            RuleFor(x => x.Short).NotEmpty().WithMessage(localizationService.GetResource("Admin.ContentManagement.News.NewsItems.Fields.Short.Required"));

            RuleFor(x => x.Full).NotEmpty().WithMessage(localizationService.GetResource("Admin.ContentManagement.News.NewsItems.Fields.Full.Required"));

            RuleFor(x => x.SeName).Length(0, QNetSeoDefaults.SearchEngineNameLength)
                .WithMessage(string.Format(localizationService.GetResource("Admin.SEO.SeName.MaxLengthValidation"), QNetSeoDefaults.SearchEngineNameLength));

            SetDatabaseValidationRules<NewsItem>(dbContext);
        }
    }
}