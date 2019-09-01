using System.Collections.Generic;
using QNet.Web.Framework.Models;
using QNet.Web.Models.Common;

namespace QNet.Web.Models.Catalog
{
    public partial class CustomerBackInStockSubscriptionsModel : BaseQNetModel
    {
        public CustomerBackInStockSubscriptionsModel()
        {
            Subscriptions = new List<BackInStockSubscriptionModel>();
        }

        public IList<BackInStockSubscriptionModel> Subscriptions { get; set; }
        public PagerModel PagerModel { get; set; }

        #region Nested classes

        public partial class BackInStockSubscriptionModel : BaseQNetEntityModel
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public string SeName { get; set; }
        }

        #endregion
    }
}