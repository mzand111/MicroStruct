using Microsoft.AspNetCore.Mvc;

namespace MicroStruct.Web.Controllers
{
    public class WorkflowController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
