
namespace QNet.Data
{
    /// <summary>
    /// Represents default values related to QNet data
    /// </summary>
    public static partial class QNetDataDefaults
    {
        /// <summary>
        /// Gets a path to the file that contains script to create SQL Server indexes
        /// </summary>
        public static string SqlServerIndexesFilePath => "~/App_Data/Install/SqlServer.Indexes.sql";

        /// <summary>
        /// Gets a path to the file that contains script to create SQL Server stored procedures
        /// </summary>
        public static string SqlServerStoredProceduresFilePath => "~/App_Data/Install/SqlServer.StoredProcedures.sql";
    }
}