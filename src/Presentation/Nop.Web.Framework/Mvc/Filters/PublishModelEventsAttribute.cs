﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Nop.Core.Events;
using Nop.Web.Framework.Events;
using Nop.Web.Framework.Models;

namespace Nop.Web.Framework.Mvc.Filters
{
    /// <summary>
    /// Represents filter attribute that publish ModelReceived event before the action executes, after model binding is complete
    /// and publish ModelPrepared event after the action executes, before the action result
    /// </summary>
    public sealed class PublishModelEventsAttribute : TypeFilterAttribute
    {
        #region Ctor

        /// <summary>
        /// Create instance of the filter attribute
        /// </summary>
        /// <param name="ignore">Whether to ignore the execution of filter actions</param>
        public PublishModelEventsAttribute(bool ignore = false) : base(typeof(PublishModelEventsFilter))
        {
            IgnoreFilter = ignore;
            Arguments = new object[] { ignore };
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether to ignore the execution of filter actions
        /// </summary>
        public bool IgnoreFilter { get; }

        #endregion

        #region Nested filter

        /// <summary>
        /// Represents filter that publish ModelReceived event before the action executes, after model binding is complete
        /// and publish ModelPrepared event after the action executes, before the action result
        /// </summary>
        private class PublishModelEventsFilter : IAsyncActionFilter
        {
            #region Fields

            private readonly bool _ignoreFilter;
            private readonly IEventPublisher _eventPublisher;

            #endregion

            #region Ctor

            public PublishModelEventsFilter(bool ignoreFilter,
                IEventPublisher eventPublisher)
            {
                _ignoreFilter = ignoreFilter;
                _eventPublisher = eventPublisher;
            }

            #endregion

            #region Utilities

            /// <summary>
            /// Called asynchronously before the action, after model binding is complete.
            /// </summary>
            /// <param name="context">A context for action filters</param>
            /// <returns>A task that on completion indicates the necessary filter actions have been executed</returns>
            private async Task PublishModelReceivedEventAsync(ActionExecutingContext context)
            {
                if (context == null)
                    throw new ArgumentNullException(nameof(context));

                if (context.HttpContext.Request == null)
                    return;

                //only in POST requests
                if (!context.HttpContext.Request.Method.Equals(WebRequestMethods.Http.Post, StringComparison.InvariantCultureIgnoreCase))
                    return;

                //check whether this filter has been overridden for the Action
                var actionFilter = context.ActionDescriptor.FilterDescriptors
                    .Where(filterDescriptor => filterDescriptor.Scope == FilterScope.Action)
                    .Select(filterDescriptor => filterDescriptor.Filter)
                    .OfType<PublishModelEventsAttribute>()
                    .FirstOrDefault();

                //whether to ignore this filter
                if (actionFilter?.IgnoreFilter ?? _ignoreFilter)
                    return;

                //model received event
                foreach (var model in context.ActionArguments.Values.OfType<BaseNopModel>())
                {
                    //we publish the ModelReceived event for all models as the BaseNopModel, 
                    //so you need to implement IConsumer<ModelReceived<BaseNopModel>> interface to handle this event
                    await _eventPublisher.ModelReceivedAsync(model, context.ModelState);
                }
            }

            /// <summary>
            /// Called asynchronously before the action, after model binding is complete.
            /// </summary>
            /// <param name="context">A context for action filters</param>
            /// <returns>A task that on completion indicates the necessary filter actions have been executed</returns>
            private async Task PublishModelPreparedEventAsync(ActionExecutingContext context)
            {
                if (context == null)
                    throw new ArgumentNullException(nameof(context));

                if (context.HttpContext.Request == null)
                    return;

                //check whether this filter has been overridden for the Action
                var actionFilter = context.ActionDescriptor.FilterDescriptors
                    .Where(filterDescriptor => filterDescriptor.Scope == FilterScope.Action)
                    .Select(filterDescriptor => filterDescriptor.Filter)
                    .OfType<PublishModelEventsAttribute>()
                    .FirstOrDefault();

                //whether to ignore this filter
                if (actionFilter?.IgnoreFilter ?? _ignoreFilter)
                    return;

                //model prepared event
                if (context.Controller is Controller controller)
                {
                    if (controller.ViewData.Model is BaseNopModel model)
                    {
                        //we publish the ModelPrepared event for all models as the BaseNopModel, 
                        //so you need to implement IConsumer<ModelPrepared<BaseNopModel>> interface to handle this event
                        await _eventPublisher.ModelPreparedAsync(model);
                    }

                    if (controller.ViewData.Model is IEnumerable<BaseNopModel> modelCollection)
                    {
                        //we publish the ModelPrepared event for collection as the IEnumerable<BaseNopModel>, 
                        //so you need to implement IConsumer<ModelPrepared<IEnumerable<BaseNopModel>>> interface to handle this event
                        await _eventPublisher.ModelPreparedAsync(modelCollection);
                    }
                }
            }

            #endregion

            #region Methods

            /// <summary>
            /// Called asynchronously before the action, after model binding is complete.
            /// </summary>
            /// <param name="context">A context for action filters</param>
            /// <param name="next">A delegate invoked to execute the next action filter or the action itself</param>
            /// <returns>A task that on completion indicates the filter has executed</returns>
            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                await PublishModelReceivedEventAsync(context);
                if (context.Result == null)
                    await next();
                await PublishModelPreparedEventAsync(context);
            }

            #endregion
        }

        #endregion
    }
}