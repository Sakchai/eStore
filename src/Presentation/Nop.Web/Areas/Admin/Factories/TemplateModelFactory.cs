﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Nop.Services.Catalog;
using Nop.Services.Topics;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Templates;
using Nop.Web.Framework.Models.Extensions;

namespace Nop.Web.Areas.Admin.Factories
{
    /// <summary>
    /// Represents the template model factory implementation
    /// </summary>
    public partial class TemplateModelFactory : ITemplateModelFactory
    {
        #region Fields

        private readonly ICategoryTemplateService _categoryTemplateService;
        private readonly IManufacturerTemplateService _manufacturerTemplateService;
        private readonly IProductTemplateService _productTemplateService;
        private readonly ITopicTemplateService _topicTemplateService;

        #endregion

        #region Ctor

        public TemplateModelFactory(ICategoryTemplateService categoryTemplateService,
            IManufacturerTemplateService manufacturerTemplateService,
            IProductTemplateService productTemplateService,
            ITopicTemplateService topicTemplateService)
        {
            _categoryTemplateService = categoryTemplateService;
            _manufacturerTemplateService = manufacturerTemplateService;
            _productTemplateService = productTemplateService;
            _topicTemplateService = topicTemplateService;
        }

        #endregion

        #region Utilities

        /// <summary>
        /// Prepare category template search model
        /// </summary>
        /// <param name="searchModel">Category template search model</param>
        /// <returns>Category template search model</returns>
        protected virtual Task<CategoryTemplateSearchModel> PrepareCategoryTemplateSearchModelAsync(CategoryTemplateSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //prepare page parameters
            searchModel.SetGridPageSize();

            return Task.FromResult(searchModel);
        }

        /// <summary>
        /// Prepare manufacturer template search model
        /// </summary>
        /// <param name="searchModel">Manufacturer template search model</param>
        /// <returns>Manufacturer template search model</returns>
        protected virtual Task<ManufacturerTemplateSearchModel> PrepareManufacturerTemplateSearchModelAsync(ManufacturerTemplateSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //prepare page parameters
            searchModel.SetGridPageSize();

            return Task.FromResult(searchModel);
        }

        /// <summary>
        /// Prepare product template search model
        /// </summary>
        /// <param name="searchModel">Product template search model</param>
        /// <returns>Product template search model</returns>
        protected virtual Task<ProductTemplateSearchModel> PrepareProductTemplateSearchModelAsync(ProductTemplateSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //prepare page parameters
            searchModel.SetGridPageSize();

            return Task.FromResult(searchModel);
        }

        /// <summary>
        /// Prepare topic template search model
        /// </summary>
        /// <param name="searchModel">Topic template search model</param>
        /// <returns>Topic template search model</returns>
        protected virtual Task<TopicTemplateSearchModel> PrepareTopicTemplateSearchModelAsync(TopicTemplateSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //prepare page parameters
            searchModel.SetGridPageSize();

            return Task.FromResult(searchModel);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Prepare templates model
        /// </summary>
        /// <param name="model">Templates model</param>
        /// <returns>Templates model</returns>
        public virtual async Task<TemplatesModel> PrepareTemplatesModelAsync(TemplatesModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            //prepare nested search models
            await PrepareCategoryTemplateSearchModelAsync(model.TemplatesCategory);
            await PrepareManufacturerTemplateSearchModelAsync(model.TemplatesManufacturer);
            await PrepareProductTemplateSearchModelAsync(model.TemplatesProduct);
            await PrepareTopicTemplateSearchModelAsync(model.TemplatesTopic);

            return model;
        }
        
        /// <summary>
        /// Prepare paged category template list model
        /// </summary>
        /// <param name="searchModel">Category template search model</param>
        /// <returns>Category template list model</returns>
        public virtual async Task<CategoryTemplateListModel> PrepareCategoryTemplateListModelAsync(CategoryTemplateSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //get category templates
            var categoryTemplates = (await _categoryTemplateService.GetAllCategoryTemplatesAsync()).ToPagedList(searchModel);

            //prepare grid model
            var model = new CategoryTemplateListModel().PrepareToGrid(searchModel, categoryTemplates,
                () => categoryTemplates.Select(template => template.ToModel<CategoryTemplateModel>()));

            return model;
        }
        
        /// <summary>
        /// Prepare paged manufacturer template list model
        /// </summary>
        /// <param name="searchModel">Manufacturer template search model</param>
        /// <returns>Manufacturer template list model</returns>
        public virtual async Task<ManufacturerTemplateListModel> PrepareManufacturerTemplateListModelAsync(ManufacturerTemplateSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //get manufacturer templates
            var manufacturerTemplates = (await _manufacturerTemplateService.GetAllManufacturerTemplatesAsync()).ToPagedList(searchModel);

            //prepare grid model
            var model = new ManufacturerTemplateListModel().PrepareToGrid(searchModel, manufacturerTemplates,
                () => manufacturerTemplates.Select(template => template.ToModel<ManufacturerTemplateModel>()));
            
            return model;
        }
        
        /// <summary>
        /// Prepare paged product template list model
        /// </summary>
        /// <param name="searchModel">Product template search model</param>
        /// <returns>Product template list model</returns>
        public virtual async Task<ProductTemplateListModel> PrepareProductTemplateListModelAsync(ProductTemplateSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //get product templates
            var productTemplates = (await _productTemplateService.GetAllProductTemplatesAsync()).ToPagedList(searchModel);

            //prepare grid model
            var model = new ProductTemplateListModel().PrepareToGrid(searchModel, productTemplates,
                () => productTemplates.Select(template => template.ToModel<ProductTemplateModel>()));

            return model;
        }

        /// <summary>
        /// Prepare paged topic template list model
        /// </summary>
        /// <param name="searchModel">Topic template search model</param>
        /// <returns>Topic template list model</returns>
        public virtual async Task<TopicTemplateListModel> PrepareTopicTemplateListModelAsync(TopicTemplateSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //get topic templates
            var topicTemplates = (await _topicTemplateService.GetAllTopicTemplatesAsync()).ToPagedList(searchModel);

            //prepare grid model
            var model = new TopicTemplateListModel().PrepareToGrid(searchModel, topicTemplates,
                () => topicTemplates.Select(template => template.ToModel<TopicTemplateModel>()));

            return model;
        }

        #endregion
    }
}