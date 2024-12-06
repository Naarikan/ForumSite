using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Forum.UI.ExtensionClasses;
using System.Linq;

namespace Forum.UI.Authorize
{
    public class RoleAuthorizeAttribute : ActionFilterAttribute
    {
        private readonly string[] _requiredRoles;

        public RoleAuthorizeAttribute(params string[] requiredRoles)
        {
            _requiredRoles = requiredRoles;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var user = context.HttpContext.Session.GetObject<string>("UserName");
            var role = context.HttpContext.Session.GetObject<string>("UserRole");

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(role) || !_requiredRoles.Contains(role))
            {
                context.Result = new RedirectToActionResult("Login", "Login", null);
            }
            base.OnActionExecuting(context);
        }




    }
}
