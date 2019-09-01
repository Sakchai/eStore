using FluentValidation;
using QNet.Web.Areas.Admin.Models.Orders;
using QNet.Services.Localization;
using QNet.Web.Framework.Validators;

namespace QNet.Web.Areas.Admin.Validators.Orders
{
    public partial class ReturnRequestValidator : BaseQNetValidator<ReturnRequestModel>
    {
        public ReturnRequestValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.ReasonForReturn).NotEmpty().WithMessage(localizationService.GetResource("Admin.ReturnRequests.Fields.ReasonForReturn.Required"));
            RuleFor(x => x.RequestedAction).NotEmpty().WithMessage(localizationService.GetResource("Admin.ReturnRequests.Fields.RequestedAction.Required"));
        }
    }
}