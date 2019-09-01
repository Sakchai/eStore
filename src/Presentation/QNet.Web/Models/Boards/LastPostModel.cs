using QNet.Web.Framework.Models;

namespace QNet.Web.Models.Boards
{
    public partial class LastPostModel : BaseQNetModel
    {
        public int Id { get; set; }
        public int ForumTopicId { get; set; }
        public string ForumTopicSeName { get; set; }
        public string ForumTopicSubject { get; set; }
        
        public int CustomerId { get; set; }
        public bool AllowViewingProfiles { get; set; }
        public string CustomerName { get; set; }

        public string PostCreatedOnStr { get; set; }
        
        public bool ShowTopic { get; set; }
    }
}