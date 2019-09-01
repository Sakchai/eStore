using System.Collections.Generic;
using QNet.Web.Areas.Admin.Models.Customers;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Security
{
    /// <summary>
    /// Represents a permission mapping model
    /// </summary>
    public partial class PermissionMappingModel : BaseQNetModel
    {
        #region Ctor

        public PermissionMappingModel()
        {
            AvailablePermissions = new List<PermissionRecordModel>();
            AvailableCustomerRoles = new List<CustomerRoleModel>();
            Allowed = new Dictionary<string, IDictionary<int, bool>>();
        }

        #endregion

        #region Properties

        public IList<PermissionRecordModel> AvailablePermissions { get; set; }

        public IList<CustomerRoleModel> AvailableCustomerRoles { get; set; }

        //[permission system name] / [customer role id] / [allowed]
        public IDictionary<string, IDictionary<int, bool>> Allowed { get; set; }

        #endregion
    }
}