using QNet.Web.Framework.Models;

namespace QNet.Web.Models.Common
{
    public partial class CurrencyModel : BaseQNetEntityModel
    {
        public string Name { get; set; }

        public string CurrencySymbol { get; set; }
    }
}