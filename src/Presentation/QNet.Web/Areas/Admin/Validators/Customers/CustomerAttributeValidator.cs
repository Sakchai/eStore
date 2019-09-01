using FluentValidation;
using QNet.Web.Areas.Admin.Models.Customers;
using QNet.Core.Domain.Customers;
using QNet.Data;
using QNet.Services.Localization;
using QNet.Web.Framework.Validators;

namespace QNet.Web.Areas.Admin.Validators.Customers
{
    public partial class CustomerAttributeValidator : BaseQNetValidator<CustomerAttributeModel>
    {
        public CustomerAttributeValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Customers.CustomerAttributes.Fields.Name.Required"));

            SetDatabaseValidationRules<CustomerAttribute>(dbContext);
        }
    }
}