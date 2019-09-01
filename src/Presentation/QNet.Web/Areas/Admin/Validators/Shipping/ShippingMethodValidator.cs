using FluentValidation;
using QNet.Web.Areas.Admin.Models.Shipping;
using QNet.Core.Domain.Shipping;
using QNet.Data;
using QNet.Services.Localization;
using QNet.Web.Framework.Validators;

namespace QNet.Web.Areas.Admin.Validators.Shipping
{
    public partial class ShippingMethodValidator : BaseQNetValidator<ShippingMethodModel>
    {
        public ShippingMethodValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Shipping.Methods.Fields.Name.Required"));

            SetDatabaseValidationRules<ShippingMethod>(dbContext);
        }
    }
}