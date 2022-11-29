using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WarehouseApp.ActionFilters
{
    public class AuthenticationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionDescriptor.DisplayName != "WarehouseApp.Controllers.HomeController.Index (WarehouseApp)" && context.ActionDescriptor.DisplayName != "WarehouseApp.Controllers.UsersController.Login (WarehouseApp)" && context.ActionDescriptor.DisplayName != "WarehouseApp.Controllers.UsersController.Register (WarehouseApp)" && context.HttpContext.Session.GetString("LoggedIn") == null)
            {
                context.Result = new RedirectResult("/Home/Index");
            }
            if (context.HttpContext.Session.GetString("LoggedIn") != null && (context.ActionDescriptor.DisplayName == "WarehouseApp.Controllers.HomeController.Index (WarehouseApp)" || context.ActionDescriptor.DisplayName == "WarehouseApp.Controllers.UsersController.Login (WarehouseApp)" || context.ActionDescriptor.DisplayName == "WarehouseApp.Controllers.UsersController.Register (WarehouseApp)")) {
                context.Result = new RedirectResult("/Products/Index");
            }
        }
    }
}
