using FluentValidation;
using QNet.Services.Localization;
using QNet.Web.Framework.Validators;
using QNet.Web.Models.Customer;

namespace QNet.Web.Validators.Customer
{
    public partial class GiftCardValidator : BaseQNetValidator<CheckGiftCardBalanceModel>
    {
        public GiftCardValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.GiftCardCode).NotEmpty().WithMessage(localizationService.GetResource("CheckGiftCardBalance.GiftCardCouponCode.Empty"));            
        }
    }
}
