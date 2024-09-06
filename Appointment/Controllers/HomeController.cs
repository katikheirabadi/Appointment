using Appointment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Appointment.Controllers
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
            var cookieOptions = new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddDays(1),
                HttpOnly = true,
                Secure = true // Set to true if using HTTPS
            };

            HttpContext.Response.Cookies.Append("UserName", "JohnDoe", cookieOptions);
            return View();
        }

        public IActionResult Privacy()
        {
            string userName = Request.Cookies["UserName"]?.ToString();
            ViewBag.UserName = userName;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}