using System;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Orders
{
    /// <summary>
    /// Represents a return request model
    /// </summary>
    public partial class ReturnRequestModel : BaseQNetEntityModel
    {
        #region Properties

        [QNetResourceDisplayName("Admin.ReturnRequests.Fields.CustomNumber")]
        public string CustomNumber { get; set; }
        
        public int OrderId { get; set; }

        [QNetResourceDisplayName("Admin.ReturnRequests.Fields.CustomOrderNumber")]
        public string CustomOrderNumber { get; set; }

        [QNetResourceDisplayName("Admin.ReturnRequests.Fields.Customer")]
        public int CustomerId { get; set; }

        [QNetResourceDisplayName("Admin.ReturnRequests.Fields.Customer")]
        public string CustomerInfo { get; set; }

        public int ProductId { get; set; }

        [QNetResourceDisplayName("Admin.ReturnRequests.Fields.Product")]
        public string ProductName { get; set; }

        public string AttributeInfo { get; set; }

        [QNetResourceDisplayName("Admin.ReturnRequests.Fields.Quantity")]
        public int Quantity { get; set; }
        
        [QNetResourceDisplayName("Admin.ReturnRequests.Fields.ReasonForReturn")]
        public string ReasonForReturn { get; set; }
        
        [QNetResourceDisplayName("Admin.ReturnRequests.Fields.RequestedAction")]
        public string RequestedAction { get; set; }
        
        [QNetResourceDisplayName("Admin.ReturnRequests.Fields.CustomerComments")]
        public string CustomerComments { get; set; }

        [QNetResourceDisplayName("Admin.ReturnRequests.Fields.UploadedFile")]
        public Guid UploadedFileGuid { get; set; }
        
        [QNetResourceDisplayName("Admin.ReturnRequests.Fields.StaffNotes")]
        public string StaffNotes { get; set; }

        [QNetResourceDisplayName("Admin.ReturnRequests.Fields.Status")]
        public int ReturnRequestStatusId { get; set; }

        [QNetResourceDisplayName("Admin.ReturnRequests.Fields.Status")]
        public string ReturnRequestStatusStr { get; set; }

        [QNetResourceDisplayName("Admin.ReturnRequests.Fields.CreatedOn")]
        public DateTime CreatedOn { get; set; }

        #endregion
    }
}