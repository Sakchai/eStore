using Microsoft.AspNetCore.Mvc;
using QNet.Web.Framework.Mvc.Filters;
using QNet.Web.Framework.Security;

namespace QNet.Web.Controllers
{
    public partial class HomeController : BasePublicController
    {
        [HttpsRequirement(SslRequirement.No)]
        public virtual IActionResult Index()
        {
            return View();
        }
    }
}