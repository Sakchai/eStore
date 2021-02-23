﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Data;
using Nop.Services.Common;
using Nop.Services.Messages;

namespace Nop.Services.Catalog
{
    /// <summary>
    /// Back in stock subscription service
    /// </summary>
    public partial class BackInStockSubscriptionService : IBackInStockSubscriptionService
    {
        #region Fields

        private readonly IGenericAttributeService _genericAttributeService;
        private readonly IRepository<BackInStockSubscription> _backInStockSubscriptionRepository;
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IWorkflowMessageService _workflowMessageService;

        #endregion

        #region Ctor

        public BackInStockSubscriptionService(IGenericAttributeService genericAttributeService,
            IRepository<BackInStockSubscription> backInStockSubscriptionRepository,
            IRepository<Customer> customerRepository,
            IRepository<Product> productRepository,
            IWorkflowMessageService workflowMessageService)
        {
            _genericAttributeService = genericAttributeService;
            _backInStockSubscriptionRepository = backInStockSubscriptionRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _workflowMessageService = workflowMessageService;
        }

        #endregion

        #region Utilities

        /// <summary>
        /// Gets all subscriptions
        /// </summary>
        /// <param name="productId">Product identifier</param>
        /// <param name="storeId">Store identifier; pass 0 to load all records</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Subscriptions</returns>
        protected virtual async Task<IPagedList<BackInStockSubscription>> GetAllSubscriptionsByProductIdAsync(int productId,
            int storeId = 0, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            return await _backInStockSubscriptionRepository.GetAllPagedAsync(query =>
            {
                //product
                query = query.Where(biss => biss.ProductId == productId);
                //store
                if (storeId > 0)
                    query = query.Where(biss => biss.StoreId == storeId);
                //customer
                query = from biss in query
                    join c in _customerRepository.Table on biss.CustomerId equals c.Id
                    where c.Active && !c.Deleted
                    select biss;

                query = query.OrderByDescending(biss => biss.CreatedOnUtc);

                return query;
            }, pageIndex, pageSize);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Delete a back in stock subscription
        /// </summary>
        /// <param name="subscription">Subscription</param>
        public virtual async Task DeleteSubscriptionAsync(BackInStockSubscription subscription)
        {
            await _backInStockSubscriptionRepository.DeleteAsync(subscription);
        }

        /// <summary>
        /// Gets all subscriptions
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <param name="storeId">Store identifier; pass 0 to load all records</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Subscriptions</returns>
        public virtual async Task<IPagedList<BackInStockSubscription>> GetAllSubscriptionsByCustomerIdAsync(int customerId,
            int storeId = 0, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            return await _backInStockSubscriptionRepository.GetAllPagedAsync(query =>
            {
                //customer
                query = query.Where(biss => biss.CustomerId == customerId);

                //store
                if (storeId > 0)
                    query = query.Where(biss => biss.StoreId == storeId);

                //product
                query = from q in query
                    join p in _productRepository.Table on q.ProductId equals p.Id
                    where !p.Deleted
                    select q;

                query = query.OrderByDescending(biss => biss.CreatedOnUtc);

                return query;
            }, pageIndex, pageSize);
        }

        /// <summary>
        /// Gets all subscriptions
        /// </summary>
        /// <param name="customerId">Customer id</param>
        /// <param name="productId">Product identifier</param>
        /// <param name="storeId">Store identifier</param>
        /// <returns>Subscriptions</returns>
        public virtual async Task<BackInStockSubscription> FindSubscriptionAsync(int customerId, int productId, int storeId)
        {
            var query = from biss in _backInStockSubscriptionRepository.Table
                        orderby biss.CreatedOnUtc descending
                        where biss.CustomerId == customerId &&
                              biss.ProductId == productId &&
                              biss.StoreId == storeId
                        select biss;

            var subscription = await query.FirstOrDefaultAsync();

            return subscription;
        }

        /// <summary>
        /// Gets a subscription
        /// </summary>
        /// <param name="subscriptionId">Subscription identifier</param>
        /// <returns>Subscription</returns>
        public virtual async Task<BackInStockSubscription> GetSubscriptionByIdAsync(int subscriptionId)
        {
            return await _backInStockSubscriptionRepository.GetByIdAsync(subscriptionId, cache => default);
        }

        /// <summary>
        /// Inserts subscription
        /// </summary>
        /// <param name="subscription">Subscription</param>
        public virtual async Task InsertSubscriptionAsync(BackInStockSubscription subscription)
        {
            await _backInStockSubscriptionRepository.InsertAsync(subscription);
        }
        
        /// <summary>
        /// Send notification to subscribers
        /// </summary>
        /// <param name="product">Product</param>
        /// <returns>Number of sent email</returns>
        public virtual async Task<int> SendNotificationsToSubscribersAsync(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            var result = 0;
            var subscriptions = await GetAllSubscriptionsByProductIdAsync(product.Id);
            foreach (var subscription in subscriptions)
            {
                var customerLanguageId = await _genericAttributeService.GetAttributeAsync<Customer, int>(subscription.CustomerId, NopCustomerDefaults.LanguageIdAttribute, subscription.StoreId);

                result += (await _workflowMessageService.SendBackInStockNotificationAsync(subscription, customerLanguageId)).Count;
            }

            for (var i = 0; i <= subscriptions.Count - 1; i++)
                await DeleteSubscriptionAsync(subscriptions[i]);

            return result;
        }

        #endregion
    }
}