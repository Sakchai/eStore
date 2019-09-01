using FluentValidation;
using QNet.Web.Areas.Admin.Models.Blogs;
using QNet.Core.Domain.Blogs;
using QNet.Data;
using QNet.Services.Localization;
using QNet.Services.Seo;
using QNet.Web.Framework.Validators;

namespace QNet.Web.Areas.Admin.Validators.Blogs
{
    public partial class BlogPostValidator : BaseQNetValidator<BlogPostModel>
    {
        public BlogPostValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage(localizationService.GetResource("Admin.ContentManagement.Blog.BlogPosts.Fields.Title.Required"));

            RuleFor(x => x.Body)
                .NotEmpty()
                .WithMessage(localizationService.GetResource("Admin.ContentManagement.Blog.BlogPosts.Fields.Body.Required"));

            //blog tags should not contain dots
            //current implementation does not support it because it can be handled as file extension
            RuleFor(x => x.Tags)
                .Must(x => x == null || !x.Contains("."))
                .WithMessage(localizationService.GetResource("Admin.ContentManagement.Blog.BlogPosts.Fields.Tags.NoDots"));

            RuleFor(x => x.SeName).Length(0, QNetSeoDefaults.SearchEngineNameLength)
                .WithMessage(string.Format(localizationService.GetResource("Admin.SEO.SeName.MaxLengthValidation"), QNetSeoDefaults.SearchEngineNameLength));

            SetDatabaseValidationRules<BlogPost>(dbContext);
        }
    }
}