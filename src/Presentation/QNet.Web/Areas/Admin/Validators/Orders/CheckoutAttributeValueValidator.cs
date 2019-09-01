using FluentValidation;
using QNet.Web.Areas.Admin.Models.Orders;
using QNet.Core.Domain.Orders;
using QNet.Data;
using QNet.Services.Localization;
using QNet.Web.Framework.Validators;

namespace QNet.Web.Areas.Admin.Validators.Orders
{
    public partial class CheckoutAttributeValueValidator : BaseQNetValidator<CheckoutAttributeValueModel>
    {
        public CheckoutAttributeValueValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Catalog.Attributes.CheckoutAttributes.Values.Fields.Name.Required"));

            SetDatabaseValidationRules<CheckoutAttributeValue>(dbContext);
        }
    }
}