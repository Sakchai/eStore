using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Common
{
    public partial class CommonStatisticsModel : BaseQNetModel
    {
        public int NumberOfOrders { get; set; }

        public int NumberOfCustomers { get; set; }

        public int NumberOfPendingReturnRequests { get; set; }

        public int NumberOfLowStockProducts { get; set; }
    }
}