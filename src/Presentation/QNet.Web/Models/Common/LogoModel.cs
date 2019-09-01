using QNet.Web.Framework.Models;

namespace QNet.Web.Models.Common
{
    public partial class LogoModel : BaseQNetModel
    {
        public string StoreName { get; set; }

        public string LogoPath { get; set; }
    }
}