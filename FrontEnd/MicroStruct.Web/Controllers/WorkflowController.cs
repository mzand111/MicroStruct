using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MicroStruct.Web.Library.ControllerBase;

namespace MicroStruct.Web.Controllers
{
    public class WorkflowController : BaseMVCController
    {
        [Authorize]
        public IActionResult Manage()
        {
            return View();
        }
    }
}
