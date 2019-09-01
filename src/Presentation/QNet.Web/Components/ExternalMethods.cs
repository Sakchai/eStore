using Microsoft.AspNetCore.Mvc;
using QNet.Web.Factories;
using QNet.Web.Framework.Components;

namespace QNet.Web.Components
{
    public class ExternalMethodsViewComponent : QNetViewComponent
    {
        #region Fields

        private readonly IExternalAuthenticationModelFactory _externalAuthenticationModelFactory;

        #endregion

        #region Ctor

        public ExternalMethodsViewComponent(IExternalAuthenticationModelFactory externalAuthenticationModelFactory)
        {
            _externalAuthenticationModelFactory = externalAuthenticationModelFactory;
        }

        #endregion

        #region Methods

        public IViewComponentResult Invoke()
        {
            var model = _externalAuthenticationModelFactory.PrepareExternalMethodsModel();

            return View(model);
        }

        #endregion
    }
}
