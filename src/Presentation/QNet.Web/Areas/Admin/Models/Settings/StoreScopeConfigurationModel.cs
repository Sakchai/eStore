using System.Collections.Generic;
using QNet.Web.Areas.Admin.Models.Stores;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Settings
{
    /// <summary>
    /// Represents a store scope configuration model
    /// </summary>
    public partial class StoreScopeConfigurationModel : BaseQNetModel
    {
        #region Ctor

        public StoreScopeConfigurationModel()
        {
            Stores = new List<StoreModel>();
        }

        #endregion

        #region Properties

        public int StoreId { get; set; }

        public IList<StoreModel> Stores { get; set; }

        #endregion
    }
}