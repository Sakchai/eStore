using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using QNet.Core.Domain.Catalog;
using QNet.Web.Areas.Admin.Models.Common;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Vendors
{
    /// <summary>
    /// Represents a vendor model
    /// </summary>
    public partial class VendorModel : BaseQNetEntityModel, ILocalizedModel<VendorLocalizedModel>
    {
        #region Ctor

        public VendorModel()
        {
            if (PageSize < 1)
                PageSize = 5;

            Address = new AddressModel();
            VendorAttributes = new List<VendorAttributeModel>();
            Locales = new List<VendorLocalizedModel>();
            AssociatedCustomers = new List<VendorAssociatedCustomerModel>();
            VendorNoteSearchModel = new VendorNoteSearchModel();
        }

        #endregion

        #region Properties

        [QNetResourceDisplayName("Admin.Vendors.Fields.Name")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [QNetResourceDisplayName("Admin.Vendors.Fields.Email")]
        public string Email { get; set; }

        [QNetResourceDisplayName("Admin.Vendors.Fields.Description")]
        public string Description { get; set; }

        [UIHint("Picture")]
        [QNetResourceDisplayName("Admin.Vendors.Fields.Picture")]
        public int PictureId { get; set; }

        [QNetResourceDisplayName("Admin.Vendors.Fields.AdminComment")]
        public string AdminComment { get; set; }

        public AddressModel Address { get; set; }

        [QNetResourceDisplayName("Admin.Vendors.Fields.Active")]
        public bool Active { get; set; }

        [QNetResourceDisplayName("Admin.Vendors.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }        

        [QNetResourceDisplayName("Admin.Vendors.Fields.MetaKeywords")]
        public string MetaKeywords { get; set; }

        [QNetResourceDisplayName("Admin.Vendors.Fields.MetaDescription")]
        public string MetaDescription { get; set; }

        [QNetResourceDisplayName("Admin.Vendors.Fields.MetaTitle")]
        public string MetaTitle { get; set; }

        [QNetResourceDisplayName("Admin.Vendors.Fields.SeName")]
        public string SeName { get; set; }

        [QNetResourceDisplayName("Admin.Vendors.Fields.PageSize")]
        public int PageSize { get; set; }

        [QNetResourceDisplayName("Admin.Vendors.Fields.AllowCustomersToSelectPageSize")]
        public bool AllowCustomersToSelectPageSize { get; set; }

        [QNetResourceDisplayName("Admin.Vendors.Fields.PageSizeOptions")]
        public string PageSizeOptions { get; set; }

        public List<VendorAttributeModel> VendorAttributes { get; set; }

        public IList<VendorLocalizedModel> Locales { get; set; }

        [QNetResourceDisplayName("Admin.Vendors.Fields.AssociatedCustomerEmails")]
        public IList<VendorAssociatedCustomerModel> AssociatedCustomers { get; set; }

        //vendor notes
        [QNetResourceDisplayName("Admin.Vendors.VendorNotes.Fields.Note")]
        public string AddVendorNoteMessage { get; set; }

        public VendorNoteSearchModel VendorNoteSearchModel { get; set; }

        #endregion

        #region Nested classes
        
        public partial class VendorAttributeModel : BaseQNetEntityModel
        {
            public VendorAttributeModel()
            {
                Values = new List<VendorAttributeValueModel>();
            }

            public string Name { get; set; }

            public bool IsRequired { get; set; }

            /// <summary>
            /// Default value for textboxes
            /// </summary>
            public string DefaultValue { get; set; }

            public AttributeControlType AttributeControlType { get; set; }

            public IList<VendorAttributeValueModel> Values { get; set; }
        }

        public partial class VendorAttributeValueModel : BaseQNetEntityModel
        {
            public string Name { get; set; }

            public bool IsPreSelected { get; set; }
        }

        #endregion
    }

    public partial class VendorLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }

        [QNetResourceDisplayName("Admin.Vendors.Fields.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Admin.Vendors.Fields.Description")]
        public string Description { get; set; }

        [QNetResourceDisplayName("Admin.Vendors.Fields.MetaKeywords")]
        public string MetaKeywords { get; set; }

        [QNetResourceDisplayName("Admin.Vendors.Fields.MetaDescription")]
        public string MetaDescription { get; set; }

        [QNetResourceDisplayName("Admin.Vendors.Fields.MetaTitle")]
        public string MetaTitle { get; set; }

        [QNetResourceDisplayName("Admin.Vendors.Fields.SeName")]
        public string SeName { get; set; }
    }
}