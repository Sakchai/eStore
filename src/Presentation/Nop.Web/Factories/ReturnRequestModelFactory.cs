﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Tax;
using Nop.Services.Catalog;
using Nop.Services.Directory;
using Nop.Services.Helpers;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Services.Orders;
using Nop.Services.Seo;
using Nop.Web.Models.Order;

namespace Nop.Web.Factories
{
    /// <summary>
    /// Represents the return request model factory
    /// </summary>
    public partial class ReturnRequestModelFactory : IReturnRequestModelFactory
    {
        #region Fields

        private readonly ICurrencyService _currencyService;
        private readonly IDateTimeHelper _dateTimeHelper;
        private readonly IDownloadService _downloadService;
        private readonly ILocalizationService _localizationService;
        private readonly IOrderService _orderService;
        private readonly IPriceFormatter _priceFormatter;
        private readonly IProductService _productService;
        private readonly IReturnRequestService _returnRequestService;
        private readonly IStoreContext _storeContext;
        private readonly IUrlRecordService _urlRecordService;
        private readonly IWorkContext _workContext;
        private readonly OrderSettings _orderSettings;

        #endregion

        #region Ctor

        public ReturnRequestModelFactory(ICurrencyService currencyService,
            IDateTimeHelper dateTimeHelper,
            IDownloadService downloadService,
            ILocalizationService localizationService,
            IOrderService orderService,
            IPriceFormatter priceFormatter,
            IProductService productService,
            IReturnRequestService returnRequestService,
            IStoreContext storeContext,
            IUrlRecordService urlRecordService,
            IWorkContext workContext,
            OrderSettings orderSettings)
        {
            _currencyService = currencyService;
            _dateTimeHelper = dateTimeHelper;
            _downloadService = downloadService;
            _localizationService = localizationService;
            _orderService = orderService;
            _priceFormatter = priceFormatter;
            _productService = productService;
            _returnRequestService = returnRequestService;
            _storeContext = storeContext;
            _urlRecordService = urlRecordService;
            _workContext = workContext;
            _orderSettings = orderSettings;
        }

        #endregion

        #region Utilities

        /// <summary>
        /// Prepare the order item model
        /// </summary>
        /// <param name="orderItem">Order item</param>
        /// <returns>Order item model</returns>
        protected virtual async Task<SubmitReturnRequestModel.OrderItemModel> PrepareSubmitReturnRequestOrderItemModelAsync(OrderItem orderItem)
        {
            if (orderItem == null)
                throw new ArgumentNullException(nameof(orderItem));

            var order = await _orderService.GetOrderByIdAsync(orderItem.OrderId);
            var product = await _productService.GetProductByIdAsync(orderItem.ProductId);

            var model = new SubmitReturnRequestModel.OrderItemModel
            {
                Id = orderItem.Id,
                ProductId = product.Id,
                ProductName = await _localizationService.GetLocalizedAsync(product, x => x.Name),
                ProductSeName = await _urlRecordService.GetSeNameAsync(product),
                AttributeInfo = orderItem.AttributeDescription,
                Quantity = orderItem.Quantity
            };

            var languageId = (await _workContext.GetWorkingLanguageAsync()).Id;

            //unit price
            if (order.CustomerTaxDisplayType == TaxDisplayType.IncludingTax)
            {
                //including tax
                var unitPriceInclTaxInCustomerCurrency = _currencyService.ConvertCurrency(orderItem.UnitPriceInclTax, order.CurrencyRate);
                model.UnitPrice = await _priceFormatter.FormatPriceAsync(unitPriceInclTaxInCustomerCurrency, true, order.CustomerCurrencyCode, languageId, true);
            }
            else
            {
                //excluding tax
                var unitPriceExclTaxInCustomerCurrency = _currencyService.ConvertCurrency(orderItem.UnitPriceExclTax, order.CurrencyRate);
                model.UnitPrice = await _priceFormatter.FormatPriceAsync(unitPriceExclTaxInCustomerCurrency, true, order.CustomerCurrencyCode, languageId, false);
            }

            return model;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Prepare the submit return request model
        /// </summary>
        /// <param name="model">Submit return request model</param>
        /// <param name="order">Order</param>
        /// <returns>Submit return request model</returns>
        public virtual async Task<SubmitReturnRequestModel> PrepareSubmitReturnRequestModelAsync(SubmitReturnRequestModel model,
            Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            if (model == null)
                throw new ArgumentNullException(nameof(model));

            model.OrderId = order.Id;
            model.AllowFiles = _orderSettings.ReturnRequestsAllowFiles;
            model.CustomOrderNumber = order.CustomOrderNumber;

            //return reasons
            model.AvailableReturnReasons = await (await _returnRequestService.GetAllReturnRequestReasonsAsync())
                .SelectAwait(async rrr => new SubmitReturnRequestModel.ReturnRequestReasonModel
                {
                    Id = rrr.Id,
                    Name = await _localizationService.GetLocalizedAsync(rrr, x => x.Name)
                }).ToListAsync();

            //return actions
            model.AvailableReturnActions = await (await _returnRequestService.GetAllReturnRequestActionsAsync())
                .SelectAwait(async rra => new SubmitReturnRequestModel.ReturnRequestActionModel
                {
                    Id = rra.Id,
                    Name = await _localizationService.GetLocalizedAsync(rra, x => x.Name)
                })
                .ToListAsync();

            //returnable products
            var orderItems = await _orderService.GetOrderItemsAsync(order.Id, isNotReturnable: false);
            foreach (var orderItem in orderItems)
            {
                var orderItemModel = await PrepareSubmitReturnRequestOrderItemModelAsync(orderItem);
                model.Items.Add(orderItemModel);
            }

            return model;
        }

        /// <summary>
        /// Prepare the customer return requests model
        /// </summary>
        /// <returns>Customer return requests model</returns>
        public virtual async Task<CustomerReturnRequestsModel> PrepareCustomerReturnRequestsModelAsync()
        {
            var model = new CustomerReturnRequestsModel();

            var returnRequests = await _returnRequestService.SearchReturnRequestsAsync((await _storeContext.GetCurrentStoreAsync()).Id, (await _workContext.GetCurrentCustomerAsync()).Id);
            foreach (var returnRequest in returnRequests)
            {
                var orderItem = await _orderService.GetOrderItemByIdAsync(returnRequest.OrderItemId);
                if (orderItem != null)
                {
                    var product = await _productService.GetProductByIdAsync(orderItem.ProductId);

                    var download = await _downloadService.GetDownloadByIdAsync(returnRequest.UploadedFileId);

                    var itemModel = new CustomerReturnRequestsModel.ReturnRequestModel
                    {
                        Id = returnRequest.Id,
                        CustomNumber = returnRequest.CustomNumber,
                        ReturnRequestStatus = await _localizationService.GetLocalizedEnumAsync(returnRequest.ReturnRequestStatus),
                        ProductId = product.Id,
                        ProductName = await _localizationService.GetLocalizedAsync(product, x => x.Name),
                        ProductSeName = await _urlRecordService.GetSeNameAsync(product),
                        Quantity = returnRequest.Quantity,
                        ReturnAction = returnRequest.RequestedAction,
                        ReturnReason = returnRequest.ReasonForReturn,
                        Comments = returnRequest.CustomerComments,
                        UploadedFileGuid = download?.DownloadGuid ?? Guid.Empty,
                        CreatedOn = await _dateTimeHelper.ConvertToUserTimeAsync(returnRequest.CreatedOnUtc, DateTimeKind.Utc),
                    };
                    model.Items.Add(itemModel);
                }
            }

            return model;
        }

        #endregion
    }
}