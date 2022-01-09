using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MicroStruct.Web.Models;
using System.Diagnostics;

namespace MicroStruct.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TableBasic()
        {
            return View();
        }

        public IActionResult TableDatatable()
        {
            return View();
        }

        public IActionResult FormElements()
        {
            return View();
        }

        public IActionResult FormInputGroup()
        {
            return View();
        }

        public IActionResult FormLayouts()
        {
            return View();
        }

        public IActionResult FormValidations()
        {
            return View();
        }

        public IActionResult FormWizard()
        {
            return View();
        }

        public IActionResult FormTextEditor()
        {
            return View();
        }

        public IActionResult FormFileUpload()
        {
            return View();
        }

        public IActionResult FormDateTimePickes()
        {
            return View();
        }

        public IActionResult FormSelect2()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Authorize]
        public async Task<IActionResult> Login()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }
    }
}