using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using Forum.MVCUI.ExtensionClasses;

namespace Forum.UI.Filters
{
    public class RoleAuthorizeAttribute : ActionFilterAttribute
    {
        private readonly string _requiredRole;

        public RoleAuthorizeAttribute(string requiredRole)
        {
            _requiredRole = requiredRole;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var user = context.HttpContext.Session.GetObject<string>("UserName");
            var role = context.HttpContext.Session.GetObject<string>("UserRole");

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(role) || role != _requiredRole)
            {
                context.Result = new RedirectToActionResult("Login", "Login", null);
            }
            base.OnActionExecuting(context);
        }
    }
}
