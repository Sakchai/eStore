using System.Collections.Generic;
using QNet.Web.Framework.Models;

namespace QNet.Web.Models.Catalog
{
    public partial class CompareProductsModel : BaseQNetEntityModel
    {
        public CompareProductsModel()
        {
            Products = new List<ProductOverviewModel>();
        }
        public IList<ProductOverviewModel> Products { get; set; }

        public bool IncludeShortDescriptionInCompareProducts { get; set; }
        public bool IncludeFullDescriptionInCompareProducts { get; set; }
    }
}