using FluentValidation;
using QNet.Web.Areas.Admin.Models.Common;
using QNet.Core.Domain.Common;
using QNet.Data;
using QNet.Services.Localization;
using QNet.Web.Framework.Validators;

namespace QNet.Web.Areas.Admin.Validators.Common
{
    public partial class AddressAttributeValidator : BaseQNetValidator<AddressAttributeModel>
    {
        public AddressAttributeValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Address.AddressAttributes.Fields.Name.Required"));

            SetDatabaseValidationRules<AddressAttribute>(dbContext);
        }
    }
}