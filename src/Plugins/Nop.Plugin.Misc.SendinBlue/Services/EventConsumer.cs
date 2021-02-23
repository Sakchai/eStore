﻿using System.Threading.Tasks;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Messages;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Stores;
using Nop.Core.Events;
using Nop.Services.Common;
using Nop.Services.Events;
using Nop.Services.Messages;

namespace Nop.Plugin.Misc.Sendinblue.Services
{
    /// <summary>
    /// Represents event consumer
    /// </summary>
    public class EventConsumer :
        IConsumer<EmailUnsubscribedEvent>,
        IConsumer<EmailSubscribedEvent>,
        IConsumer<EntityInsertedEvent<ShoppingCartItem>>,
        IConsumer<EntityUpdatedEvent<ShoppingCartItem>>,
        IConsumer<EntityDeletedEvent<ShoppingCartItem>>,
        IConsumer<OrderPaidEvent>,
        IConsumer<OrderPlacedEvent>,
        IConsumer<EntityTokensAddedEvent<Store, Token>>,
        IConsumer<EntityTokensAddedEvent<Customer, Token>>
    {
        #region Fields

        private readonly IGenericAttributeService _genericAttributeService;
        private readonly SendinblueManager _sendinblueEmailManager;
        private readonly SendinblueMarketingAutomationManager _sendinblueMarketingAutomationManager;

        #endregion

        #region Ctor

        public EventConsumer(IGenericAttributeService genericAttributeService,
            SendinblueManager sendinblueEmailManager,
            SendinblueMarketingAutomationManager sendinblueMarketingAutomationManager)
        {
            _genericAttributeService = genericAttributeService;
            _sendinblueEmailManager = sendinblueEmailManager;
            _sendinblueMarketingAutomationManager = sendinblueMarketingAutomationManager;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Handle the email unsubscribed event.
        /// </summary>
        /// <param name="eventMessage">The event message.</param>
        public async Task HandleEventAsync(EmailUnsubscribedEvent eventMessage)
        {
            //unsubscribe contact
            await _sendinblueEmailManager.UnsubscribeAsync(eventMessage.Subscription);
        }

        /// <summary>
        /// Handle the email subscribed event.
        /// </summary>
        /// <param name="eventMessage">The event message.</param>
        public async Task HandleEventAsync(EmailSubscribedEvent eventMessage)
        {
            //subscribe contact
            await _sendinblueEmailManager.SubscribeAsync(eventMessage.Subscription);
        }

        /// <summary>
        /// Handle the add shopping cart item event
        /// </summary>
        /// <param name="eventMessage">The event message.</param>
        public async Task HandleEventAsync(EntityInsertedEvent<ShoppingCartItem> eventMessage)
        {
            //handle event
            await _sendinblueMarketingAutomationManager.HandleShoppingCartChangedEventAsync(eventMessage.Entity);
        }

        /// <summary>
        /// Handle the update shopping cart item event
        /// </summary>
        /// <param name="eventMessage">The event message.</param>
        public async Task HandleEventAsync(EntityUpdatedEvent<ShoppingCartItem> eventMessage)
        {
            //handle event
            await _sendinblueMarketingAutomationManager.HandleShoppingCartChangedEventAsync(eventMessage.Entity);
        }

        /// <summary>
        /// Handle the delete shopping cart item event
        /// </summary>
        /// <param name="eventMessage">The event message.</param>
        public async Task HandleEventAsync(EntityDeletedEvent<ShoppingCartItem> eventMessage)
        {
            //handle event
            await _sendinblueMarketingAutomationManager.HandleShoppingCartChangedEventAsync(eventMessage.Entity);
        }

        /// <summary>
        /// Handle the order paid event
        /// </summary>
        /// <param name="eventMessage">The event message.</param>
        public async Task HandleEventAsync(OrderPaidEvent eventMessage)
        {
            //handle event
            await _sendinblueMarketingAutomationManager.HandleOrderCompletedEventAsync(eventMessage.Order);
            await _sendinblueEmailManager.UpdateContactAfterCompletingOrderAsync(eventMessage.Order);
        }

        /// <summary>
        /// Handle the order placed event
        /// </summary>
        /// <param name="eventMessage">The event message.</param>
        public async Task HandleEventAsync(OrderPlacedEvent eventMessage)
        {
            //handle event
            await _sendinblueMarketingAutomationManager.HandleOrderPlacedEventAsync(eventMessage.Order);
        }

        /// <summary>
        /// Handle the store tokens added event
        /// </summary>
        /// <param name="eventMessage">The event message.</param>
        public Task HandleEventAsync(EntityTokensAddedEvent<Store, Token> eventMessage)
        {
            //handle event
            eventMessage.Tokens.Add(new Token("Store.Id", eventMessage.Entity.Id));

            return Task.CompletedTask;
        }

        /// <summary>
        /// Handle the customer tokens added event
        /// </summary>
        /// <param name="eventMessage">The event message.</param>
        public async Task HandleEventAsync(EntityTokensAddedEvent<Customer, Token> eventMessage)
        {
            //handle event
            var phone = await _genericAttributeService.GetAttributeAsync<string>(eventMessage.Entity, NopCustomerDefaults.PhoneAttribute);
            eventMessage.Tokens.Add(new Token("Customer.PhoneNumber", phone));
        }

        #endregion
    }
}