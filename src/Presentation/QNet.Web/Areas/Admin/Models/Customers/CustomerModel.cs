using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using QNet.Core.Domain.Catalog;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Customers
{
    /// <summary>
    /// Represents a customer model
    /// </summary>
    public partial class CustomerModel : BaseQNetEntityModel, IAclSupportedModel
    {
        #region Ctor

        public CustomerModel()
        {
            AvailableTimeZones = new List<SelectListItem>();
            SendEmail = new SendEmailModel() { SendImmediately = true };
            SendPm = new SendPmModel();

            SelectedCustomerRoleIds = new List<int>();
            AvailableCustomerRoles = new List<SelectListItem>();

            AvailableCountries = new List<SelectListItem>();
            AvailableStates = new List<SelectListItem>();
            AvailableVendors = new List<SelectListItem>();
            CustomerAttributes = new List<CustomerAttributeModel>();
            AvailableNewsletterSubscriptionStores = new List<SelectListItem>();
            SelectedNewsletterSubscriptionStoreIds = new List<int>();
            AddRewardPoints = new AddRewardPointsToCustomerModel();
            CustomerRewardPointsSearchModel = new CustomerRewardPointsSearchModel();
            CustomerAddressSearchModel = new CustomerAddressSearchModel();
            CustomerOrderSearchModel = new CustomerOrderSearchModel();
            CustomerShoppingCartSearchModel = new CustomerShoppingCartSearchModel();
            CustomerActivityLogSearchModel = new CustomerActivityLogSearchModel();
            CustomerBackInStockSubscriptionSearchModel = new CustomerBackInStockSubscriptionSearchModel();
            CustomerAssociatedExternalAuthRecordsSearchModel = new CustomerAssociatedExternalAuthRecordsSearchModel();
        }

        #endregion

        #region Properties

        public bool UsernamesEnabled { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.Fields.Username")]
        public string Username { get; set; }

        [DataType(DataType.EmailAddress)]
        [QNetResourceDisplayName("Admin.Customers.Customers.Fields.Email")]
        public string Email { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.Fields.Password")]
        [DataType(DataType.Password)]
        [NoTrim]
        public string Password { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.Fields.Vendor")]
        public int VendorId { get; set; }

        public IList<SelectListItem> AvailableVendors { get; set; }

        //form fields & properties
        public bool GenderEnabled { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.Fields.Gender")]
        public string Gender { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.Fields.FirstName")]
        public string FirstName { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.Fields.LastName")]
        public string LastName { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.Fields.FullName")]
        public string FullName { get; set; }

        public bool DateOfBirthEnabled { get; set; }

        [UIHint("DateNullable")]
        [QNetResourceDisplayName("Admin.Customers.Customers.Fields.DateOfBirth")]
        public DateTime? DateOfBirth { get; set; }

        public bool CompanyEnabled { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.Fields.Company")]
        public string Company { get; set; }

        public bool StreetAddressEnabled { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.Fields.StreetAddress")]
        public string StreetAddress { get; set; }

        public bool StreetAddress2Enabled { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.Fields.StreetAddress2")]
        public string StreetAddress2 { get; set; }

        public bool ZipPostalCodeEnabled { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.Fields.ZipPostalCode")]
        public string ZipPostalCode { get; set; }

        public bool CityEnabled { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.Fields.City")]
        public string City { get; set; }

        public bool CountyEnabled { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.Fields.County")]
        public string County { get; set; }

        public bool CountryEnabled { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.Fields.Country")]
        public int CountryId { get; set; }

        public IList<SelectListItem> AvailableCountries { get; set; }

        public bool StateProvinceEnabled { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.Fields.StateProvince")]
        public int StateProvinceId { get; set; }

        public IList<SelectListItem> AvailableStates { get; set; }

        public bool PhoneEnabled { get; set; }

        [DataType(DataType.PhoneNumber)]
        [QNetResourceDisplayName("Admin.Customers.Customers.Fields.Phone")]
        public string Phone { get; set; }

        public bool FaxEnabled { get; set; }

        [DataType(DataType.PhoneNumber)]
        [QNetResourceDisplayName("Admin.Customers.Customers.Fields.Fax")]
        public string Fax { get; set; }

        public List<CustomerAttributeModel> CustomerAttributes { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.Fields.RegisteredInStore")]
        public string RegisteredInStore { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.Fields.AdminComment")]
        public string AdminComment { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.Fields.IsTaxExempt")]
        public bool IsTaxExempt { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.Fields.Active")]
        public bool Active { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.Fields.Affiliate")]
        public int AffiliateId { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.Fields.Affiliate")]
        public string AffiliateName { get; set; }

        //time zone
        [QNetResourceDisplayName("Admin.Customers.Customers.Fields.TimeZoneId")]
        public string TimeZoneId { get; set; }

        public bool AllowCustomersToSetTimeZone { get; set; }

        public IList<SelectListItem> AvailableTimeZones { get; set; }

        //EU VAT
        [QNetResourceDisplayName("Admin.Customers.Customers.Fields.VatNumber")]
        public string VatNumber { get; set; }

        public string VatNumberStatusNote { get; set; }

        public bool DisplayVatNumber { get; set; }

        //registration date
        [QNetResourceDisplayName("Admin.Customers.Customers.Fields.CreatedOn")]
        public DateTime CreatedOn { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.Fields.LastActivityDate")]
        public DateTime LastActivityDate { get; set; }

        //IP address
        [QNetResourceDisplayName("Admin.Customers.Customers.Fields.IPAddress")]
        public string LastIpAddress { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.Fields.LastVisitedPage")]
        public string LastVisitedPage { get; set; }

        //customer roles
        [QNetResourceDisplayName("Admin.Customers.Customers.Fields.CustomerRoles")]
        public string CustomerRoleNames { get; set; }

        public IList<SelectListItem> AvailableCustomerRoles { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.Fields.CustomerRoles")]
        public IList<int> SelectedCustomerRoleIds { get; set; }

        //newsletter subscriptions (per store)
        [QNetResourceDisplayName("Admin.Customers.Customers.Fields.Newsletter")]
        public IList<SelectListItem> AvailableNewsletterSubscriptionStores { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.Fields.Newsletter")]
        public IList<int> SelectedNewsletterSubscriptionStoreIds { get; set; }

        //reward points history
        public bool DisplayRewardPointsHistory { get; set; }

        public AddRewardPointsToCustomerModel AddRewardPoints { get; set; }

        public CustomerRewardPointsSearchModel CustomerRewardPointsSearchModel { get; set; }

        //send email model
        public SendEmailModel SendEmail { get; set; }

        //send PM model
        public SendPmModel SendPm { get; set; }

        //send the welcome message
        public bool AllowSendingOfWelcomeMessage { get; set; }

        //re-send the activation message
        public bool AllowReSendingOfActivationMessage { get; set; }

        //GDPR enabled
        public bool GdprEnabled { get; set; }
        
        public string AvatarUrl { get; internal set; }

        public CustomerAddressSearchModel CustomerAddressSearchModel { get; set; }

        public CustomerOrderSearchModel CustomerOrderSearchModel { get; set; }

        public CustomerShoppingCartSearchModel CustomerShoppingCartSearchModel { get; set; }

        public CustomerActivityLogSearchModel CustomerActivityLogSearchModel { get; set; }

        public CustomerBackInStockSubscriptionSearchModel CustomerBackInStockSubscriptionSearchModel { get; set; }

        public CustomerAssociatedExternalAuthRecordsSearchModel CustomerAssociatedExternalAuthRecordsSearchModel { get; set; }

        #endregion

        #region Nested classes

        public partial class SendEmailModel : BaseQNetModel
        {
            [QNetResourceDisplayName("Admin.Customers.Customers.SendEmail.Subject")]
            public string Subject { get; set; }

            [QNetResourceDisplayName("Admin.Customers.Customers.SendEmail.Body")]
            public string Body { get; set; }

            [QNetResourceDisplayName("Admin.Customers.Customers.SendEmail.SendImmediately")]
            public bool SendImmediately { get; set; }

            [QNetResourceDisplayName("Admin.Customers.Customers.SendEmail.DontSendBeforeDate")]
            [UIHint("DateTimeNullable")]
            public DateTime? DontSendBeforeDate { get; set; }
        }

        public partial class SendPmModel : BaseQNetModel
        {
            [QNetResourceDisplayName("Admin.Customers.Customers.SendPM.Subject")]
            public string Subject { get; set; }

            [QNetResourceDisplayName("Admin.Customers.Customers.SendPM.Message")]
            public string Message { get; set; }
        }

        public partial class CustomerAttributeModel : BaseQNetEntityModel
        {
            public CustomerAttributeModel()
            {
                Values = new List<CustomerAttributeValueModel>();
            }

            public string Name { get; set; }

            public bool IsRequired { get; set; }

            /// <summary>
            /// Default value for textboxes
            /// </summary>
            public string DefaultValue { get; set; }

            public AttributeControlType AttributeControlType { get; set; }

            public IList<CustomerAttributeValueModel> Values { get; set; }
        }

        public partial class CustomerAttributeValueModel : BaseQNetEntityModel
        {
            public string Name { get; set; }

            public bool IsPreSelected { get; set; }
        }

        #endregion
    }
}