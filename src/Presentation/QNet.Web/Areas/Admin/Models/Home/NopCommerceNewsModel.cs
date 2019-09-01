using System.Collections.Generic;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Home
{
    /// <summary>
    /// Represents a QNet news model
    /// </summary>
    public partial class QNetCommerceNewsModel : BaseQNetModel
    {
        #region Ctor

        public QNetCommerceNewsModel()
        {
            Items = new List<QNetCommerceNewsDetailsModel>();
        }

        #endregion

        #region Properties

        public List<QNetCommerceNewsDetailsModel> Items { get; set; }

        public bool HasNewItems { get; set; }

        public bool HideAdvertisements { get; set; }

        #endregion
    }
}