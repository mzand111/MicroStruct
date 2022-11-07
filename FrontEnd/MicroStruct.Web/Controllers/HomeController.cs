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
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            Debug.WriteLine("Token");
            Debug.WriteLine(accessToken);
            Debug.WriteLine("end token");
            return View();
        }
        [Authorize]
        public async Task<IActionResult> Cartable()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            Debug.WriteLine("Token");
            Debug.WriteLine(accessToken);
            Debug.WriteLine("end token");
            return View();
        }

        public IActionResult UserProfile()
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