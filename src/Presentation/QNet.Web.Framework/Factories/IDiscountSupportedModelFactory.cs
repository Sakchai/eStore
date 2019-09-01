using System.Collections.Generic;
using QNet.Core;
using QNet.Core.Domain.Discounts;
using QNet.Web.Framework.Models;

namespace QNet.Web.Framework.Factories
{
    /// <summary>
    /// Represents the discount supported model factory
    /// </summary>
    public partial interface IDiscountSupportedModelFactory
    {
        /// <summary>
        /// Prepare selected and all available discounts for the passed model
        /// </summary>
        /// <typeparam name="TModel">Discount supported model type</typeparam>
        /// <param name="model">Model</param>
        /// <param name="availableDiscounts">List of all available discounts</param>
        void PrepareModelDiscounts<TModel>(TModel model, IList<Discount> availableDiscounts) where TModel : IDiscountSupportedModel;

        /// <summary>
        /// Prepare selected and all available discounts for the passed model by entity applied discounts
        /// </summary>
        /// <typeparam name="TModel">Discount supported model type</typeparam>
        /// <typeparam name="TEntity">Discount supported entity type</typeparam>
        /// <param name="model">Model</param>
        /// <param name="entity">Entity</param>
        /// <param name="availableDiscounts">List of all available discounts</param>
        /// <param name="ignoreAppliedDiscounts">Whether to ignore existing applied discounts</param>
        void PrepareModelDiscounts<TModel, TEntity>(TModel model, TEntity entity, 
            IList<Discount> availableDiscounts, bool ignoreAppliedDiscounts)
            where TModel : IDiscountSupportedModel where TEntity : BaseEntity, IDiscountSupported;
    }
}