using FluentValidation;
using QNet.Services.Localization;
using QNet.Web.Framework.Validators;
using QNet.Web.Models.Catalog;

namespace QNet.Web.Validators.Catalog
{
    public partial class ProductEmailAFriendValidator : BaseQNetValidator<ProductEmailAFriendModel>
    {
        public ProductEmailAFriendValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.FriendEmail).NotEmpty().WithMessage(localizationService.GetResource("Products.EmailAFriend.FriendEmail.Required"));
            RuleFor(x => x.FriendEmail).EmailAddress().WithMessage(localizationService.GetResource("Common.WrongEmail"));

            RuleFor(x => x.YourEmailAddress).NotEmpty().WithMessage(localizationService.GetResource("Products.EmailAFriend.YourEmailAddress.Required"));
            RuleFor(x => x.YourEmailAddress).EmailAddress().WithMessage(localizationService.GetResource("Common.WrongEmail"));
        }}
}