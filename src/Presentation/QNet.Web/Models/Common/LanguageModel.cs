using QNet.Web.Framework.Models;

namespace QNet.Web.Models.Common
{
    public partial class LanguageModel : BaseQNetEntityModel
    {
        public string Name { get; set; }

        public string FlagImageFileName { get; set; }
    }
}