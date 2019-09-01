using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Plugin.Payments.Square.Models
{
    /// <summary>
    /// Represents configuration model
    /// </summary>
    public class ConfigurationModel : BaseQNetModel
    {
        #region Ctor

        public ConfigurationModel()
        {
            Locations = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        [QNetResourceDisplayName("Plugins.Payments.Square.Fields.ApplicationId")]
        public string ApplicationId { get; set; }

        [QNetResourceDisplayName("Plugins.Payments.Square.Fields.SandboxApplicationId")]
        public string SandboxApplicationId { get; set; }

        [QNetResourceDisplayName("Plugins.Payments.Square.Fields.ApplicationSecret")]
        [DataType(DataType.Password)]
        [NoTrim]
        public string ApplicationSecret { get; set; }

        [QNetResourceDisplayName("Plugins.Payments.Square.Fields.AccessToken")]
        [DataType(DataType.Password)]
        [NoTrim]
        public string AccessToken { get; set; }

        [QNetResourceDisplayName("Plugins.Payments.Square.Fields.SandboxAccessToken")]
        [DataType(DataType.Password)]
        [NoTrim]
        public string SandboxAccessToken { get; set; }

        [QNetResourceDisplayName("Plugins.Payments.Square.Fields.UseSandbox")]
        public bool UseSandbox { get; set; }

        [QNetResourceDisplayName("Plugins.Payments.Square.Fields.TransactionMode")]
        public int TransactionModeId { get; set; }

        [QNetResourceDisplayName("Plugins.Payments.Square.Fields.Location")]
        public string LocationId { get; set; }
        public IList<SelectListItem> Locations { get; set; }

        [QNetResourceDisplayName("Plugins.Payments.Square.Fields.AdditionalFee")]
        public decimal AdditionalFee { get; set; }

        [QNetResourceDisplayName("Plugins.Payments.Square.Fields.AdditionalFeePercentage")]
        public bool AdditionalFeePercentage { get; set; }

        #endregion
    }
}