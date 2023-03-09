using RequestService.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace RequestService.Attributes
{
    public class UserIdAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context) { }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            RequestsController? c = context.Controller as RequestsController;
            c!.UserId = c.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
