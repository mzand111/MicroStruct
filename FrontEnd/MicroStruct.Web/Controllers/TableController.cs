using Microsoft.AspNetCore.Mvc;

namespace MicroStruct.Web.Controllers
{
    public class TableController : Controller
    {
        public IActionResult TableBasic()
        {
            return View();
        }

        public IActionResult TableDatatable()
        {
            return View();
        }
    }
}
