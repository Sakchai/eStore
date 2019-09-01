using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Directory
{
    /// <summary>
    /// Represents a currency exchange rate model
    /// </summary>
    public partial class CurrencyExchangeRateModel : BaseQNetModel
    {
        #region Properties

        public string CurrencyCode { get; set; }

        public decimal Rate { get; set; }

        #endregion
    }
}