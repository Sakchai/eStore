using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using QNet.Core.Domain.Common;
using QNet.Core.Infrastructure;
using QNet.Web.Framework;
using QNet.Web.Framework.Controllers;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.Filters;
using QNet.Web.Framework.Security;

namespace QNet.Web.Areas.Admin.Controllers
{
    [Area(AreaNames.Admin)]
    [HttpsRequirement(SslRequirement.Yes)]
    [AdminAntiForgery]
    [ValidateIpAddress]
    [AuthorizeAdmin]
    [ValidateVendor]
    [SaveSelectedTab]
    public abstract partial class BaseAdminController : BaseController
    {
        /// <summary>
        /// Creates an object that serializes the specified object to JSON.
        /// </summary>
        /// <param name="data">The object to serialize.</param>
        /// <returns>The created object that serializes the specified data to JSON format for the response.</returns>
        public override JsonResult Json(object data)
        {
            //use IsoDateFormat on writing JSON text to fix issue with dates in grid
            var useIsoDateFormat = EngineContext.Current.Resolve<AdminAreaSettings>()?.UseIsoDateFormatInJsonResult ?? false;
            var serializerSettings = EngineContext.Current.Resolve<IOptions<MvcJsonOptions>>()?.Value?.SerializerSettings
                ?? new JsonSerializerSettings();

            if (!useIsoDateFormat)
                return base.Json(data, serializerSettings);

            serializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
            serializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Unspecified;

            return base.Json(data, serializerSettings);
        }

    }
}