using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using PortfolioApp.Application.Abstraction.Services;
using JsonConverter = Newtonsoft.Json.JsonConverter;

namespace PortfolioApp.Persistance.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CacheAttribute<T> : Attribute, IAsyncActionFilter
    {
        private readonly int _expireTimeSeconds;

        public CacheAttribute(int expireTimeSeconds)
        {
            _expireTimeSeconds = expireTimeSeconds;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var cacheFactory = context.HttpContext.RequestServices.GetRequiredService<IResponseCacheService>();

            var cacheKey = _GenerateCacheKeyFromRequest(context.HttpContext.Request);

            var cachedResponse = await cacheFactory.GetCachedResponseAsync(cacheKey);


            if (!string.IsNullOrEmpty(cachedResponse))
            {
                T? cachedResult = JsonConvert.DeserializeObject<T>(cachedResponse);
                context.Result = new OkObjectResult(cachedResult);
                return;
            }

            var executedContext = await next();

            if (executedContext.Result is ObjectResult objectResult && objectResult.Value is T result)
            {
                await cacheFactory.CacheResponseAsync(cacheKey, result, TimeSpan.FromSeconds(_expireTimeSeconds));
            }
        }

        private static string _GenerateCacheKeyFromRequest(HttpRequest httpContextRequest)
        {
            var keyBuilder = new StringBuilder();
            keyBuilder.Append($"{httpContextRequest.Path}");

            foreach (var (key, value) in httpContextRequest.Query.OrderBy(x => x.Key))
            {
                keyBuilder.Append($"|{key}-{value}");
            }

            return keyBuilder.ToString();
        }
    }
}
