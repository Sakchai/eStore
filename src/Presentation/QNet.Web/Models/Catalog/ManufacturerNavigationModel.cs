using System.Collections.Generic;
using QNet.Web.Framework.Models;

namespace QNet.Web.Models.Catalog
{
    public partial class ManufacturerNavigationModel : BaseQNetModel
    {
        public ManufacturerNavigationModel()
        {
            Manufacturers = new List<ManufacturerBriefInfoModel>();
        }

        public IList<ManufacturerBriefInfoModel> Manufacturers { get; set; }

        public int TotalManufacturers { get; set; }
    }

    public partial class ManufacturerBriefInfoModel : BaseQNetEntityModel
    {
        public string Name { get; set; }

        public string SeName { get; set; }
        
        public bool IsActive { get; set; }
    }
}