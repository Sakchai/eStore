using System;
using System.ComponentModel.DataAnnotations;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Plugin.Tax.Avalara.Models.Log
{
    /// <summary>
    /// Represents a tax transaction log search model
    /// </summary>
    public class TaxTransactionLogSearchModel : BaseSearchModel
    {
        #region Properties

        [QNetResourceDisplayName("Plugins.Tax.Avalara.Log.Search.CreatedFrom")]
        [UIHint("DateNullable")]
        public DateTime? CreatedFrom { get; set; }

        [QNetResourceDisplayName("Plugins.Tax.Avalara.Log.Search.CreatedTo")]
        [UIHint("DateNullable")]
        public DateTime? CreatedTo { get; set; }

        #endregion
    }
}