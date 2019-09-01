using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using QNet.Core.Domain.Catalog;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a product attribute combination model
    /// </summary>
    public partial class ProductAttributeCombinationModel : BaseQNetEntityModel
    {
        #region Ctor

        public ProductAttributeCombinationModel()
        {
            ProductAttributes = new List<ProductAttributeModel>();
            ProductPictureModels = new List<ProductPictureModel>();
            Warnings = new List<string>();
        }

        #endregion

        #region Properties

        public int ProductId { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.ProductAttributes.AttributeCombinations.Fields.Attributes")]
        public string AttributesXml { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.ProductAttributes.AttributeCombinations.Fields.StockQuantity")]
        public int StockQuantity { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.ProductAttributes.AttributeCombinations.Fields.AllowOutOfStockOrders")]
        public bool AllowOutOfStockOrders { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.ProductAttributes.AttributeCombinations.Fields.Sku")]
        public string Sku { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.ProductAttributes.AttributeCombinations.Fields.ManufacturerPartNumber")]
        public string ManufacturerPartNumber { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.ProductAttributes.AttributeCombinations.Fields.Gtin")]
        public string Gtin { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.ProductAttributes.AttributeCombinations.Fields.OverriddenPrice")]
        [UIHint("DecimalNullable")]
        public decimal? OverriddenPrice { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.ProductAttributes.AttributeCombinations.Fields.NotifyAdminForQuantityBelow")]
        public int NotifyAdminForQuantityBelow { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.ProductAttributes.AttributeCombinations.Fields.Picture")]
        public int PictureId { get; set; }

        public string PictureThumbnailUrl { get; set; }

        public IList<ProductAttributeModel> ProductAttributes { get; set; }

        public IList<ProductPictureModel> ProductPictureModels { get; set; }

        public IList<string> Warnings { get; set; }

        #endregion

        #region Nested classes

        public partial class ProductAttributeModel : BaseQNetEntityModel
        {
            public ProductAttributeModel()
            {
                Values = new List<ProductAttributeValueModel>();
            }

            public int ProductAttributeId { get; set; }

            public string Name { get; set; }

            public string TextPrompt { get; set; }

            public bool IsRequired { get; set; }

            public AttributeControlType AttributeControlType { get; set; }

            public IList<ProductAttributeValueModel> Values { get; set; }
        }

        public partial class ProductAttributeValueModel : BaseQNetEntityModel
        {
            public string Name { get; set; }

            public bool IsPreSelected { get; set; }

            public string Checked { get; set; }
        }

        #endregion
    }
}