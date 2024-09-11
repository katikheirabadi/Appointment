using Appointment.Attributes;
using Appointment.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Appointment.Controllers
{
    public class HomeController : Controller
    {
        private readonly Config configuration;

        public HomeController(Config configuration)
        {
            this.configuration = configuration;
        }
        public IActionResult Index()
        {
            if (Request.Cookies.Keys.Count != 0)
                return RedirectToAction("Dashboard", "Panel");
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
        [HttpPost]
        public IActionResult Login(LoginInputDto dto)
        {
            ViewBag.Color1 = this.configuration.Color1;
            ViewBag.Color2 = this.configuration.Color2;
            ViewBag.Color3 = this.configuration.Color3;
            ViewBag.DarkColor1 = this.configuration.DarkColor1;
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            var cookieOptions = new CookieOptions
            {
                
                Expires = DateTimeOffset.UtcNow.AddMinutes(5),
                HttpOnly = true,
                Secure = true // Set to true if using HTTPS,
                
            };

            HttpContext.Response.Cookies.Append("UserName", dto.UserName, cookieOptions);
            return RedirectToAction("Dashboard", "Panel");
        }
    }
}