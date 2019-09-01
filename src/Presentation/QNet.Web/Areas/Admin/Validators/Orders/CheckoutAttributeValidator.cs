using FluentValidation;
using QNet.Web.Areas.Admin.Models.Orders;
using QNet.Core.Domain.Orders;
using QNet.Data;
using QNet.Services.Localization;
using QNet.Web.Framework.Validators;

namespace QNet.Web.Areas.Admin.Validators.Orders
{
    public partial class CheckoutAttributeValidator : BaseQNetValidator<CheckoutAttributeModel>
    {
        public CheckoutAttributeValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Catalog.Attributes.CheckoutAttributes.Fields.Name.Required"));

            SetDatabaseValidationRules<CheckoutAttribute>(dbContext);
        }
    }
}