﻿using System.Collections.Generic;
using Nop.Web.Framework.Models;

namespace Nop.Web.Models.Common
{
    public partial record SitemapModel : BaseNopModel
    {
        #region Ctor

        public SitemapModel()
        {
            Items = new List<SitemapItemModel>();
            PageModel = new SitemapPageModel();
        }

        #endregion

        #region Properties

        public List<SitemapItemModel> Items { get; set; }

        public SitemapPageModel PageModel { get; set; }

        #endregion

        #region Nested classes

        public record SitemapItemModel
        {
            public string GroupTitle { get; set; }
            public string Url { get; set; }
            public string Name { get; set; }
        }

        #endregion
    }
}