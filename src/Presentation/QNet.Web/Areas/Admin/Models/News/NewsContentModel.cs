﻿using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.News
{
    /// <summary>
    /// Represents a news content model
    /// </summary>
    public partial class NewsContentModel : BaseQNetModel
    {
        #region Ctor

        public NewsContentModel()
        {
            NewsItems = new NewsItemSearchModel();
            NewsComments = new NewsCommentSearchModel();
        }

        #endregion

        #region Properties

        public NewsItemSearchModel NewsItems { get; set; }

        public NewsCommentSearchModel NewsComments { get; set; }

        #endregion
    }
}
