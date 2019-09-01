using FluentValidation;
using QNet.Web.Areas.Admin.Models.Catalog;
using QNet.Core.Domain.Catalog;
using QNet.Data;
using QNet.Services.Localization;
using QNet.Services.Seo;
using QNet.Web.Framework.Validators;

namespace QNet.Web.Areas.Admin.Validators.Catalog
{
    public partial class ProductValidator : BaseQNetValidator<ProductModel>
    {
        public ProductValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Catalog.Products.Fields.Name.Required"));
            RuleFor(x => x.SeName).Length(0, QNetSeoDefaults.SearchEngineNameLength)
                .WithMessage(string.Format(localizationService.GetResource("Admin.SEO.SeName.MaxLengthValidation"), QNetSeoDefaults.SearchEngineNameLength));

            SetDatabaseValidationRules<Product>(dbContext);
        }
    }
}