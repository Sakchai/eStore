using System.Collections.Generic;
using QNet.Web.Framework.Models;
using QNet.Web.Models.Common;

namespace QNet.Web.Models.Profile
{
    public partial class ProfilePostsModel : BaseQNetModel
    {
        public IList<PostsModel> Posts { get; set; }
        public PagerModel PagerModel { get; set; }
    }
}