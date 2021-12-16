using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MicroStruct.Web.Config;
using MicroStruct.Web.Library.ControllerBase;
using MicroStruct.Web.Services;

namespace MicroStruct.Web.Controllers
{
    public class WorkflowController : BaseMVCController
    {
        private readonly ServiceUrls _serviceUrls;
        private readonly ILogger<WorkflowController> _wfLogger;
        private readonly IWorkflowService _service;
        public WorkflowController(IOptions<ServiceUrls> serviceUrls,ILogger<WorkflowController> wfLogger,IWorkflowService service)
        {
            _serviceUrls = serviceUrls.Value;
            _wfLogger = wfLogger;
            _service = service;
        }
        [Authorize]
        public IActionResult Manage()
        {
            _wfLogger.Log(LogLevel.Warning, "Accessed to manage workflows logcode:{UserActionId}", 1122);
            var s=_serviceUrls.WorkflowApi;
            _service.GetAll();
            return View();
        }
    }
}
