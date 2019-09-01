using System.ComponentModel.DataAnnotations;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Orders
{
    /// <summary>
    /// Represents an upload license model
    /// </summary>
    public partial class UploadLicenseModel : BaseQNetModel
    {
        #region Properties

        public int OrderId { get; set; }

        public int OrderItemId { get; set; }

        [UIHint("Download")]
        public int LicenseDownloadId { get; set; }

        #endregion
    }
}