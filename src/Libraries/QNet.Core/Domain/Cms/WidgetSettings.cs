using System.Collections.Generic;
using QNet.Core.Configuration;

namespace QNet.Core.Domain.Cms
{
    /// <summary>
    /// Widget settings
    /// </summary>
    public class WidgetSettings : ISettings
    {
        public WidgetSettings()
        {
            ActiveWidgetSystemNames = new List<string>();
        }

        /// <summary>
        /// Gets or sets a system names of active widgets
        /// </summary>
        public List<string> ActiveWidgetSystemNames { get; set; }
    }
}