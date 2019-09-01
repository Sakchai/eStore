using FluentValidation;
using QNet.Web.Areas.Admin.Models.Catalog;
using QNet.Core.Domain.Catalog;
using QNet.Data;
using QNet.Services.Localization;
using QNet.Web.Framework.Validators;

namespace QNet.Web.Areas.Admin.Validators.Catalog
{
    public partial class ProductAttributeValueModelValidator : BaseQNetValidator<ProductAttributeValueModel>
    {
        public ProductAttributeValueModelValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(localizationService.GetResource("Admin.Catalog.Products.ProductAttributes.Attributes.Values.Fields.Name.Required"));

            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(1)
                .WithMessage(localizationService.GetResource("Admin.Catalog.Products.ProductAttributes.Attributes.Values.Fields.Quantity.GreaterThanOrEqualTo1"))
                .When(x => x.AttributeValueTypeId == (int)AttributeValueType.AssociatedToProduct && !x.CustomerEntersQty);

            RuleFor(x => x.AssociatedProductId)
                .GreaterThanOrEqualTo(1)
                .WithMessage(localizationService.GetResource("Admin.Catalog.Products.ProductAttributes.Attributes.Values.Fields.AssociatedProduct.Choose"))
                .When(x => x.AttributeValueTypeId == (int)AttributeValueType.AssociatedToProduct);

            SetDatabaseValidationRules<ProductAttributeValue>(dbContext);
        }
    }
}