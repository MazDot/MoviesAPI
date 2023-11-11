using Microsoft.AspNetCore.Mvc.Filters;

namespace MoviesAPI.Filters
{
    public class MyActionFilter : IActionFilter
    {
        private readonly ILogger<MyActionFilter> logger;

        public MyActionFilter(ILogger<MyActionFilter> _logger)
        {
            logger = _logger;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            logger.LogWarning("OnActionExecuted");

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            logger.LogWarning("OnActionExecuting");
        }
    }
}
