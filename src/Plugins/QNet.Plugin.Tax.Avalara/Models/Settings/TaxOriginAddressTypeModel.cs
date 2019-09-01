using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Plugin.Tax.Avalara.Models.Settings
{
    /// <summary>
    /// Represents a tax origin address type model
    /// </summary>
    public class TaxOriginAddressTypeModel : BaseQNetModel
    {
        #region Ctor

        public TaxOriginAddressTypeModel()
        {
            TaxOriginAddressTypes = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        public string PrecedingElementId { get; set; }

        [QNetResourceDisplayName("Plugins.Tax.Avalara.Fields.TaxOriginAddressType")]
        public int AvalaraTaxOriginAddressType { get; set; }
        public IList<SelectListItem> TaxOriginAddressTypes { get; set; }

        #endregion
    }
}