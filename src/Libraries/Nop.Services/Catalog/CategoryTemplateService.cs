﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nop.Core.Domain.Catalog;
using Nop.Data;

namespace Nop.Services.Catalog
{
    /// <summary>
    /// Category template service
    /// </summary>
    public partial class CategoryTemplateService : ICategoryTemplateService
    {
        #region Fields

        private readonly IRepository<CategoryTemplate> _categoryTemplateRepository;

        #endregion

        #region Ctor

        public CategoryTemplateService(IRepository<CategoryTemplate> categoryTemplateRepository)
        {
            _categoryTemplateRepository = categoryTemplateRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Delete category template
        /// </summary>
        /// <param name="categoryTemplate">Category template</param>
        public virtual async Task DeleteCategoryTemplateAsync(CategoryTemplate categoryTemplate)
        {
            await _categoryTemplateRepository.DeleteAsync(categoryTemplate);
        }

        /// <summary>
        /// Gets all category templates
        /// </summary>
        /// <returns>Category templates</returns>
        public virtual async Task<IList<CategoryTemplate>> GetAllCategoryTemplatesAsync()
        {
            var templates = await _categoryTemplateRepository.GetAllAsync(query =>
            {
                return from pt in query
                    orderby pt.DisplayOrder, pt.Id
                    select pt;
            }, cache => default);

            return templates;
        }

        /// <summary>
        /// Gets a category template
        /// </summary>
        /// <param name="categoryTemplateId">Category template identifier</param>
        /// <returns>Category template</returns>
        public virtual async Task<CategoryTemplate> GetCategoryTemplateByIdAsync(int categoryTemplateId)
        {
            return await _categoryTemplateRepository.GetByIdAsync(categoryTemplateId, cache => default);
        }

        /// <summary>
        /// Inserts category template
        /// </summary>
        /// <param name="categoryTemplate">Category template</param>
        public virtual async Task InsertCategoryTemplateAsync(CategoryTemplate categoryTemplate)
        {
            await _categoryTemplateRepository.InsertAsync(categoryTemplate);
        }

        /// <summary>
        /// Updates the category template
        /// </summary>
        /// <param name="categoryTemplate">Category template</param>
        public virtual async Task UpdateCategoryTemplateAsync(CategoryTemplate categoryTemplate)
        {
            await _categoryTemplateRepository.UpdateAsync(categoryTemplate);
        }

        #endregion
    }
}