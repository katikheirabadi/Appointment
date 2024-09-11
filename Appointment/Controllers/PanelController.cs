using Appointment.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.Controllers
{
    public class PanelController : Controller
    {
        private readonly Config configuration;
        public PanelController(Config config)
        {
            configuration = config;
        }
        [Auth]
        public IActionResult Dashboard()
        {
            ViewBag.Color1 = this.configuration.Color1;
            ViewBag.Color2 = this.configuration.Color2;
            ViewBag.Color3 = this.configuration.Color3;
            ViewBag.DarkColor1 = this.configuration.DarkColor1;

            ViewBag.UserName = Request.Cookies["UserName"].ToString();
            return View();
        }

        [Auth]
        public IActionResult Users()
        {
            ViewBag.Color1 = this.configuration.Color1;
            ViewBag.Color2 = this.configuration.Color2;
            ViewBag.Color3 = this.configuration.Color3;
            ViewBag.DarkColor1 = this.configuration.DarkColor1;
            ViewBag.UserName = Request.Cookies["UserName"].ToString();

            return View();
        }


    }
}
