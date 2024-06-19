using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace DevLibraryMads.API.Filters
{
    public class ValidationFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            context.Result = new OkObjectResult(context);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var messages = context.ModelState
                .SelectMany(e => e.Value.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();
            context.Result = new BadRequestObjectResult(messages);
        }
    }
}
