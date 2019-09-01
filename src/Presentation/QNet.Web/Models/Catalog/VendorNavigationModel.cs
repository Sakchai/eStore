using System.Collections.Generic;
using QNet.Web.Framework.Models;

namespace QNet.Web.Models.Catalog
{
    public partial class VendorNavigationModel : BaseQNetModel
    {
        public VendorNavigationModel()
        {
            Vendors = new List<VendorBriefInfoModel>();
        }

        public IList<VendorBriefInfoModel> Vendors { get; set; }

        public int TotalVendors { get; set; }
    }

    public partial class VendorBriefInfoModel : BaseQNetEntityModel
    {
        public string Name { get; set; }

        public string SeName { get; set; }
    }
}