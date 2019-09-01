using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Customers
{
    /// <summary>
    /// Represents a customer role model
    /// </summary>
    public partial class CustomerRoleModel : BaseQNetEntityModel
    {
        #region Ctor

        public CustomerRoleModel()
        {
            TaxDisplayTypeValues = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        [QNetResourceDisplayName("Admin.Customers.CustomerRoles.Fields.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Admin.Customers.CustomerRoles.Fields.FreeShipping")]
        public bool FreeShipping { get; set; }

        [QNetResourceDisplayName("Admin.Customers.CustomerRoles.Fields.TaxExempt")]
        public bool TaxExempt { get; set; }

        [QNetResourceDisplayName("Admin.Customers.CustomerRoles.Fields.Active")]
        public bool Active { get; set; }

        [QNetResourceDisplayName("Admin.Customers.CustomerRoles.Fields.IsSystemRole")]
        public bool IsSystemRole { get; set; }

        [QNetResourceDisplayName("Admin.Customers.CustomerRoles.Fields.SystemName")]
        public string SystemName { get; set; }

        [QNetResourceDisplayName("Admin.Customers.CustomerRoles.Fields.EnablePasswordLifetime")]
        public bool EnablePasswordLifetime { get; set; }

        [QNetResourceDisplayName("Admin.Customers.CustomerRoles.Fields.OverrideTaxDisplayType")]
        public bool OverrideTaxDisplayType { get; set; }

        [QNetResourceDisplayName("Admin.Customers.CustomerRoles.Fields.DefaultTaxDisplayType")]
        public int DefaultTaxDisplayTypeId { get; set; }

        public IList<SelectListItem> TaxDisplayTypeValues { get; set; }

        [QNetResourceDisplayName("Admin.Customers.CustomerRoles.Fields.PurchasedWithProduct")]
        public int PurchasedWithProductId { get; set; }

        [QNetResourceDisplayName("Admin.Customers.CustomerRoles.Fields.PurchasedWithProduct")]
        public string PurchasedWithProductName { get; set; }

        #endregion
    }
}