using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using QNet.Core.Http.Extensions;
using QNet.Core.Infrastructure;

namespace QNet.Services.Authentication.External
{
    /// <summary>
    /// External authorizer helper
    /// </summary>
    public static partial class ExternalAuthorizerHelper
    {
        #region Methods

        /// <summary>
        /// Add error
        /// </summary>
        /// <param name="error">Error</param>
        public static void AddErrorsToDisplay(string error)
        {
            var session = EngineContext.Current.Resolve<IHttpContextAccessor>().HttpContext.Session;
            var errors = session.Get<IList<string>>(QNetAuthenticationDefaults.ExternalAuthenticationErrorsSessionKey) ?? new List<string>();
            errors.Add(error);
            session.Set(QNetAuthenticationDefaults.ExternalAuthenticationErrorsSessionKey, errors);
        }

        /// <summary>
        /// Retrieve errors to display
        /// </summary>
        /// <returns>Errors</returns>
        public static IList<string> RetrieveErrorsToDisplay()
        {
            var session = EngineContext.Current.Resolve<IHttpContextAccessor>().HttpContext.Session;
            var errors = session.Get<IList<string>>(QNetAuthenticationDefaults.ExternalAuthenticationErrorsSessionKey);

            if (errors != null)
                session.Remove(QNetAuthenticationDefaults.ExternalAuthenticationErrorsSessionKey);

            return errors;
        }

        #endregion
    }
}