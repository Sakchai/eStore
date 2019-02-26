﻿using System.ComponentModel.DataAnnotations;
using FluentValidation.Attributes;
using Nop.Web.Areas.Admin.Validators.Messages;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Messages
{
    /// <summary>
    /// Represents a newsletter subscription model
    /// </summary>
    [Validator(typeof(NewsLetterSubscriptionValidator))]
    public partial class NewsletterSubscriptionModel : BaseNopEntityModel
    {
        #region Properties

        [DataType(DataType.EmailAddress)]
        [NopResourceDisplayName("Admin.Promotions.NewsLetterSubscriptions.Fields.Email")]
        public string Email { get; set; }

        [NopResourceDisplayName("Admin.Promotions.NewsLetterSubscriptions.Fields.Active")]
        public bool Active { get; set; }

        [NopResourceDisplayName("Admin.Promotions.NewsLetterSubscriptions.Fields.Store")]
        public string StoreName { get; set; }

        [NopResourceDisplayName("Admin.Promotions.NewsLetterSubscriptions.Fields.CreatedOn")]
        public string CreatedOn { get; set; }

        #endregion
    }
}