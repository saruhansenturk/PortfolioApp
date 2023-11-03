using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PortfolioApp.Infrastructure.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState
                    .Where(t => t.Value.Errors.Any())
                    .ToDictionary(t => t.Key, t => t.Value.Errors.Select(t => t.ErrorMessage))
                    .ToArray();

                context.Result = new BadRequestObjectResult(errors);

                return;
            }

            await next();
        }
    }
}
