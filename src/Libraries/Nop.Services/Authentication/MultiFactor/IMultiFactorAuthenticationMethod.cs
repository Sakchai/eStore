﻿using System.Threading.Tasks;
using Nop.Services.Plugins;

namespace Nop.Services.Authentication.MultiFactor
{
    /// <summary>
    /// Represents method for the multi-factor authentication
    /// </summary>
    public partial interface IMultiFactorAuthenticationMethod : IPlugin
    {
        #region Methods

        /// <summary>
        ///  Gets a multi-factor authentication type
        /// </summary>
        MultiFactorAuthenticationType Type { get; }

        /// <summary>
        /// Gets a name of a view component for displaying plugin in public store
        /// </summary>
        /// <returns>View component name</returns>
        string GetPublicViewComponentName();

        /// <summary>
        /// Gets a name of a view component for displaying verification page
        /// </summary>
        /// <returns>View component name</returns>
        string GetVerificationViewComponentName();

        /// <summary>
        /// Gets a multi-factor authentication method description that will be displayed on customer info pages in the public store
        /// </summary>
        Task<string> GetDescriptionAsync();

        #endregion
    }
}
