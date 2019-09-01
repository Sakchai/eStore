using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Localization
{
    /// <summary>
    /// Represents a language model
    /// </summary>
    public partial class LanguageModel : BaseQNetEntityModel, IStoreMappingSupportedModel
    {
        #region Ctor

        public LanguageModel()
        {
            AvailableCurrencies = new List<SelectListItem>();
            SelectedStoreIds = new List<int>();
            AvailableStores = new List<SelectListItem>();
            LocaleResourceSearchModel = new LocaleResourceSearchModel();
        }

        #endregion

        #region Properties

        [QNetResourceDisplayName("Admin.Configuration.Languages.Fields.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Languages.Fields.LanguageCulture")]
        public string LanguageCulture { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Languages.Fields.UniqueSeoCode")]
        public string UniqueSeoCode { get; set; }

        //flags
        [QNetResourceDisplayName("Admin.Configuration.Languages.Fields.FlagImageFileName")]
        public string FlagImageFileName { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Languages.Fields.Rtl")]
        public bool Rtl { get; set; }

        //default currency
        [QNetResourceDisplayName("Admin.Configuration.Languages.Fields.DefaultCurrency")]
        public int DefaultCurrencyId { get; set; }

        public IList<SelectListItem> AvailableCurrencies { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Languages.Fields.Published")]
        public bool Published { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Languages.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        //store mapping
        [QNetResourceDisplayName("Admin.Configuration.Languages.Fields.LimitedToStores")]
        public IList<int> SelectedStoreIds { get; set; }

        public IList<SelectListItem> AvailableStores { get; set; }

        // search
        public LocaleResourceSearchModel LocaleResourceSearchModel { get; set; }

        #endregion
    }
}