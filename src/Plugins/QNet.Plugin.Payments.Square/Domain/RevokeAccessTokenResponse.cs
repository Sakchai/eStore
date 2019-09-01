using Newtonsoft.Json;

namespace QNet.Plugin.Payments.Square.Domain
{
    /// <summary>
    /// Represents returned values of request to revoke access token 
    /// </summary>
    public class RevokeAccessTokenResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether token was successfully revoked
        /// </summary>
        [JsonProperty(PropertyName = "success")]
        public bool SuccessfullyRevoked { get; set; }
    }
}