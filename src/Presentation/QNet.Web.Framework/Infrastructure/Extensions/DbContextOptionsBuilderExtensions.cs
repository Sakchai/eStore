using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QNet.Core.Configuration;
using QNet.Core.Data;

namespace QNet.Web.Framework.Infrastructure.Extensions
{
    /// <summary>
    /// Represents extensions of DbContextOptionsBuilder
    /// </summary>
    public static class DbContextOptionsBuilderExtensions
    {
        /// <summary>
        /// SQL Server specific extension method for Microsoft.EntityFrameworkCore.DbContextOptionsBuilder
        /// </summary>
        /// <param name="optionsBuilder">Database context options builder</param>
        /// <param name="services">Collection of service descriptors</param>
        public static void UseSqlServerWithLazyLoading(this DbContextOptionsBuilder optionsBuilder, IServiceCollection services)
        {
            var nopConfig = services.BuildServiceProvider().GetRequiredService<QNetConfig>();

            var dataSettings = DataSettingsManager.LoadSettings();
            if (!dataSettings?.IsValid ?? true)
                return;

            var dbContextOptionsBuilder = optionsBuilder.UseLazyLoadingProxies();

            if (nopConfig.UseRowNumberForPaging)
                dbContextOptionsBuilder.UseSqlServer(dataSettings.DataConnectionString, option => option.UseRowNumberForPaging());
            else
                dbContextOptionsBuilder.UseSqlServer(dataSettings.DataConnectionString);
        }

        public static void UseMySQLWithLazyLoading(this DbContextOptionsBuilder optionsBuilder, IServiceCollection services)
        {
            var nopConfig = services.BuildServiceProvider().GetRequiredService<QNetConfig>();

            var dataSettings = DataSettingsManager.LoadSettings();
            if (!dataSettings?.IsValid ?? true)
                return;

            var dbContextOptionsBuilder = optionsBuilder.UseLazyLoadingProxies();
            dbContextOptionsBuilder.UseMySQL(dataSettings.DataConnectionString);
            //if (nopConfig.UseRowNumberForPaging)
            //    dbContextOptionsBuilder.UseMySQL(dataSettings.DataConnectionString, option => option.UseRowNumberForPaging());
            //else
            //    dbContextOptionsBuilder.UseMySQL(dataSettings.DataConnectionString);
        }
    }
}
