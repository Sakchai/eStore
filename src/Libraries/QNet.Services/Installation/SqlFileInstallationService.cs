using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using QNet.Core;
using QNet.Core.Data;
using QNet.Core.Domain.Customers;
using QNet.Core.Domain.Localization;
using QNet.Core.Domain.Stores;
using QNet.Core.Infrastructure;
using QNet.Data;
using QNet.Services.Customers;
using QNet.Services.Localization;

namespace QNet.Services.Installation
{
    /// <summary>
    /// Installation service using SQL files (fast installation)
    /// </summary>
    public partial class SqlFileInstallationService : IInstallationService
    {
        #region Fields

        private readonly IDbContext _dbContext;
        private readonly IQNetFileProvider _fileProvider;
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Language> _languageRepository;
        private readonly IRepository<Store> _storeRepository;
        private readonly IWebHelper _webHelper;

        #endregion

        #region Ctor

        public SqlFileInstallationService(IDbContext dbContext,
            IQNetFileProvider fileProvider,
            IRepository<Customer> customerRepository,
            IRepository<Language> languageRepository,
            IRepository<Store> storeRepository,
            IWebHelper webHelper)
        {
            _dbContext = dbContext;
            _fileProvider = fileProvider;
            _customerRepository = customerRepository;
            _languageRepository = languageRepository;
            _storeRepository = storeRepository;
            _webHelper = webHelper;
        }

        #endregion

        #region Utilities

        /// <summary>
        /// Install locales
        /// </summary>
        protected virtual void InstallLocaleResources()
        {
            //'English' language
            var language = _languageRepository.Table.Single(l => l.Name == "English");

            //save resources
            var directoryPath = _fileProvider.MapPath(QNetInstallationDefaults.LocalizationResourcesPath);
            var pattern = $"*.{QNetInstallationDefaults.LocalizationResourcesFileExtension}";
            foreach (var filePath in _fileProvider.EnumerateFiles(directoryPath, pattern))
            {
                var localizationService = EngineContext.Current.Resolve<ILocalizationService>();
                using (var streamReader = new StreamReader(filePath))
                {
                    localizationService.ImportResourcesFromXml(language, streamReader);
                }
            }
        }

        /// <summary>
        /// Update default customer
        /// </summary>
        /// <param name="defaultUserEmail">Email</param>
        /// <param name="defaultUserPassword">Password</param>
        protected virtual void UpdateDefaultCustomer(string defaultUserEmail, string defaultUserPassword)
        {
            var adminUser = _customerRepository.Table.Single(x => x.Email == "admin@yourStore.com");
            if (adminUser == null)
                throw new Exception("Admin user cannot be loaded");

            adminUser.CustomerGuid = Guid.NewGuid().ToString();
            adminUser.Email = defaultUserEmail;
            adminUser.Username = defaultUserEmail;
            _customerRepository.Update(adminUser);

            var customerRegistrationService = EngineContext.Current.Resolve<ICustomerRegistrationService>();
            customerRegistrationService.ChangePassword(new ChangePasswordRequest(defaultUserEmail, false,
                 PasswordFormat.Hashed, defaultUserPassword, null, QNetCustomerServiceDefaults.DefaultHashedPasswordFormat));
        }

        /// <summary>
        /// Update default store URL
        /// </summary>
        protected virtual void UpdateDefaultStoreUrl()
        {
            var store = _storeRepository.Table.FirstOrDefault();
            if (store == null)
                throw new Exception("Default store cannot be loaded");

            store.Url = _webHelper.GetStoreLocation(false);
            _storeRepository.Update(store);
        }

        /// <summary>
        /// Execute SQL file
        /// </summary>
        /// <param name="path">File path</param>
        protected virtual void ExecuteSqlFile(string path)
        {
            var statements = new List<string>();

            using (var reader = new StreamReader(path))
            {
                string statement;
                while ((statement = ReadNextStatementFromStream(reader)) != null)
                    statements.Add(statement);
            }

            foreach (var stmt in statements)
                _dbContext.ExecuteSqlCommand(stmt);
        }

        /// <summary>
        /// Read next statement from stream
        /// </summary>
        /// <param name="reader">Reader</param>
        /// <returns>Result</returns>
        protected virtual string ReadNextStatementFromStream(StreamReader reader)
        {
            var sb = new StringBuilder();
            while (true)
            {
                var lineOfText = reader.ReadLine();
                if (lineOfText == null)
                {
                    if (sb.Length > 0)
                        return sb.ToString();

                    return null;
                }

                if (lineOfText.TrimEnd().ToUpper() == "GO")
                    break;

                sb.Append(lineOfText + Environment.NewLine);
            }

            return sb.ToString();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Install required data
        /// </summary>
        /// <param name="defaultUserEmail">Default user email</param>
        /// <param name="defaultUserPassword">Default user password</param>
        public virtual void InstallRequiredData(string defaultUserEmail, string defaultUserPassword)
        {
            ExecuteSqlFile(_fileProvider.MapPath(QNetInstallationDefaults.RequiredDataPath));
            InstallLocaleResources();
            UpdateDefaultCustomer(defaultUserEmail, defaultUserPassword);
            UpdateDefaultStoreUrl();
        }

        /// <summary>
        /// Install sample data
        /// </summary>
        /// <param name="defaultUserEmail">Default user email</param>
        public virtual void InstallSampleData(string defaultUserEmail)
        {
            ExecuteSqlFile(_fileProvider.MapPath(QNetInstallationDefaults.SampleDataPath));
        }

        #endregion
    }
}