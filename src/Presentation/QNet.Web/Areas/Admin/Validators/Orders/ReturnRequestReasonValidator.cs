using FluentValidation;
using QNet.Web.Areas.Admin.Models.Orders;
using QNet.Services.Localization;
using QNet.Web.Framework.Validators;

namespace QNet.Web.Areas.Admin.Validators.Orders
{
    public partial class ReturnRequestReasonValidator : BaseQNetValidator<ReturnRequestReasonModel>
    {
        public ReturnRequestReasonValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Settings.Order.ReturnRequestReasons.Name.Required"));
        }
    }
}