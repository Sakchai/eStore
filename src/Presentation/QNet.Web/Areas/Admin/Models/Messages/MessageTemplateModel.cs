using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Messages
{
    /// <summary>
    /// Represents a message template model
    /// </summary>
    public partial class MessageTemplateModel : BaseQNetEntityModel, ILocalizedModel<MessageTemplateLocalizedModel>, IStoreMappingSupportedModel
    {
        #region Ctor

        public MessageTemplateModel()
        {
            Locales = new List<MessageTemplateLocalizedModel>();
            AvailableEmailAccounts = new List<SelectListItem>();

            SelectedStoreIds = new List<int>();
            AvailableStores = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        [QNetResourceDisplayName("Admin.ContentManagement.MessageTemplates.Fields.AllowedTokens")]
        public string AllowedTokens { get; set; }

        [QNetResourceDisplayName("Admin.ContentManagement.MessageTemplates.Fields.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Admin.ContentManagement.MessageTemplates.Fields.BccEmailAddresses")]
        public string BccEmailAddresses { get; set; }

        [QNetResourceDisplayName("Admin.ContentManagement.MessageTemplates.Fields.Subject")]
        public string Subject { get; set; }

        [QNetResourceDisplayName("Admin.ContentManagement.MessageTemplates.Fields.Body")]
        public string Body { get; set; }

        [QNetResourceDisplayName("Admin.ContentManagement.MessageTemplates.Fields.IsActive")]
        public bool IsActive { get; set; }

        [QNetResourceDisplayName("Admin.ContentManagement.MessageTemplates.Fields.SendImmediately")]
        public bool SendImmediately { get; set; }

        [QNetResourceDisplayName("Admin.ContentManagement.MessageTemplates.Fields.DelayBeforeSend")]
        [UIHint("Int32Nullable")]
        public int? DelayBeforeSend { get; set; }

        public int DelayPeriodId { get; set; }

        public bool HasAttachedDownload { get; set; }
        [QNetResourceDisplayName("Admin.ContentManagement.MessageTemplates.Fields.AttachedDownload")]
        [UIHint("Download")]
        public int AttachedDownloadId { get; set; }

        [QNetResourceDisplayName("Admin.ContentManagement.MessageTemplates.Fields.EmailAccount")]
        public int EmailAccountId { get; set; }

        public IList<SelectListItem> AvailableEmailAccounts { get; set; }

        //store mapping
        [QNetResourceDisplayName("Admin.ContentManagement.MessageTemplates.Fields.LimitedToStores")]
        public IList<int> SelectedStoreIds { get; set; }

        public IList<SelectListItem> AvailableStores { get; set; }

        //comma-separated list of stores used on the list page
        [QNetResourceDisplayName("Admin.ContentManagement.MessageTemplates.Fields.LimitedToStores")]
        public string ListOfStores { get; set; }

        public IList<MessageTemplateLocalizedModel> Locales { get; set; }

        #endregion
    }

    public partial class MessageTemplateLocalizedModel : ILocalizedLocaleModel
    {
        public MessageTemplateLocalizedModel()
        {
            AvailableEmailAccounts = new List<SelectListItem>();
        }

        public int LanguageId { get; set; }

        [QNetResourceDisplayName("Admin.ContentManagement.MessageTemplates.Fields.BccEmailAddresses")]
        public string BccEmailAddresses { get; set; }

        [QNetResourceDisplayName("Admin.ContentManagement.MessageTemplates.Fields.Subject")]
        public string Subject { get; set; }

        [QNetResourceDisplayName("Admin.ContentManagement.MessageTemplates.Fields.Body")]
        public string Body { get; set; }

        [QNetResourceDisplayName("Admin.ContentManagement.MessageTemplates.Fields.EmailAccount")]
        public int EmailAccountId { get; set; }
        public IList<SelectListItem> AvailableEmailAccounts { get; set; }
    }
}