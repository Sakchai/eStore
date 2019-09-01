using System;
using System.Collections.Generic;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;
using QNet.Web.Models.Common;

namespace QNet.Web.Models.Order
{
    public partial class CustomerRewardPointsModel : BaseQNetModel
    {
        public CustomerRewardPointsModel()
        {
            RewardPoints = new List<RewardPointsHistoryModel>();
        }

        public IList<RewardPointsHistoryModel> RewardPoints { get; set; }
        public PagerModel PagerModel { get; set; }
        public int RewardPointsBalance { get; set; }
        public string RewardPointsAmount { get; set; }
        public int MinimumRewardPointsBalance { get; set; }
        public string MinimumRewardPointsAmount { get; set; }

        #region Nested classes

        public partial class RewardPointsHistoryModel : BaseQNetEntityModel
        {
            [QNetResourceDisplayName("RewardPoints.Fields.Points")]
            public int Points { get; set; }

            [QNetResourceDisplayName("RewardPoints.Fields.PointsBalance")]
            public string PointsBalance { get; set; }

            [QNetResourceDisplayName("RewardPoints.Fields.Message")]
            public string Message { get; set; }

            [QNetResourceDisplayName("RewardPoints.Fields.CreatedDate")]
            public DateTime CreatedOn { get; set; }

            [QNetResourceDisplayName("RewardPoints.Fields.EndDate")]
            public DateTime? EndDate { get; set; }
        }

        #endregion
    }
}