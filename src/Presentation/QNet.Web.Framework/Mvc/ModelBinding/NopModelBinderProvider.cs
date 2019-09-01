using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using QNet.Core.Infrastructure;
using QNet.Web.Framework.Models;

namespace QNet.Web.Framework.Mvc.ModelBinding
{
    /// <summary>
    /// Represents model binder provider for the creating QNetModelBinder
    /// </summary>
    public class QNetModelBinderProvider : IModelBinderProvider
    {
        /// <summary>
        /// Creates a nop model binder based on passed context
        /// </summary>
        /// <param name="context">Model binder provider context</param>
        /// <returns>Model binder</returns>
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));


            var modelType = context.Metadata.ModelType;
            if (!typeof(BaseQNetModel).IsAssignableFrom(modelType))
                return null;

            //use QNetModelBinder as a ComplexTypeModelBinder for BaseQNetModel
            if (context.Metadata.IsComplexType && !context.Metadata.IsCollectionType)
            {
                //create binders for all model properties
                var propertyBinders = context.Metadata.Properties
                    .ToDictionary(modelProperty => modelProperty, modelProperty => context.CreateBinder(modelProperty));
                
                return new QNetModelBinder(propertyBinders, EngineContext.Current.Resolve<ILoggerFactory>());
            }

            //or return null to further search for a suitable binder
            return null;
        }
    }
}
