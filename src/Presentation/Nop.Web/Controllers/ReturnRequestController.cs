﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Media;
using Nop.Core.Domain.Orders;
using Nop.Core.Infrastructure;
using Nop.Services.Customers;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Services.Messages;
using Nop.Services.Orders;
using Nop.Web.Factories;
using Nop.Web.Models.Order;

namespace Nop.Web.Controllers
{
    [AutoValidateAntiforgeryToken]
    public partial class ReturnRequestController : BasePublicController
    {
        #region Fields

        private readonly ICustomerService _customerService;
        private readonly ICustomNumberFormatter _customNumberFormatter;
        private readonly IDownloadService _downloadService;
        private readonly ILocalizationService _localizationService;
        private readonly INopFileProvider _fileProvider;
        private readonly IOrderProcessingService _orderProcessingService;
        private readonly IOrderService _orderService;
        private readonly IReturnRequestModelFactory _returnRequestModelFactory;
        private readonly IReturnRequestService _returnRequestService;
        private readonly IStoreContext _storeContext;
        private readonly IWorkContext _workContext;
        private readonly IWorkflowMessageService _workflowMessageService;
        private readonly LocalizationSettings _localizationSettings;
        private readonly OrderSettings _orderSettings;

        #endregion

        #region Ctor

        public ReturnRequestController(ICustomerService customerService,
            ICustomNumberFormatter customNumberFormatter,
            IDownloadService downloadService,
            ILocalizationService localizationService,
            INopFileProvider fileProvider,
            IOrderProcessingService orderProcessingService,
            IOrderService orderService,
            IReturnRequestModelFactory returnRequestModelFactory,
            IReturnRequestService returnRequestService,
            IStoreContext storeContext,
            IWorkContext workContext,
            IWorkflowMessageService workflowMessageService,
            LocalizationSettings localizationSettings,
            OrderSettings orderSettings)
        {
            _customerService = customerService;
            _customNumberFormatter = customNumberFormatter;
            _downloadService = downloadService;
            _localizationService = localizationService;
            _fileProvider = fileProvider;
            _orderProcessingService = orderProcessingService;
            _orderService = orderService;
            _returnRequestModelFactory = returnRequestModelFactory;
            _returnRequestService = returnRequestService;
            _storeContext = storeContext;
            _workContext = workContext;
            _workflowMessageService = workflowMessageService;
            _localizationSettings = localizationSettings;
            _orderSettings = orderSettings;
        }

        #endregion

        #region Methods

        public virtual async Task<IActionResult> CustomerReturnRequests()
        {
            if (!await _customerService.IsRegisteredAsync(await _workContext.GetCurrentCustomerAsync()))
                return Challenge();

            var model = await _returnRequestModelFactory.PrepareCustomerReturnRequestsModelAsync();
            return View(model);
        }

        public virtual async Task<IActionResult> ReturnRequest(int orderId)
        {
            var order = await _orderService.GetOrderByIdAsync(orderId);
            if (order == null || order.Deleted || (await _workContext.GetCurrentCustomerAsync()).Id != order.CustomerId)
                return Challenge();

            if (!await _orderProcessingService.IsReturnRequestAllowedAsync(order))
                return RedirectToRoute("Homepage");

            var model = new SubmitReturnRequestModel();
            model = await _returnRequestModelFactory.PrepareSubmitReturnRequestModelAsync(model, order);
            return View(model);
        }

