using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Concecionaria.Validations
{
    public class ValidationFilterAttribute : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //context.Result = new BadRequestObjectResult(context.ModelState);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            

            if (!context.ModelState.IsValid)
            {
                context.Result = new UnprocessableEntityObjectResult(context.ModelState);

            }
        }
    }
}
