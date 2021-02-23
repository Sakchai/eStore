﻿using System.Threading.Tasks;
using Nop.Web.Areas.Admin.Models.Reports;

namespace Nop.Web.Areas.Admin.Factories
{
    /// <summary>
    /// Represents the report model factory
    /// </summary>
    public partial interface IReportModelFactory
    {
        #region Sales summary

        /// <summary>
        /// Prepare sales summary search model
        /// </summary>
        /// <param name="searchModel">Sales summary search model</param>
        /// <returns>Sales summary search model</returns>
        Task<SalesSummarySearchModel> PrepareSalesSummarySearchModelAsync(SalesSummarySearchModel searchModel);

        /// <summary>
        /// Prepare sales summary list model
        /// </summary>
        /// <param name="searchModel">Sales summary search model</param>
        /// <returns>Sales summary list model</returns>
        Task<SalesSummaryListModel> PrepareSalesSummaryListModelAsync(SalesSummarySearchModel searchModel);

        #endregion

        #region LowStockProduct

        /// <summary>
        /// Prepare low stock product search model
        /// </summary>
        /// <param name="searchModel">Low stock product search model</param>
        /// <returns>Low stock product search model</returns>
        Task<LowStockProductSearchModel> PrepareLowStockProductSearchModelAsync(LowStockProductSearchModel searchModel);

        /// <summary>
        /// Prepare paged low stock product list model
        /// </summary>
        /// <param name="searchModel">Low stock product search model</param>
        /// <returns>Low stock product list model</returns>
        Task<LowStockProductListModel> PrepareLowStockProductListModelAsync(LowStockProductSearchModel searchModel);

        #endregion

        #region Bestseller

        /// <summary>
        /// Prepare bestseller search model
        /// </summary>
        /// <param name="searchModel">Bestseller search model</param>
        /// <returns>Bestseller search model</returns>
        Task<BestsellerSearchModel> PrepareBestsellerSearchModelAsync(BestsellerSearchModel searchModel);

        /// <summary>
        /// Prepare paged bestseller list model
        /// </summary>
        /// <param name="searchModel">Bestseller search model</param>
        /// <returns>Bestseller list model</returns>
        Task<BestsellerListModel> PrepareBestsellerListModelAsync(BestsellerSearchModel searchModel);

        /// <summary>
        /// Get bestsellers total amount
        /// </summary>
        /// <param name="searchModel">Bestseller search model</param>
        /// <returns>Bestseller total amount</returns>
        Task<string> GetBestsellerTotalAmountAsync(BestsellerSearchModel searchModel);

        #endregion

        #region NeverSold

        /// <summary>
        /// Prepare never sold report search model
        /// </summary>
        /// <param name="searchModel">Never sold report search model</param>
        /// <returns>Never sold report search model</returns>
        Task<NeverSoldReportSearchModel> PrepareNeverSoldSearchModelAsync(NeverSoldReportSearchModel searchModel);

        /// <summary>
        /// Prepare paged never sold report list model
        /// </summary>
        /// <param name="searchModel">Never sold report search model</param>
        /// <returns>Never sold report list model</returns>
        Task<NeverSoldReportListModel> PrepareNeverSoldListModelAsync(NeverSoldReportSearchModel searchModel);

        #endregion

        #region Country sales

        /// <summary>
        /// Prepare country report search model
        /// </summary>
        /// <param name="searchModel">Country report search model</param>
        /// <returns>Country report search model</returns>
        Task<CountryReportSearchModel> PrepareCountrySalesSearchModelAsync(CountryReportSearchModel searchModel);

        /// <summary>
        /// Prepare paged country report list model
        /// </summary>
        /// <param name="searchModel">Country report search model</param>
        /// <returns>Country report list model</returns>
        Task<CountryReportListModel> PrepareCountrySalesListModelAsync(CountryReportSearchModel searchModel);

        #endregion

        #region Customer reports

        /// <summary>
        /// Prepare customer reports search model
        /// </summary>
        /// <param name="searchModel">Customer reports search model</param>
        /// <returns>Customer reports search model</returns>
        Task<CustomerReportsSearchModel> PrepareCustomerReportsSearchModelAsync(CustomerReportsSearchModel searchModel);

        /// <summary>
        /// Prepare paged best customers report list modelSearchModel searchModel
        /// </summary>
        /// <param name="searchModel">Best customers report search model</param>
        /// <returns>Best customers report list model</returns>
        Task<BestCustomersReportListModel> PrepareBestCustomersReportListModelAsync(BestCustomersReportSearchModel searchModel);

        /// <summary>
        /// Prepare paged registered customers report list model
        /// </summary>
        /// <param name="searchModel">Registered customers report search model</param>
        /// <returns>Registered customers report list model</returns>
        Task<RegisteredCustomersReportListModel> PrepareRegisteredCustomersReportListModelAsync(RegisteredCustomersReportSearchModel searchModel);

        #endregion
    }
}
