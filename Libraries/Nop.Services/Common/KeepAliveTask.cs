﻿using System.Net;
using Nop.Core;
using Nop.Core.Http;
using Nop.Services.Tasks;

namespace Nop.Services.Common
{
    /// <summary>
    /// Represents a task for keeping the site alive
    /// </summary>
    public partial class KeepAliveTask : IScheduleTask
    {
        #region Fields

        private readonly IWebHelper _webHelper;

        #endregion

        #region Ctor

        public KeepAliveTask(IWebHelper webHelper)
        {
            _webHelper = webHelper;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Executes a task
        /// </summary>
        public void Execute()
        {
            var keepAliveUrl = $"{_webHelper.GetStoreLocation()}{NopHttpDefaults.KeepAlivePath}";
            using (var wc = new WebClient())
            {
                wc.DownloadString(keepAliveUrl);
            }
        }

        #endregion
    }
}