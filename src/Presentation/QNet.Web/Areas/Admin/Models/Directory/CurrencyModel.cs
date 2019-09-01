using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Directory
{
    /// <summary>
    /// Represents a currency model
    /// </summary>
    public partial class CurrencyModel : BaseQNetEntityModel, ILocalizedModel<CurrencyLocalizedModel>, IStoreMappingSupportedModel
    {
        #region Ctor

        public CurrencyModel()
        {
            Locales = new List<CurrencyLocalizedModel>();

            SelectedStoreIds = new List<int>();
            AvailableStores = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        [QNetResourceDisplayName("Admin.Configuration.Currencies.Fields.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Currencies.Fields.CurrencyCode")]
        public string CurrencyCode { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Currencies.Fields.DisplayLocale")]
        public string DisplayLocale { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Currencies.Fields.Rate")]
        public decimal Rate { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Currencies.Fields.CustomFormatting")]
        public string CustomFormatting { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Currencies.Fields.Published")]
        public bool Published { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Currencies.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Currencies.Fields.CreatedOn")]
        public DateTime CreatedOn { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Currencies.Fields.IsPrimaryExchangeRateCurrency")]
        public bool IsPrimaryExchangeRateCurrency { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Currencies.Fields.IsPrimaryStoreCurrency")]
        public bool IsPrimaryStoreCurrency { get; set; }

        public IList<CurrencyLocalizedModel> Locales { get; set; }

        //store mapping
        [QNetResourceDisplayName("Admin.Configuration.Currencies.Fields.LimitedToStores")]
        public IList<int> SelectedStoreIds { get; set; }
        public IList<SelectListItem> AvailableStores { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Currencies.Fields.RoundingType")]
        public int RoundingTypeId { get; set; }

        #endregion
    }

    public partial class CurrencyLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Currencies.Fields.Name")]
        public string Name { get; set; }
    }
}