using FluentValidation;
using QNet.Web.Areas.Admin.Models.Vendors;
using QNet.Core.Domain.Vendors;
using QNet.Data;
using QNet.Services.Localization;
using QNet.Web.Framework.Validators;

namespace QNet.Web.Areas.Admin.Validators.Vendors
{
    public partial class VendorAttributeValueValidator : BaseQNetValidator<VendorAttributeValueModel>
    {
        public VendorAttributeValueValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Vendors.VendorAttributes.Values.Fields.Name.Required"));

            SetDatabaseValidationRules<VendorAttributeValue>(dbContext);
        }
    }
}