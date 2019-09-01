using System;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Plugin.Tax.Avalara.Models.Log
{
    /// <summary>
    /// Represents a tax transaction log model
    /// </summary>
    public class TaxTransactionLogModel : BaseQNetEntityModel
    {
        #region Properties

        [QNetResourceDisplayName("Plugins.Tax.Avalara.Log.StatusCode")]
        public int StatusCode { get; set; }

        [QNetResourceDisplayName("Plugins.Tax.Avalara.Log.Url")]
        public string Url { get; set; }

        [QNetResourceDisplayName("Plugins.Tax.Avalara.Log.RequestMessage")]
        public string RequestMessage { get; set; }

        [QNetResourceDisplayName("Plugins.Tax.Avalara.Log.ResponseMessage")]
        public string ResponseMessage { get; set; }

        [QNetResourceDisplayName("Plugins.Tax.Avalara.Log.Customer")]
        public int? CustomerId { get; set; }
        public string CustomerEmail { get; set; }

        [QNetResourceDisplayName("Plugins.Tax.Avalara.Log.CreatedDate")]
        public DateTime CreatedDate { get; set; }

        #endregion
    }
}