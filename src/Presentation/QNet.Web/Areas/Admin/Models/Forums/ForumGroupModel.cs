using System;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Forums
{
    /// <summary>
    /// Represents a forum group model
    /// </summary>
    public partial class ForumGroupModel : BaseQNetEntityModel
    {
        #region Properties

        [QNetResourceDisplayName("Admin.ContentManagement.Forums.ForumGroup.Fields.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Admin.ContentManagement.Forums.ForumGroup.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [QNetResourceDisplayName("Admin.ContentManagement.Forums.ForumGroup.Fields.CreatedOn")]
        public DateTime CreatedOn { get; set; }

        #endregion
    }
}