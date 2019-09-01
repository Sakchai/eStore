using FluentValidation;
using QNet.Services.Localization;
using QNet.Web.Framework.Validators;
using QNet.Web.Models.ShoppingCart;

namespace QNet.Web.Validators.ShoppingCart
{
    public partial class WishlistEmailAFriendValidator : BaseQNetValidator<WishlistEmailAFriendModel>
    {
        public WishlistEmailAFriendValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.FriendEmail).NotEmpty().WithMessage(localizationService.GetResource("Wishlist.EmailAFriend.FriendEmail.Required"));
            RuleFor(x => x.FriendEmail).EmailAddress().WithMessage(localizationService.GetResource("Common.WrongEmail"));

            RuleFor(x => x.YourEmailAddress).NotEmpty().WithMessage(localizationService.GetResource("Wishlist.EmailAFriend.YourEmailAddress.Required"));
            RuleFor(x => x.YourEmailAddress).EmailAddress().WithMessage(localizationService.GetResource("Common.WrongEmail"));
        }
    }
}