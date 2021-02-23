﻿using System.Threading.Tasks;
using Nop.Core.Domain.Messages;
using Nop.Web.Areas.Admin.Models.Messages;

namespace Nop.Web.Areas.Admin.Factories
{
    /// <summary>
    /// Represents the campaign model factory
    /// </summary>
    public partial interface ICampaignModelFactory
    {
        /// <summary>
        /// Prepare campaign search model
        /// </summary>
        /// <param name="searchModel">Campaign search model</param>
        /// <returns>Campaign search model</returns>
        Task<CampaignSearchModel> PrepareCampaignSearchModelAsync(CampaignSearchModel searchModel);

        /// <summary>
        /// Prepare paged campaign list model
        /// </summary>
        /// <param name="searchModel">Campaign search model</param>
        /// <returns>Campaign list model</returns>
        Task<CampaignListModel> PrepareCampaignListModelAsync(CampaignSearchModel searchModel);

        /// <summary>
        /// Prepare campaign model
        /// </summary>
        /// <param name="model">Campaign model</param>
        /// <param name="campaign">Campaign</param>
        /// <param name="excludeProperties">Whether to exclude populating of some properties of model</param>
        /// <returns>Campaign model</returns>
        Task<CampaignModel> PrepareCampaignModelAsync(CampaignModel model, Campaign campaign, bool excludeProperties = false);
    }
}