using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Models.Common
{
    public partial class AddressModel : BaseQNetEntityModel
    {
        public AddressModel()
        {
            AvailableCountries = new List<SelectListItem>();
            AvailableStates = new List<SelectListItem>();
            CustomAddressAttributes = new List<AddressAttributeModel>();
        }

        [QNetResourceDisplayName("Address.Fields.FirstName")]
        public string FirstName { get; set; }
        [QNetResourceDisplayName("Address.Fields.LastName")]
        public string LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        [QNetResourceDisplayName("Address.Fields.Email")]
        public string Email { get; set; }


        public bool CompanyEnabled { get; set; }
        public bool CompanyRequired { get; set; }
        [QNetResourceDisplayName("Address.Fields.Company")]
        public string Company { get; set; }

        public bool CountryEnabled { get; set; }
        [QNetResourceDisplayName("Address.Fields.Country")]
        public int? CountryId { get; set; }
        [QNetResourceDisplayName("Address.Fields.Country")]
        public string CountryName { get; set; }

        public bool StateProvinceEnabled { get; set; }
        [QNetResourceDisplayName("Address.Fields.StateProvince")]
        public int? StateProvinceId { get; set; }
        [QNetResourceDisplayName("Address.Fields.StateProvince")]
        public string StateProvinceName { get; set; }

        public bool CountyEnabled { get; set; }
        public bool CountyRequired { get; set; }
        [QNetResourceDisplayName("Address.Fields.County")]
        public string County { get; set; }

        public bool CityEnabled { get; set; }
        public bool CityRequired { get; set; }
        [QNetResourceDisplayName("Address.Fields.City")]
        public string City { get; set; }

        public bool StreetAddressEnabled { get; set; }
        public bool StreetAddressRequired { get; set; }
        [QNetResourceDisplayName("Address.Fields.Address1")]
        public string Address1 { get; set; }

        public bool StreetAddress2Enabled { get; set; }
        public bool StreetAddress2Required { get; set; }
        [QNetResourceDisplayName("Address.Fields.Address2")]
        public string Address2 { get; set; }

        public bool ZipPostalCodeEnabled { get; set; }
        public bool ZipPostalCodeRequired { get; set; }
        [QNetResourceDisplayName("Address.Fields.ZipPostalCode")]
        public string ZipPostalCode { get; set; }

        public bool PhoneEnabled { get; set; }
        public bool PhoneRequired { get; set; }
        [DataType(DataType.PhoneNumber)]
        [QNetResourceDisplayName("Address.Fields.PhoneNumber")]
        public string PhoneNumber { get; set; }

        public bool FaxEnabled { get; set; }
        public bool FaxRequired { get; set; }
        [QNetResourceDisplayName("Address.Fields.FaxNumber")]
        public string FaxNumber { get; set; }
        
        public IList<SelectListItem> AvailableCountries { get; set; }
        public IList<SelectListItem> AvailableStates { get; set; }

        public string FormattedCustomAddressAttributes { get; set; }
        public IList<AddressAttributeModel> CustomAddressAttributes { get; set; }
    }
}