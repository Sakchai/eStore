using QNet.Web.Areas.Admin.Models.Common;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Shipping
{
    /// <summary>
    /// Represents a warehouse model
    /// </summary>
    public partial class WarehouseModel : BaseQNetEntityModel
    {
        #region Ctor

        public WarehouseModel()
        {
            Address = new AddressModel();
        }

        #endregion

        #region Properties

        [QNetResourceDisplayName("Admin.Configuration.Shipping.Warehouses.Fields.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Shipping.Warehouses.Fields.AdminComment")]
        public string AdminComment { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Shipping.Warehouses.Fields.Address")]
        public AddressModel Address { get; set; }

        #endregion
    }
}