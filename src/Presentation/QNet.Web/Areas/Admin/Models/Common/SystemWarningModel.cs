using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Common
{
    public partial class SystemWarningModel : BaseQNetModel
    {
        public SystemWarningLevel Level { get; set; }

        public string Text { get; set; }

        public bool DontEncode { get; set; }
    }

    public enum SystemWarningLevel
    {
        Pass,
        Recommendation,
        CopyrightRemovalKey,
        Warning,
        Fail
    }
}