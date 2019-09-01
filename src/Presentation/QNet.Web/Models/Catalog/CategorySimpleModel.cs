using System.Collections.Generic;
using QNet.Web.Framework.Models;

namespace QNet.Web.Models.Catalog
{
    public class CategorySimpleModel : BaseQNetEntityModel
    {
        public CategorySimpleModel()
        {
            SubCategories = new List<CategorySimpleModel>();
        }

        public string Name { get; set; }

        public string SeName { get; set; }

        public int? NumberOfProducts { get; set; }

        public bool IncludeInTopMenu { get; set; }

        public List<CategorySimpleModel> SubCategories { get; set; }

        public bool HaveSubCategories { get; set; }

        public string Route { get; set; }
    }
}