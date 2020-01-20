using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace webapi.Filters
{
    public class MyAsyncActionFilter : ActionFilterAttribute
    {
        private readonly UserService _userService;
        public MyAsyncActionFilter(UserService userService)
        {
            _userService = userService;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (_userService.GetUser().Firstname == "zi")
            {
                context.Result = new RedirectResult("https://www.google.com.au");
            }
            else
            {
                await next();
            }
        }
    }
}
