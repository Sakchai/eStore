using FluentValidation;
using QNet.Web.Areas.Admin.Models.Stores;
using QNet.Core.Domain.Stores;
using QNet.Data;
using QNet.Services.Localization;
using QNet.Web.Framework.Validators;

namespace QNet.Web.Areas.Admin.Validators.Stores
{
    public partial class StoreValidator : BaseQNetValidator<StoreModel>
    {
        public StoreValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Stores.Fields.Name.Required"));
            RuleFor(x => x.Url).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Stores.Fields.Url.Required"));

            SetDatabaseValidationRules<Store>(dbContext);
        }
    }
}