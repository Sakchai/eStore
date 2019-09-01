using System.Collections.Generic;
using QNet.Web.Framework.Models;

namespace QNet.Web.Models.Common
{
    public partial class CurrencySelectorModel : BaseQNetModel
    {
        public CurrencySelectorModel()
        {
            AvailableCurrencies = new List<CurrencyModel>();
        }

        public IList<CurrencyModel> AvailableCurrencies { get; set; }

        public int CurrentCurrencyId { get; set; }
    }
}