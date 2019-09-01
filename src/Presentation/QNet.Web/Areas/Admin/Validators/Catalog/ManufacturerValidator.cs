using FluentValidation;
using QNet.Web.Areas.Admin.Models.Catalog;
using QNet.Core.Domain.Catalog;
using QNet.Data;
using QNet.Services.Localization;
using QNet.Services.Seo;
using QNet.Web.Framework.Validators;

namespace QNet.Web.Areas.Admin.Validators.Catalog
{
    public partial class ManufacturerValidator : BaseQNetValidator<ManufacturerModel>
    {
        public ManufacturerValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Catalog.Manufacturers.Fields.Name.Required"));
            RuleFor(x => x.PageSizeOptions).Must(ValidatorUtilities.PageSizeOptionsValidator).WithMessage(localizationService.GetResource("Admin.Catalog.Manufacturers.Fields.PageSizeOptions.ShouldHaveUniqueItems"));
            RuleFor(x => x.PageSize).Must((x, context) =>
            {
                if (!x.AllowCustomersToSelectPageSize && x.PageSize <= 0)
                    return false;

                return true;
            }).WithMessage(localizationService.GetResource("Admin.Catalog.Manufacturers.Fields.PageSize.Positive"));
            RuleFor(x => x.SeName).Length(0, QNetSeoDefaults.SearchEngineNameLength)
                .WithMessage(string.Format(localizationService.GetResource("Admin.SEO.SeName.MaxLengthValidation"), QNetSeoDefaults.SearchEngineNameLength));

            SetDatabaseValidationRules<Manufacturer>(dbContext);
        }
    }
}