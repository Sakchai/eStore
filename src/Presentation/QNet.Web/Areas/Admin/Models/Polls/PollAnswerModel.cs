using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Polls
{
    /// <summary>
    /// Represents a poll answer model
    /// </summary>
    public partial class PollAnswerModel : BaseQNetEntityModel
    {
        #region Properties

        public int PollId { get; set; }

        [QNetResourceDisplayName("Admin.ContentManagement.Polls.Answers.Fields.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Admin.ContentManagement.Polls.Answers.Fields.NumberOfVotes")]
        public int NumberOfVotes { get; set; }

        [QNetResourceDisplayName("Admin.ContentManagement.Polls.Answers.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        #endregion
    }
}