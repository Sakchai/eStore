using System.Collections.Generic;
using System.Linq;
using QNet.Web.Framework.Models;

namespace QNet.Web.Models.Catalog
{
    public partial class TopMenuModel : BaseQNetModel
    {
        public TopMenuModel()
        {
            Categories = new List<CategorySimpleModel>();
            Topics = new List<TopicModel>();
        }

        public IList<CategorySimpleModel> Categories { get; set; }
        public IList<TopicModel> Topics { get; set; }

        public bool BlogEnabled { get; set; }
        public bool NewProductsEnabled { get; set; }
        public bool ForumEnabled { get; set; }

        public bool DisplayHomepageMenuItem { get; set; }
        public bool DisplayNewProductsMenuItem { get; set; }
        public bool DisplayProductSearchMenuItem { get; set; }
        public bool DisplayCustomerInfoMenuItem { get; set; }
        public bool DisplayBlogMenuItem { get; set; }
        public bool DisplayForumsMenuItem { get; set; }
        public bool DisplayContactUsMenuItem { get; set; }

        public bool UseAjaxMenu { get; set; }

        public bool HasOnlyCategories
        {
            get
            {
                return Categories.Any()
                       && !Topics.Any()
                       && !DisplayHomepageMenuItem
                       && !(DisplayNewProductsMenuItem && NewProductsEnabled)
                       && !DisplayProductSearchMenuItem
                       && !DisplayCustomerInfoMenuItem
                       && !(DisplayBlogMenuItem && BlogEnabled)
                       && !(DisplayForumsMenuItem && ForumEnabled)
                       && !DisplayContactUsMenuItem;
            }
        }

        #region Nested classes
        
        public class TopicModel : BaseQNetEntityModel
        {
            public string Name { get; set; }
            public string SeName { get; set; }
        }

        public class CategoryLineModel : BaseQNetModel
        {
            public int Level { get; set; }
            public bool ResponsiveMobileMenu { get; set; }
            public CategorySimpleModel Category { get; set; }
        }

        #endregion
    }
}