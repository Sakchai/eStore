using Microsoft.AspNetCore.Mvc;
using QNet.Web.Areas.Admin.Factories;
using QNet.Web.Framework.Components;

namespace QNet.Web.Areas.Admin.Components
{
    /// <summary>
    /// Represents a view component that displays the QNet news
    /// </summary>
    public class QNetCommerceNewsViewComponent : QNetViewComponent
    {
        #region Fields

        private readonly IHomeModelFactory _homeModelFactory;

        #endregion

        #region Ctor

        public QNetCommerceNewsViewComponent(IHomeModelFactory homeModelFactory)
        {
            _homeModelFactory = homeModelFactory;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invoke view component
        /// </summary>
        /// <returns>View component result</returns>
        public IViewComponentResult Invoke()
        {
            try
            {
                //prepare model
                var model = _homeModelFactory.PrepareQNetCommerceNewsModel();

                return View(model);
            }
            catch
            {
                return Content(string.Empty);
            }
        }

        #endregion
    }
}