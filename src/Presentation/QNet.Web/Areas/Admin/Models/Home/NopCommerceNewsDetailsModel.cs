﻿using System;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Home
{
    /// <summary>
    /// Represents a QNet news details model
    /// </summary>
    public partial class QNetCommerceNewsDetailsModel : BaseQNetModel
    {
        #region Properties

        public string Title { get; set; }

        public string Url { get; set; }

        public string Summary { get; set; }

        public DateTimeOffset PublishDate { get; set; }

        #endregion
    }
}