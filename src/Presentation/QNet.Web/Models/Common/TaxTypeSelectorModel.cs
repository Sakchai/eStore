using QNet.Core.Domain.Tax;
using QNet.Web.Framework.Models;

namespace QNet.Web.Models.Common
{
    public partial class TaxTypeSelectorModel : BaseQNetModel
    {
        public TaxDisplayType CurrentTaxType { get; set; }
    }
}