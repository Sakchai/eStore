using System.Collections.Generic;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Vendors
{
    /// <summary>
    /// Represents a vendor attribute value model
    /// </summary>
    public partial class VendorAttributeValueModel : BaseQNetEntityModel, ILocalizedModel<VendorAttributeValueLocalizedModel>
    {
        #region Ctor

        public VendorAttributeValueModel()
        {
            Locales = new List<VendorAttributeValueLocalizedModel>();
        }

        #endregion

        #region Properties

        public int VendorAttributeId { get; set; }

        [QNetResourceDisplayName("Admin.Vendors.VendorAttributes.Values.Fields.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Admin.Vendors.VendorAttributes.Values.Fields.IsPreSelected")]
        public bool IsPreSelected { get; set; }

        [QNetResourceDisplayName("Admin.Vendors.VendorAttributes.Values.Fields.DisplayOrder")]
        public int DisplayOrder {get;set;}

        public IList<VendorAttributeValueLocalizedModel> Locales { get; set; }

        #endregion
    }

    public partial class VendorAttributeValueLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }

        [QNetResourceDisplayName("Admin.Vendors.VendorAttributes.Values.Fields.Name")]
        public string Name { get; set; }
    }
}