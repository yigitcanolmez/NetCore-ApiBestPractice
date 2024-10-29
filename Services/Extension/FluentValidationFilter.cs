using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Services.Extension;

public class FluentValidationFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.ModelState.IsValid)
        {
            var errorMessages = context.ModelState.Values.SelectMany(x => x.Errors)
                .Select(y => y.ErrorMessage).ToList();

            var result = ServiceResult.Fail(errorMessages);

            context.Result = new BadRequestObjectResult(result);
            
            return;
        }

        await next();
    }
}