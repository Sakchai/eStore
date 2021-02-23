﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nop.Core.Domain.Catalog;
using Nop.Data;

namespace Nop.Services.Catalog
{
    /// <summary>
    /// Manufacturer template service
    /// </summary>
    public partial class ManufacturerTemplateService : IManufacturerTemplateService
    {
        #region Fields

        private readonly IRepository<ManufacturerTemplate> _manufacturerTemplateRepository;

        #endregion

        #region Ctor

        public ManufacturerTemplateService(IRepository<ManufacturerTemplate> manufacturerTemplateRepository)
        {
            _manufacturerTemplateRepository = manufacturerTemplateRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Delete manufacturer template
        /// </summary>
        /// <param name="manufacturerTemplate">Manufacturer template</param>
        public virtual async Task DeleteManufacturerTemplateAsync(ManufacturerTemplate manufacturerTemplate)
        {
            await _manufacturerTemplateRepository.DeleteAsync(manufacturerTemplate);
        }

        /// <summary>
        /// Gets all manufacturer templates
        /// </summary>
        /// <returns>Manufacturer templates</returns>
        public virtual async Task<IList<ManufacturerTemplate>> GetAllManufacturerTemplatesAsync()
        {
            var templates = await _manufacturerTemplateRepository.GetAllAsync(query =>
            {
                return from pt in query
                    orderby pt.DisplayOrder, pt.Id
                    select pt;
            }, cache => default);

            return templates;
        }

        /// <summary>
        /// Gets a manufacturer template
        /// </summary>
        /// <param name="manufacturerTemplateId">Manufacturer template identifier</param>
        /// <returns>Manufacturer template</returns>
        public virtual async Task<ManufacturerTemplate> GetManufacturerTemplateByIdAsync(int manufacturerTemplateId)
        {
            return await _manufacturerTemplateRepository.GetByIdAsync(manufacturerTemplateId, cache => default);
        }

        /// <summary>
        /// Inserts manufacturer template
        /// </summary>
        /// <param name="manufacturerTemplate">Manufacturer template</param>
        public virtual async Task InsertManufacturerTemplateAsync(ManufacturerTemplate manufacturerTemplate)
        {
            await _manufacturerTemplateRepository.InsertAsync(manufacturerTemplate);
        }

        /// <summary>
        /// Updates the manufacturer template
        /// </summary>
        /// <param name="manufacturerTemplate">Manufacturer template</param>
        public virtual async Task UpdateManufacturerTemplateAsync(ManufacturerTemplate manufacturerTemplate)
        {
            await _manufacturerTemplateRepository.UpdateAsync(manufacturerTemplate);
        }

        #endregion
    }
}