using QNet.Web.Framework.Models;

namespace QNet.Web.Models.Catalog
{
    public partial class SearchBoxModel : BaseQNetModel
    {
        public bool AutoCompleteEnabled { get; set; }
        public bool ShowProductImagesInSearchAutoComplete { get; set; }
        public int SearchTermMinimumLength { get; set; }
    }
}