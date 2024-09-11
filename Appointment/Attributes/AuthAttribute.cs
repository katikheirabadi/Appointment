using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Appointment.Attributes
{
    public class AuthAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!IsUserAuthorized(context.HttpContext))
            {
                context.Result = new RedirectResult("/Home/Login");
            }
            base.OnActionExecuting(context);
        }
        private bool IsUserAuthorized(HttpContext context)
        {
            if (context.Request.Cookies.ContainsKey("UserName"))
            {
                return true;
            }
            return false;
        }
    }
}
