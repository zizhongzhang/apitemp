using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace webapi.Filters
{
    public class MyAsyncResponseFilter : ResultFilterAttribute
    {
        public async override Task OnResultExecutionAsync(ResultExecutingContext context,
                                                 ResultExecutionDelegate next)
        {
            context.HttpContext.Response.Redirect("https://google.com.au");
        }
    }
}
