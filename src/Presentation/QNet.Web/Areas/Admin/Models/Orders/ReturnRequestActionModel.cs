using System.Collections.Generic;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Orders
{
    /// <summary>
    /// Represents a return request action model
    /// </summary>
    public partial class ReturnRequestActionModel : BaseQNetEntityModel, ILocalizedModel<ReturnRequestActionLocalizedModel>
    {
        #region Ctor

        public ReturnRequestActionModel()
        {
            Locales = new List<ReturnRequestActionLocalizedModel>();
        }

        #endregion

        #region Properties

        [QNetResourceDisplayName("Admin.Configuration.Settings.Order.ReturnRequestActions.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.Order.ReturnRequestActions.DisplayOrder")]
        public int DisplayOrder { get; set; }

        public IList<ReturnRequestActionLocalizedModel> Locales { get; set; }

        #endregion
    }

    public partial class ReturnRequestActionLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.Order.ReturnRequestActions.Name")]
        public string Name { get; set; }
    }
}