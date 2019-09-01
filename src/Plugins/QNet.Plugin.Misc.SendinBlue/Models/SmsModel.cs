using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Plugin.Misc.SendinBlue.Models
{
    /// <summary>
    /// Represents SMS model
    /// </summary>
    public class SmsModel : BaseQNetEntityModel
    {
        #region Ctor

        public SmsModel()
        {
            AvailableMessages = new List<SelectListItem>();
            AvailablePhoneTypes = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        [QNetResourceDisplayName("Admin.ContentManagement.MessageTemplates.Fields.Name")]
        public int MessageId { get; set; }

        public IList<SelectListItem> AvailableMessages { get; set; }

        public string Name { get; set; }

        [QNetResourceDisplayName("Plugins.Misc.SendinBlue.PhoneType")]
        public int PhoneTypeId { get; set; }

        public IList<SelectListItem> AvailablePhoneTypes { get; set; }

        public string PhoneType { get; set; }

        [QNetResourceDisplayName("Plugins.Misc.SendinBlue.SMSText")]
        public string Text { get; set; }

        #endregion
    }
}