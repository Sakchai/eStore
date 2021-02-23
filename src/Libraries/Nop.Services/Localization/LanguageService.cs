﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Nop.Core.Caching;
using Nop.Core.Domain.Localization;
using Nop.Data;
using Nop.Services.Configuration;
using Nop.Services.Stores;

namespace Nop.Services.Localization
{
    /// <summary>
    /// Language service
    /// </summary>
    public partial class LanguageService : ILanguageService
    {
        #region Fields

        private readonly IRepository<Language> _languageRepository;
        private readonly ISettingService _settingService;
        private readonly IStaticCacheManager _staticCacheManager;
        private readonly IStoreMappingService _storeMappingService;
        private readonly LocalizationSettings _localizationSettings;

        #endregion

        #region Ctor

        public LanguageService(IRepository<Language> languageRepository,
            ISettingService settingService,
            IStaticCacheManager staticCacheManager,
            IStoreMappingService storeMappingService,
            LocalizationSettings localizationSettings)
        {
            _languageRepository = languageRepository;
            _settingService = settingService;
            _staticCacheManager = staticCacheManager;
            _storeMappingService = storeMappingService;
            _localizationSettings = localizationSettings;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Deletes a language
        /// </summary>
        /// <param name="language">Language</param>
        public virtual async Task DeleteLanguageAsync(Language language)
        {
            if (language == null)
                throw new ArgumentNullException(nameof(language));
            
            //update default admin area language (if required)
            if (_localizationSettings.DefaultAdminLanguageId == language.Id)
                foreach (var activeLanguage in await GetAllLanguagesAsync())
                {
                    if (activeLanguage.Id == language.Id) 
                        continue;

                    _localizationSettings.DefaultAdminLanguageId = activeLanguage.Id;
                    await _settingService.SaveSettingAsync(_localizationSettings);
                    break;
                }

            await _languageRepository.DeleteAsync(language);
        }

        /// <summary>
        /// Gets all languages
        /// </summary>
        /// <param name="storeId">Load records allowed only in a specified store; pass 0 to load all records</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Languages</returns>
        public virtual async Task<IList<Language>> GetAllLanguagesAsync(bool showHidden = false, int storeId = 0)
        {
            //cacheable copy
            var key = _staticCacheManager.PrepareKeyForDefaultCache(NopLocalizationDefaults.LanguagesAllCacheKey, storeId, showHidden);
            
            var languages = await _staticCacheManager.GetAsync(key, async () =>
            {
                var allLanguages = await _languageRepository.GetAllAsync(query =>
                {
                    if (!showHidden)
                        query = query.Where(l => l.Published);
                    query = query.OrderBy(l => l.DisplayOrder).ThenBy(l => l.Id);

                    return query;
                });

                //store mapping
                if (storeId > 0)
                    allLanguages = await allLanguages
                        .WhereAwait(async l => await _storeMappingService.AuthorizeAsync(l, storeId))
                        .ToListAsync();

                return allLanguages;
            });

            return languages;
        }

        /// <summary>
        /// Gets a language
        /// </summary>
        /// <param name="languageId">Language identifier</param>
        /// <returns>Language</returns>
        public virtual async Task<Language> GetLanguageByIdAsync(int languageId)
        {
            return await _languageRepository.GetByIdAsync(languageId, cache => default);
        }

        /// <summary>
        /// Inserts a language
        /// </summary>
        /// <param name="language">Language</param>
        public virtual async Task InsertLanguageAsync(Language language)
        {
            await _languageRepository.InsertAsync(language);
        }

        /// <summary>
        /// Updates a language
        /// </summary>
        /// <param name="language">Language</param>
        public virtual async Task UpdateLanguageAsync(Language language)
        {
            //update language
            await _languageRepository.UpdateAsync(language);
        }

        /// <summary>
        /// Get 2 letter ISO language code
        /// </summary>
        /// <param name="language">Language</param>
        /// <returns>ISO language code</returns>
        public virtual string GetTwoLetterIsoLanguageName(Language language)
        {
            if (language == null)
                throw new ArgumentNullException(nameof(language));

            if (string.IsNullOrEmpty(language.LanguageCulture))
                return "en";

            var culture = new CultureInfo(language.LanguageCulture);
            var code = culture.TwoLetterISOLanguageName;

            return string.IsNullOrEmpty(code) ? "en" : code;
        }

        #endregion
    }
}