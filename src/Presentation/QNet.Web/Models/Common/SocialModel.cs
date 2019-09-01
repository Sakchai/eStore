using QNet.Web.Framework.Models;

namespace QNet.Web.Models.Common
{
    public partial class SocialModel : BaseQNetModel
    {
        public string FacebookLink { get; set; }
        public string TwitterLink { get; set; }
        public string YoutubeLink { get; set; }
        public int WorkingLanguageId { get; set; }
        public bool NewsEnabled { get; set; }
    }
}