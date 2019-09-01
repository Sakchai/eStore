using System;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Orders
{
    /// <summary>
    /// Represents an order note model
    /// </summary>
    public partial class OrderNoteModel : BaseQNetEntityModel
    {
        #region Properties

        public int OrderId { get; set; }

        [QNetResourceDisplayName("Admin.Orders.OrderNotes.Fields.DisplayToCustomer")]
        public bool DisplayToCustomer { get; set; }

        [QNetResourceDisplayName("Admin.Orders.OrderNotes.Fields.Note")]
        public string Note { get; set; }

        [QNetResourceDisplayName("Admin.Orders.OrderNotes.Fields.Download")]
        public int DownloadId { get; set; }

        [QNetResourceDisplayName("Admin.Orders.OrderNotes.Fields.Download")]
        public Guid DownloadGuid { get; set; }

        [QNetResourceDisplayName("Admin.Orders.OrderNotes.Fields.CreatedOn")]
        public DateTime CreatedOn { get; set; }

        #endregion
    }
}