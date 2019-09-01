using QNet.Web.Framework.Models;

namespace QNet.Web.Models.Catalog
{
    public partial class ProductTagModel : BaseQNetEntityModel
    {
        public string Name { get; set; }

        public string SeName { get; set; }

        public int ProductCount { get; set; }
    }
}