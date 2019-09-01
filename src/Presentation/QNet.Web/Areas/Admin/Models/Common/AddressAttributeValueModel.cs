using System.Collections.Generic;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Common
{
    /// <summary>
    /// Represents an address attribute value model
    /// </summary>
    public partial class AddressAttributeValueModel : BaseQNetEntityModel, ILocalizedModel<AddressAttributeValueLocalizedModel>
    {
        #region Ctor

        public AddressAttributeValueModel()
        {
            Locales = new List<AddressAttributeValueLocalizedModel>();
        }

        #endregion

        #region Properties

        public int AddressAttributeId { get; set; }

        [QNetResourceDisplayName("Admin.Address.AddressAttributes.Values.Fields.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Admin.Address.AddressAttributes.Values.Fields.IsPreSelected")]
        public bool IsPreSelected { get; set; }

        [QNetResourceDisplayName("Admin.Address.AddressAttributes.Values.Fields.DisplayOrder")]
        public int DisplayOrder {get;set;}

        public IList<AddressAttributeValueLocalizedModel> Locales { get; set; }

        #endregion
    }

    public partial class AddressAttributeValueLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }

        [QNetResourceDisplayName("Admin.Address.AddressAttributes.Values.Fields.Name")]
        public string Name { get; set; }
    }
}