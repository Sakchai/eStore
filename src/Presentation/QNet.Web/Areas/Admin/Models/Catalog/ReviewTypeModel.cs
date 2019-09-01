using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a review type model
    /// </summary>
    public partial class ReviewTypeModel : BaseQNetEntityModel, ILocalizedModel<ReviewTypeLocalizedModel>
    {
        #region Ctor

        public ReviewTypeModel()
        {
            Locales = new List<ReviewTypeLocalizedModel>();
        }

        #endregion

        #region Properties

        [QNetResourceDisplayName("Admin.Settings.ReviewType.Fields.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Admin.Settings.ReviewType.Fields.Description")]
        public string Description { get; set; }

        [QNetResourceDisplayName("Admin.Settings.ReviewType.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [QNetResourceDisplayName("Admin.Settings.ReviewType.Fields.IsRequired")]
        public bool IsRequired { get; set; }

        [QNetResourceDisplayName("Admin.Settings.ReviewType.Fields.VisibleToAllCustomers")]
        public bool VisibleToAllCustomers { get; set; }

        public IList<ReviewTypeLocalizedModel> Locales { get; set; }

        #endregion
    }
}
