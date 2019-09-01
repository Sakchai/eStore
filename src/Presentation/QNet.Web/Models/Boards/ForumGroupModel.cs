using System.Collections.Generic;
using QNet.Web.Framework.Models;

namespace QNet.Web.Models.Boards
{
    public partial  class ForumGroupModel : BaseQNetModel
    {
        public ForumGroupModel()
        {
            Forums = new List<ForumRowModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string SeName { get; set; }

        public IList<ForumRowModel> Forums { get; set; }
    }
}