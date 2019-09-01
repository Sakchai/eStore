using FluentValidation;
using QNet.Web.Areas.Admin.Models.Customers;
using QNet.Core.Domain.Customers;
using QNet.Data;
using QNet.Services.Localization;
using QNet.Web.Framework.Validators;

namespace QNet.Web.Areas.Admin.Validators.Customers
{
    public partial class CustomerRoleValidator : BaseQNetValidator<CustomerRoleModel>
    {
        public CustomerRoleValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Customers.CustomerRoles.Fields.Name.Required"));

            SetDatabaseValidationRules<CustomerRole>(dbContext);
        }
    }
}