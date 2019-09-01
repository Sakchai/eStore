using QNet.Web.Framework.Models;

namespace QNet.Web.Models.PrivateMessages
{
    public partial class PrivateMessageIndexModel : BaseQNetModel
    {
        public int InboxPage { get; set; }
        public int SentItemsPage { get; set; }
        public bool SentItemsTabSelected { get; set; }
    }
}