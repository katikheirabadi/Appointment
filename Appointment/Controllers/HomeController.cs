using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Appointment.Controllers
{
    public class HomeController : Controller
    {
        //var cookieOptions = new CookieOptions
        //{
        //    Expires = DateTimeOffset.UtcNow.AddDays(1),
        //    HttpOnly = true,
        //    Secure = true // Set to true if using HTTPS
        //};

        //HttpContext.Response.Cookies.Append("UserName", "JohnDoe", cookieOptions);
        // string userName = Request.Cookies["UserName"]?.ToString();
        private readonly Config configuration;

        public HomeController(Config configuration)
        {
            this.configuration = configuration;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }
        public IActionResult Login()
        {
            ViewBag.Color1 = this.configuration.Color1;
            ViewBag.Color2 = this.configuration.Color2;
            ViewBag.Color3 = this.configuration.Color3;
            ViewBag.DarkColor1 = this.configuration.DarkColor1;
            return View();
        }
    }
}