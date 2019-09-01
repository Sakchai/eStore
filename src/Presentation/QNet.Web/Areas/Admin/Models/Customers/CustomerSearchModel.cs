using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Customers
{
    /// <summary>
    /// Represents a customer search model
    /// </summary>
    public partial class CustomerSearchModel : BaseSearchModel, IAclSupportedModel
    {
        #region Ctor

        public CustomerSearchModel()
        {
            SelectedCustomerRoleIds = new List<int>();
            AvailableCustomerRoles = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        [QNetResourceDisplayName("Admin.Customers.Customers.List.CustomerRoles")]
        public IList<int> SelectedCustomerRoleIds { get; set; }

        public IList<SelectListItem> AvailableCustomerRoles { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.List.SearchEmail")]
        public string SearchEmail { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.List.SearchUsername")]
        public string SearchUsername { get; set; }

        public bool UsernamesEnabled { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.List.SearchFirstName")]
        public string SearchFirstName { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.List.SearchLastName")]
        public string SearchLastName { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.List.SearchDateOfBirth")]
        public string SearchDayOfBirth { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.List.SearchDateOfBirth")]
        public string SearchMonthOfBirth { get; set; }

        public bool DateOfBirthEnabled { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.List.SearchCompany")]
        public string SearchCompany { get; set; }

        public bool CompanyEnabled { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.List.SearchPhone")]
        public string SearchPhone { get; set; }

        public bool PhoneEnabled { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.List.SearchZipCode")]
        public string SearchZipPostalCode { get; set; }

        public bool ZipPostalCodeEnabled { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.List.SearchIpAddress")]
        public string SearchIpAddress { get; set; }

        public bool AvatarEnabled { get; internal set; }

        #endregion
    }
}