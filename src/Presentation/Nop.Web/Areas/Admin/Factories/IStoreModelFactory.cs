﻿using System.Threading.Tasks;
using Nop.Core.Domain.Stores;
using Nop.Web.Areas.Admin.Models.Stores;

namespace Nop.Web.Areas.Admin.Factories
{
    /// <summary>
    /// Represents the store model factory
    /// </summary>
    public partial interface IStoreModelFactory
    {
        /// <summary>
        /// Prepare store search model
        /// </summary>
        /// <param name="searchModel">Store search model</param>
        /// <returns>Store search model</returns>
        Task<StoreSearchModel> PrepareStoreSearchModelAsync(StoreSearchModel searchModel);

        /// <summary>
        /// Prepare paged store list model
        /// </summary>
        /// <param name="searchModel">Store search model</param>
        /// <returns>Store list model</returns>
        Task<StoreListModel> PrepareStoreListModelAsync(StoreSearchModel searchModel);

        /// <summary>
        /// Prepare store model
        /// </summary>
        /// <param name="model">Store model</param>
        /// <param name="store">Store</param>
        /// <param name="excludeProperties">Whether to exclude populating of some properties of model</param>
        /// <returns>Store model</returns>
        Task<StoreModel> PrepareStoreModelAsync(StoreModel model, Store store, bool excludeProperties = false);
    }
}