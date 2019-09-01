using System.ComponentModel.DataAnnotations;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a product picture model
    /// </summary>
    public partial class ProductPictureModel : BaseQNetEntityModel
    {
        #region Properties

        public int ProductId { get; set; }

        [UIHint("Picture")]
        [QNetResourceDisplayName("Admin.Catalog.Products.Pictures.Fields.Picture")]
        public int PictureId { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.Pictures.Fields.Picture")]
        public string PictureUrl { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.Pictures.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.Pictures.Fields.OverrideAltAttribute")]
        public string OverrideAltAttribute { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.Pictures.Fields.OverrideTitleAttribute")]
        public string OverrideTitleAttribute { get; set; }

        #endregion
    }
}