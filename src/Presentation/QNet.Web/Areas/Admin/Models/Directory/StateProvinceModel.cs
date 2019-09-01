using System.Collections.Generic;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Directory
{
    /// <summary>
    /// Represents a state and province model
    /// </summary>
    public partial class StateProvinceModel : BaseQNetEntityModel, ILocalizedModel<StateProvinceLocalizedModel>
    {
        #region Ctor

        public StateProvinceModel()
        {
            Locales = new List<StateProvinceLocalizedModel>();
        }

        #endregion

        #region Properties

        public int CountryId { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Countries.States.Fields.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Countries.States.Fields.Abbreviation")]
        public string Abbreviation { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Countries.States.Fields.Published")]
        public bool Published { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Countries.States.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        public IList<StateProvinceLocalizedModel> Locales { get; set; }

        #endregion
    }

    public partial class StateProvinceLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }
        
        [QNetResourceDisplayName("Admin.Configuration.Countries.States.Fields.Name")]
        public string Name { get; set; }
    }
}