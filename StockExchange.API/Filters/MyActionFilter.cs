using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;

namespace StockExchange.API.Filters
{
    public class MyActionAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("executed\n\n\n");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("executing\n\n\n");
        }
    }
}
