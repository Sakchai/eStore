﻿using System.Collections.Generic;
using QNet.Web.Framework.Models;

namespace QNet.Web.Models.Catalog
{
    public partial class CategoryNavigationModel : BaseQNetModel
    {
        public CategoryNavigationModel()
        {
            Categories = new List<CategorySimpleModel>();
        }

        public int CurrentCategoryId { get; set; }
        public List<CategorySimpleModel> Categories { get; set; }

        #region Nested classes

        public class CategoryLineModel : BaseQNetModel
        {
            public int CurrentCategoryId { get; set; }
            public CategorySimpleModel Category { get; set; }
        }

        #endregion
    }
}