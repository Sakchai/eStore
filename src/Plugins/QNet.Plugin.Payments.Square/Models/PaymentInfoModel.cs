using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Plugin.Payments.Square.Models
{
    /// <summary>
    /// Represents payment model
    /// </summary>
    public class PaymentInfoModel : BaseQNetModel
    {
        #region Ctor

        public PaymentInfoModel()
        {
            StoredCards = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        public bool IsGuest { get; set; }

        public string CardNonce { get; set; }

        public string Errors { get; set; }

        [QNetResourceDisplayName("Plugins.Payments.Square.Fields.PostalCode")]
        public string PostalCode { get; set; }

        [QNetResourceDisplayName("Plugins.Payments.Square.Fields.SaveCard")]
        public bool SaveCard { get; set; }

        [QNetResourceDisplayName("Plugins.Payments.Square.Fields.StoredCard")]
        public string StoredCardId { get; set; }
        public IList<SelectListItem> StoredCards { get; set; }

        #endregion
    }
}