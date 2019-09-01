using FluentValidation;
using QNet.Web.Areas.Admin.Models.Catalog;
using QNet.Core.Domain.Catalog;
using QNet.Data;
using QNet.Services.Localization;
using QNet.Web.Framework.Validators;

namespace QNet.Web.Areas.Admin.Validators.Catalog
{
    public partial class ProductTagValidator : BaseQNetValidator<ProductTagModel>
    {
        public ProductTagValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Catalog.ProductTags.Fields.Name.Required"));

            SetDatabaseValidationRules<ProductTag>(dbContext);
        }
    }
}