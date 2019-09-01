using System.Collections.Generic;
using QNet.Web.Framework.Models;

namespace QNet.Web.Models.Common
{
    public partial class StoreThemeSelectorModel : BaseQNetModel
    {
        public StoreThemeSelectorModel()
        {
            AvailableStoreThemes = new List<StoreThemeModel>();
        }

        public IList<StoreThemeModel> AvailableStoreThemes { get; set; }

        public StoreThemeModel CurrentStoreTheme { get; set; }
    }
}