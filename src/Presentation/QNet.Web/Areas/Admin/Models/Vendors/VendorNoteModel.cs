using System;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Vendors
{
    /// <summary>
    /// Represents a vendor note model
    /// </summary>
    public partial class VendorNoteModel : BaseQNetEntityModel
    {
        #region Properties

        public int VendorId { get; set; }

        [QNetResourceDisplayName("Admin.Vendors.VendorNotes.Fields.Note")]
        public string Note { get; set; }

        [QNetResourceDisplayName("Admin.Vendors.VendorNotes.Fields.CreatedOn")]
        public DateTime CreatedOn { get; set; }

        #endregion
    }
}