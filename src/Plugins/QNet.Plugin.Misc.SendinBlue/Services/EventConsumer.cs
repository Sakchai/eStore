using QNet.Core.Domain.Customers;
using QNet.Core.Domain.Messages;
using QNet.Core.Domain.Orders;
using QNet.Core.Domain.Stores;
using QNet.Core.Events;
using QNet.Services.Common;
using QNet.Services.Events;
using QNet.Services.Messages;

namespace QNet.Plugin.Misc.SendinBlue.Services
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
        private readonly SendinBlueManager _sendinBlueEmailManager;
        private readonly SendinBlueMarketingAutomationManager _sendinBlueMarketingAutomationManager;

        #endregion

        #region Ctor

        public EventConsumer(IGenericAttributeService genericAttributeService,
            SendinBlueManager sendinBlueEmailManager,
            SendinBlueMarketingAutomationManager sendinBlueMarketingAutomationManager)
        {
            _genericAttributeService = genericAttributeService;
            _sendinBlueEmailManager = sendinBlueEmailManager;
            _sendinBlueMarketingAutomationManager = sendinBlueMarketingAutomationManager;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Handle the email unsubscribed event.
        /// </summary>
        /// <param name="eventMessage">The event message.</param>
        public void HandleEvent(EmailUnsubscribedEvent eventMessage)
        {
            //unsubscribe contact
            _sendinBlueEmailManager.Unsubscribe(eventMessage.Subscription);
        }

        /// <summary>
        /// Handle the email subscribed event.
        /// </summary>
        /// <param name="eventMessage">The event message.</param>
        public void HandleEvent(EmailSubscribedEvent eventMessage)
        {
            //subscribe contact
            _sendinBlueEmailManager.Subscribe(eventMessage.Subscription);
        }

        /// <summary>
        /// Handle the add shopping cart item event
        /// </summary>
        /// <param name="eventMessage">The event message.</param>
        public void HandleEvent(EntityInsertedEvent<ShoppingCartItem> eventMessage)
        {
            //handle event
            _sendinBlueMarketingAutomationManager.HandleShoppingCartChangedEvent(eventMessage.Entity);
        }

        /// <summary>
        /// Handle the update shopping cart item event
        /// </summary>
        /// <param name="eventMessage">The event message.</param>
        public void HandleEvent(EntityUpdatedEvent<ShoppingCartItem> eventMessage)
        {
            //handle event
            _sendinBlueMarketingAutomationManager.HandleShoppingCartChangedEvent(eventMessage.Entity);
        }

        /// <summary>
        /// Handle the delete shopping cart item event
        /// </summary>
        /// <param name="eventMessage">The event message.</param>
        public void HandleEvent(EntityDeletedEvent<ShoppingCartItem> eventMessage)
        {
            //handle event
            _sendinBlueMarketingAutomationManager.HandleShoppingCartChangedEvent(eventMessage.Entity);
        }

        /// <summary>
        /// Handle the order paid event
        /// </summary>
        /// <param name="eventMessage">The event message.</param>
        public void HandleEvent(OrderPaidEvent eventMessage)
        {
            //handle event
            _sendinBlueMarketingAutomationManager.HandleOrderCompletedEvent(eventMessage.Order);
            _sendinBlueEmailManager.UpdateContactAfterCompletingOrder(eventMessage.Order);
        }

        /// <summary>
        /// Handle the order placed event
        /// </summary>
        /// <param name="eventMessage">The event message.</param>
        public void HandleEvent(OrderPlacedEvent eventMessage)
        {
            //handle event
            _sendinBlueMarketingAutomationManager.HandleOrderPlacedEvent(eventMessage.Order);
        }

        /// <summary>
        /// Handle the store tokens added event
        /// </summary>
        /// <param name="eventMessage">The event message.</param>
        public void HandleEvent(EntityTokensAddedEvent<Store, Token> eventMessage)
        {
            //handle event
            eventMessage.Tokens.Add(new Token("Store.Id", eventMessage.Entity.Id));
        }

        /// <summary>
        /// Handle the customer tokens added event
        /// </summary>
        /// <param name="eventMessage">The event message.</param>
        public void HandleEvent(EntityTokensAddedEvent<Customer, Token> eventMessage)
        {
            //handle event
            var phone = _genericAttributeService.GetAttribute<string>(eventMessage.Entity, QNetCustomerDefaults.PhoneAttribute);
            eventMessage.Tokens.Add(new Token("Customer.PhoneNumber", phone));
        }

        #endregion
    }
}