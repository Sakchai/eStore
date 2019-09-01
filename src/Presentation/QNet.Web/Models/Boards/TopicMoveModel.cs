using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using QNet.Web.Framework.Models;

namespace QNet.Web.Models.Boards
{
    public partial class TopicMoveModel : BaseQNetEntityModel
    {
        public TopicMoveModel()
        {
            ForumList = new List<SelectListItem>();
        }

        public int ForumSelected { get; set; }
        public string TopicSeName { get; set; }
        
        public IEnumerable<SelectListItem> ForumList { get; set; }
    }
}