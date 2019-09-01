using FluentValidation;
using QNet.Services.Localization;
using QNet.Web.Framework.Validators;
using QNet.Web.Models.Blogs;

namespace QNet.Web.Validators.Blogs
{
    public partial class BlogPostValidator : BaseQNetValidator<BlogPostModel>
    {
        public BlogPostValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.AddNewComment.CommentText).NotEmpty().WithMessage(localizationService.GetResource("Blog.Comments.CommentText.Required")).When(x => x.AddNewComment != null);
        }
    }
}