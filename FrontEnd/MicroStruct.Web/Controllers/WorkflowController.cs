using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MicroStruct.Web.Config;
using MicroStruct.Web.Library.ControllerBase;

namespace MicroStruct.Web.Controllers
{
    public class WorkflowController : BaseMVCController
    {
        private ServiceUrls _serviceUrls;
        public WorkflowController(IOptions<ServiceUrls> serviceUrls)
        {
            _serviceUrls = serviceUrls.Value;
        }
        [Authorize]
        public IActionResult Manage()
        {
            var s=_serviceUrls.WorkflowApi;
            return View();
        }
    }
}
