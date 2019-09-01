using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Stores
{
    /// <summary>
    /// Represents a store model
    /// </summary>
    public partial class StoreModel : BaseQNetEntityModel, ILocalizedModel<StoreLocalizedModel>
    {
        #region Ctor

        public StoreModel()
        {
            Locales = new List<StoreLocalizedModel>();
            AvailableLanguages = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        [QNetResourceDisplayName("Admin.Configuration.Stores.Fields.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Stores.Fields.Url")]
        public string Url { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Stores.Fields.SslEnabled")]
        public virtual bool SslEnabled { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Stores.Fields.Hosts")]
        public string Hosts { get; set; }

        //default language
        [QNetResourceDisplayName("Admin.Configuration.Stores.Fields.DefaultLanguage")]
        public int DefaultLanguageId { get; set; }

        public IList<SelectListItem> AvailableLanguages { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Stores.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Stores.Fields.CompanyName")]
        public string CompanyName { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Stores.Fields.CompanyAddress")]
        public string CompanyAddress { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Stores.Fields.CompanyPhoneNumber")]
        public string CompanyPhoneNumber { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Stores.Fields.CompanyVat")]
        public string CompanyVat { get; set; }
        
        public IList<StoreLocalizedModel> Locales { get; set; }

        #endregion
    }

    public partial class StoreLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Stores.Fields.Name")]
        public string Name { get; set; }
    }
}