        [HttpPost, ActionName("ReturnRequest")]
        public virtual async Task<IActionResult> ReturnRequestSubmit(int orderId, SubmitReturnRequestModel model, IFormCollection form)
        {
            var order = await _orderService.GetOrderByIdAsync(orderId);
            if (order == null || order.Deleted || (await _workContext.GetCurrentCustomerAsync()).Id != order.CustomerId)
                return Challenge();

            if (!await _orderProcessingService.IsReturnRequestAllowedAsync(order))
                return RedirectToRoute("Homepage");

            var count = 0;

            var downloadId = 0;
            if (_orderSettings.ReturnRequestsAllowFiles)
            {
                var download = await _downloadService.GetDownloadByGuidAsync(model.UploadedFileGuid);
                if (download != null)
                    downloadId = download.Id;
            }

            //returnable products
            var orderItems = await _orderService.GetOrderItemsAsync(order.Id, isNotReturnable: false);
            foreach (var orderItem in orderItems)
            {
                var quantity = 0; //parse quantity
                foreach (var formKey in form.Keys)
                    if (formKey.Equals($"quantity{orderItem.Id}", StringComparison.InvariantCultureIgnoreCase))
                    {
                        int.TryParse(form[formKey], out quantity);
                        break;
                    }
                if (quantity > 0)
                {
                    var rrr = await _returnRequestService.GetReturnRequestReasonByIdAsync(model.ReturnRequestReasonId);
                    var rra = await _returnRequestService.GetReturnRequestActionByIdAsync(model.ReturnRequestActionId);

                    var rr = new ReturnRequest
                    {
                        CustomNumber = "",
                        StoreId = (await _storeContext.GetCurrentStoreAsync()).Id,
                        OrderItemId = orderItem.Id,
                        Quantity = quantity,
                        CustomerId = (await _workContext.GetCurrentCustomerAsync()).Id,
                        ReasonForReturn = rrr != null ? await _localizationService.GetLocalizedAsync(rrr, x => x.Name) : "not available",
                        RequestedAction = rra != null ? await _localizationService.GetLocalizedAsync(rra, x => x.Name) : "not available",
                        CustomerComments = model.Comments,
                        UploadedFileId = downloadId,
                        StaffNotes = string.Empty,
                        ReturnRequestStatus = ReturnRequestStatus.Pending,
                        CreatedOnUtc = DateTime.UtcNow,
                        UpdatedOnUtc = DateTime.UtcNow
                    };

                    await _returnRequestService.InsertReturnRequestAsync(rr);

                    //set return request custom number
                    rr.CustomNumber = _customNumberFormatter.GenerateReturnRequestCustomNumber(rr);
                    await _customerService.UpdateCustomerAsync(await _workContext.GetCurrentCustomerAsync());
                    await _returnRequestService.UpdateReturnRequestAsync(rr);

                    //notify store owner
                    await _workflowMessageService.SendNewReturnRequestStoreOwnerNotificationAsync(rr, orderItem, order, _localizationSettings.DefaultAdminLanguageId);
                    //notify customer
                    await _workflowMessageService.SendNewReturnRequestCustomerNotificationAsync(rr, orderItem, order);

                    count++;
                }
            }

            model = await _returnRequestModelFactory.PrepareSubmitReturnRequestModelAsync(model, order);
            if (count > 0)
                model.Result = await _localizationService.GetResourceAsync("ReturnRequests.Submitted");
            else
                model.Result = await _localizationService.GetResourceAsync("ReturnRequests.NoItemsSubmitted");

            return View(model);
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public virtual async Task<IActionResult> UploadFileReturnRequest()
        {
            if (!_orderSettings.ReturnRequestsEnabled || !_orderSettings.ReturnRequestsAllowFiles)
            {
                return Json(new
                {
                    success = false,
                    downloadGuid = Guid.Empty,
                });
            }

            var httpPostedFile = Request.Form.Files.FirstOrDefault();
            if (httpPostedFile == null)
            {
                return Json(new
                {
                    success = false,
                    message = "No file uploaded",
                    downloadGuid = Guid.Empty,
                });
            }

            var fileBinary = await _downloadService.GetDownloadBitsAsync(httpPostedFile);

            var qqFileNameParameter = "qqfilename";
            var fileName = httpPostedFile.FileName;
            if (string.IsNullOrEmpty(fileName) && Request.Form.ContainsKey(qqFileNameParameter))
                fileName = Request.Form[qqFileNameParameter].ToString();
            //remove path (passed in IE)
            fileName = _fileProvider.GetFileName(fileName);

            var contentType = httpPostedFile.ContentType;

            var fileExtension = _fileProvider.GetFileExtension(fileName);
            if (!string.IsNullOrEmpty(fileExtension))
                fileExtension = fileExtension.ToLowerInvariant();

            var validationFileMaximumSize = _orderSettings.ReturnRequestsFileMaximumSize;
            if (validationFileMaximumSize > 0)
            {
                //compare in bytes
                var maxFileSizeBytes = validationFileMaximumSize * 1024;
                if (fileBinary.Length > maxFileSizeBytes)
                {
                    return Json(new
                    {
                        success = false,
                        message = string.Format(await _localizationService.GetResourceAsync("ShoppingCart.MaximumUploadedFileSize"), validationFileMaximumSize),
                        downloadGuid = Guid.Empty,
                    });
                }
            }

            var download = new Download
            {
                DownloadGuid = Guid.NewGuid(),
                UseDownloadUrl = false,
                DownloadUrl = "",
                DownloadBinary = fileBinary,
                ContentType = contentType,
                //we store filename without extension for downloads
                Filename = _fileProvider.GetFileNameWithoutExtension(fileName),
                Extension = fileExtension,
                IsNew = true
            };
            await _downloadService.InsertDownloadAsync(download);

            //when returning JSON the mime-type must be set to text/plain
            //otherwise some browsers will pop-up a "Save As" dialog.
            return Json(new
            {
                success = true,
                message = await _localizationService.GetResourceAsync("ShoppingCart.FileUploaded"),
                downloadUrl = Url.Action("GetFileUpload", "Download", new { downloadId = download.DownloadGuid }),
                downloadGuid = download.DownloadGuid,
            });
        }

        #endregion
    }
}