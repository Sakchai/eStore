﻿using Nop.Core.Domain.Common;
using Nop.Core.Infrastructure;

namespace Nop.Web.Framework.Models
{
    /// <summary>
    /// Represents base search model
    /// </summary>
    public abstract partial class BaseSearchModel : BaseNopModel, IPagingRequestModel
    {
        #region Ctor

        public BaseSearchModel()
        {
            //set the default values
            Page = 1;
            PageSize = 10;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a page number
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets a page size
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets a comma-separated list of available page sizes
        /// </summary>
        public string AvailablePageSizes { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Set grid page parameters
        /// </summary>
        public void SetGridPageSize()
        {
            var adminAreaSettings = EngineContext.Current.Resolve<AdminAreaSettings>();

            Page = 1;
            PageSize = adminAreaSettings.DefaultGridPageSize;
            AvailablePageSizes = adminAreaSettings.GridPageSizes;
        }

        /// <summary>
        /// Set popup grid page parameters
        /// </summary>
        public void SetPopupGridPageSize()
        {
            var adminAreaSettings = EngineContext.Current.Resolve<AdminAreaSettings>();

            Page = 1;
            PageSize = adminAreaSettings.PopupGridPageSize;
            AvailablePageSizes = adminAreaSettings.GridPageSizes;
        }

        #endregion
    }
}