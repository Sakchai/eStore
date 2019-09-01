using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Tax
{
    /// <summary>
    /// Represents a tax configuration model
    /// </summary>
    public partial class TaxConfigurationModel : BaseQNetModel
    {
        #region Ctor

        public TaxConfigurationModel()
        {
            TaxProviders = new TaxProviderSearchModel();
            TaxCategories = new TaxCategorySearchModel();
        }

        #endregion

        #region Properties

        public TaxProviderSearchModel TaxProviders { get; set; }

        public TaxCategorySearchModel TaxCategories { get; set; }

        #endregion
    }
}
