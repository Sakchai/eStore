using System.Collections.Generic;
using QNet.Web.Framework.Models;

namespace QNet.Web.Models.Boards
{
    public partial class BoardsIndexModel : BaseQNetModel
    {
        public BoardsIndexModel()
        {
            ForumGroups = new List<ForumGroupModel>();
        }
        
        public IList<ForumGroupModel> ForumGroups { get; set; }
    }
}