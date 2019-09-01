using System.Collections.Generic;
using QNet.Web.Framework.Models;
using QNet.Web.Models.Common;

namespace QNet.Web.Models.PrivateMessages
{
    public partial class PrivateMessageListModel : BaseQNetModel
    {
        public IList<PrivateMessageModel> Messages { get; set; }
        public PagerModel PagerModel { get; set; }
    }
}