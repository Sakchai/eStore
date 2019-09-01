using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Settings
{
    /// <summary>
    /// Represents an address settings model
    /// </summary>
    public partial class AddressSettingsModel : BaseQNetModel, ISettingsModel
    {
        #region Properties

        public int ActiveStoreScopeConfiguration { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.CustomerUser.AddressFormFields.CompanyEnabled")]
        public bool CompanyEnabled { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.CustomerUser.AddressFormFields.CompanyRequired")]
        public bool CompanyRequired { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.CustomerUser.AddressFormFields.StreetAddressEnabled")]
        public bool StreetAddressEnabled { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.CustomerUser.AddressFormFields.StreetAddressRequired")]
        public bool StreetAddressRequired { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.CustomerUser.AddressFormFields.StreetAddress2Enabled")]
        public bool StreetAddress2Enabled { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.CustomerUser.AddressFormFields.StreetAddress2Required")]
        public bool StreetAddress2Required { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.CustomerUser.AddressFormFields.ZipPostalCodeEnabled")]
        public bool ZipPostalCodeEnabled { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.CustomerUser.AddressFormFields.ZipPostalCodeRequired")]
        public bool ZipPostalCodeRequired { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.CustomerUser.AddressFormFields.CityEnabled")]
        public bool CityEnabled { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.CustomerUser.AddressFormFields.CityRequired")]
        public bool CityRequired { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.CustomerUser.AddressFormFields.CountyEnabled")]
        public bool CountyEnabled { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.CustomerUser.AddressFormFields.CountyRequired")]
        public bool CountyRequired { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.CustomerUser.AddressFormFields.CountryEnabled")]
        public bool CountryEnabled { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.CustomerUser.AddressFormFields.StateProvinceEnabled")]
        public bool StateProvinceEnabled { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.CustomerUser.AddressFormFields.PhoneEnabled")]
        public bool PhoneEnabled { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.CustomerUser.AddressFormFields.PhoneRequired")]
        public bool PhoneRequired { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.CustomerUser.AddressFormFields.FaxEnabled")]
        public bool FaxEnabled { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.CustomerUser.AddressFormFields.FaxRequired")]
        public bool FaxRequired { get; set; }

        #endregion
    }
}