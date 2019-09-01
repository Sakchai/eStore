using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Messages
{
    /// <summary>
    /// Represents a campaign model
    /// </summary>
    public partial class CampaignModel : BaseQNetEntityModel
    {
        #region Ctor

        public CampaignModel()
        {
            AvailableStores = new List<SelectListItem>();
            AvailableCustomerRoles = new List<SelectListItem>();
            AvailableEmailAccounts = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        [QNetResourceDisplayName("Admin.Promotions.Campaigns.Fields.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Admin.Promotions.Campaigns.Fields.Subject")]
        public string Subject { get; set; }

        [QNetResourceDisplayName("Admin.Promotions.Campaigns.Fields.Body")]
        public string Body { get; set; }

        [QNetResourceDisplayName("Admin.Promotions.Campaigns.Fields.Store")]
        public int StoreId { get; set; }
        public IList<SelectListItem> AvailableStores { get; set; }

        [QNetResourceDisplayName("Admin.Promotions.Campaigns.Fields.CustomerRole")]
        public int CustomerRoleId { get; set; }
        public IList<SelectListItem> AvailableCustomerRoles { get; set; }

        [QNetResourceDisplayName("Admin.Promotions.Campaigns.Fields.CreatedOn")]
        public DateTime CreatedOn { get; set; }

        [QNetResourceDisplayName("Admin.Promotions.Campaigns.Fields.DontSendBeforeDate")]
        [UIHint("DateTimeNullable")]
        public DateTime? DontSendBeforeDate { get; set; }

        [QNetResourceDisplayName("Admin.Promotions.Campaigns.Fields.AllowedTokens")]
        public string AllowedTokens { get; set; }

        [QNetResourceDisplayName("Admin.Promotions.Campaigns.Fields.EmailAccount")]
        public int EmailAccountId { get; set; }
        public IList<SelectListItem> AvailableEmailAccounts { get; set; }

        [DataType(DataType.EmailAddress)]
        [QNetResourceDisplayName("Admin.Promotions.Campaigns.Fields.TestEmail")]
        public string TestEmail { get; set; }

        #endregion
    }
}