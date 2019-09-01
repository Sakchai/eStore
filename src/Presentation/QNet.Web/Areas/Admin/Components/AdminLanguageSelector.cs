using Microsoft.AspNetCore.Mvc;
using QNet.Web.Areas.Admin.Factories;
using QNet.Web.Framework.Components;

namespace QNet.Web.Areas.Admin.Components
{
    /// <summary>
    /// Represents a view component that displays the admin language selector
    /// </summary>
    public class AdminLanguageSelectorViewComponent : QNetViewComponent
    {
        #region Fields

        private readonly ICommonModelFactory _commonModelFactory;

        #endregion

        #region Ctor

        public AdminLanguageSelectorViewComponent(ICommonModelFactory commonModelFactory)
        {
            _commonModelFactory = commonModelFactory;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invoke view component
        /// </summary>
        /// <returns>View component result</returns>
        public IViewComponentResult Invoke()
        {
            //prepare model
            var model = _commonModelFactory.PrepareLanguageSelectorModel();

            return View(model);
        }

        #endregion
    }
}