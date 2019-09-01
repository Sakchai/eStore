using System;
using System.Collections.Generic;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Forums
{
    /// <summary>
    /// Represents a forum list model
    /// </summary>
    public partial class ForumModel : BaseQNetEntityModel
    {
        #region Ctor

        public ForumModel()
        {
            ForumGroups = new List<ForumGroupModel>();
        }

        #endregion

        #region Properties

        [QNetResourceDisplayName("Admin.ContentManagement.Forums.Forum.Fields.ForumGroupId")]
        public int ForumGroupId { get; set; }

        [QNetResourceDisplayName("Admin.ContentManagement.Forums.Forum.Fields.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Admin.ContentManagement.Forums.Forum.Fields.Description")]
        public string Description { get; set; }

        [QNetResourceDisplayName("Admin.ContentManagement.Forums.Forum.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [QNetResourceDisplayName("Admin.ContentManagement.Forums.Forum.Fields.CreatedOn")]
        public DateTime CreatedOn { get; set; }

        public List<ForumGroupModel> ForumGroups { get; set; }

        #endregion
    }
}