using FluentValidation;
using QNet.Web.Areas.Admin.Models.Directory;
using QNet.Core.Domain.Directory;
using QNet.Data;
using QNet.Services.Localization;
using QNet.Web.Framework.Validators;

namespace QNet.Web.Areas.Admin.Validators.Directory
{
    public partial class StateProvinceValidator : BaseQNetValidator<StateProvinceModel>
    {
        public StateProvinceValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Countries.States.Fields.Name.Required"));

            SetDatabaseValidationRules<StateProvince>(dbContext);
        }
    }
}