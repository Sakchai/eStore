using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Security
{
    /// <summary>
    /// Represents a permission record model
    /// </summary>
    public partial class PermissionRecordModel : BaseQNetModel
    {
        #region Properties

        public string Name { get; set; }

        public string SystemName { get; set; }

        #endregion
    }
}