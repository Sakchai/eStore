using QNet.Web.Areas.Admin.Models.Home;

namespace QNet.Web.Areas.Admin.Factories
{
    /// <summary>
    /// Represents the home models factory
    /// </summary>
    public partial interface IHomeModelFactory
    {
        /// <summary>
        /// Prepare dashboard model
        /// </summary>
        /// <param name="model">Dashboard model</param>
        /// <returns>Dashboard model</returns>
        DashboardModel PrepareDashboardModel(DashboardModel model);

        /// <summary>
        /// Prepare QNet news model
        /// </summary>
        /// <returns>QNet news model</returns>
        QNetCommerceNewsModel PrepareQNetCommerceNewsModel();
    }
}