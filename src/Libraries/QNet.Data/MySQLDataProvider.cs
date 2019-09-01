using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using QNet.Core.Data;
using QNet.Core.Domain.Common;
using QNet.Core.Infrastructure;
using QNet.Data.Extensions;

namespace QNet.Data
{
    /// <summary>
    /// Represents SQL Server data provider
    /// </summary>
    public partial class MySQLDataProvider : IDataProvider
    {
        #region Methods

        /// <summary>
        /// Initialize database
        /// </summary>
        public virtual void InitializeDatabase()
        {
            var context = EngineContext.Current.Resolve<IDbContext>();

            //check some of table names to ensure that we have QNet 2.00+ installed
            var tableNamesToValidate = new List<string> { "customer", "discount", "order", "product", "shoppingcartitem" };
            var existingTableNames = context
                .QueryFromSql<StringQueryType>("SELECT table_name AS Value FROM information_schema.tables WHERE table_type = 'BASE TABLE'")
                .Select(stringValue => stringValue.Value).ToList();
            var createTables = !existingTableNames.Intersect(tableNamesToValidate, StringComparer.InvariantCultureIgnoreCase).Any();
            if (!createTables)
                return;

          //  var fileProvider = EngineContext.Current.Resolve<IQNetFileProvider>();

            //create tables
            //EngineContext.Current.Resolve<IRelationalDatabaseCreator>().CreateTables();
            //(context as DbContext).Database.EnsureCreated();
          //  context.ExecuteSqlScript(context.GenerateCreateScript());

            //create indexes
           // context.ExecuteSqlScriptFromFile(fileProvider.MapPath(QNetDataDefaults.SqlServerIndexesFilePath));

            //create stored procedures 
           // context.ExecuteSqlScriptFromFile(fileProvider.MapPath(QNetDataDefaults.SqlServerStoredProceduresFilePath));
        }

        /// <summary>
        /// Get a support database parameter object (used by stored procedures)
        /// </summary>
        /// <returns>Parameter</returns>
        public virtual DbParameter GetParameter()
        {
            return new SqlParameter();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether this data provider supports backup
        /// </summary>
        public virtual bool BackupSupported => true;

        /// <summary>
        /// Gets a maximum length of the data for HASHBYTES functions, returns 0 if HASHBYTES function is not supported
        /// </summary>
        public virtual int SupportedLengthOfBinaryHash => 21844; //for MySQL Server VARCHAR(21844) CHARACTER SET utf8.

        #endregion
    }
}