using System.Linq;
using System.Security.Claims;
using QNet.Core.Domain.Customers;
using QNet.Services.Authentication.External;
using QNet.Services.Common;
using QNet.Services.Events;

namespace QNet.Plugin.ExternalAuth.Facebook.Infrastructure
{
    /// <summary>
    /// Facebook authentication event consumer (used for saving customer fields on registration)
    /// </summary>
    public partial class FacebookAuthenticationEventConsumer : IConsumer<CustomerAutoRegisteredByExternalMethodEvent>
    {
        #region Fields

        private readonly IGenericAttributeService _genericAttributeService;

        #endregion

        #region Ctor

        public FacebookAuthenticationEventConsumer(IGenericAttributeService genericAttributeService)
        {
            _genericAttributeService = genericAttributeService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Handle event
        /// </summary>
        /// <param name="eventMessage">Event message</param>
        public void HandleEvent(CustomerAutoRegisteredByExternalMethodEvent eventMessage)
        {
            if (eventMessage?.Customer == null || eventMessage.AuthenticationParameters == null)
                return;

            //handle event only for this authentication method
            if (!eventMessage.AuthenticationParameters.ProviderSystemName.Equals(FacebookAuthenticationDefaults.SystemName))
                return;

            //store some of the customer fields
            var firstName = eventMessage.AuthenticationParameters.Claims?.FirstOrDefault(claim => claim.Type == ClaimTypes.GivenName)?.Value;
            if (!string.IsNullOrEmpty(firstName))
                _genericAttributeService.SaveAttribute(eventMessage.Customer, QNetCustomerDefaults.FirstNameAttribute, firstName);

            var lastName = eventMessage.AuthenticationParameters.Claims?.FirstOrDefault(claim => claim.Type == ClaimTypes.Surname)?.Value;
            if (!string.IsNullOrEmpty(lastName))
                _genericAttributeService.SaveAttribute(eventMessage.Customer, QNetCustomerDefaults.LastNameAttribute, lastName);
        }

        #endregion
    }
}