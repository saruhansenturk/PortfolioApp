using System.Threading.RateLimiting;

namespace PortfolioApp.Api.Extensions
{
    public static class RateLimitingExtension
    {
        public static void AddRequestLimit(this WebApplicationBuilder builder)
        {
            builder.Services.AddRateLimiter(options =>
            {
                options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
                    RateLimitPartition.GetFixedWindowLimiter(
                        partitionKey: httpContext.User.Identity?.Name ?? httpContext.Request.Headers.Host.ToString(),
                        factory: partition => new FixedWindowRateLimiterOptions
                        {
                            AutoReplenishment = true,
                            PermitLimit = 100,
                            QueueLimit = 0,
                            Window = TimeSpan.FromMinutes(1),
                        }));

                //options.RejectionStatusCode = 429;    // You can do this. But this return just statuscode

                options.OnRejected = async (context, token) =>
                {
                    context.HttpContext.Response.StatusCode = StatusCodes.Status429TooManyRequests;
                    if (context.Lease.TryGetMetadata(MetadataName.RetryAfter, out var retryAfter))
                    {
                        await context.HttpContext.Response.WriteAsync(
                            $"Too many requests. Please try again after {retryAfter.TotalMinutes} minute(s).", cancellationToken: token);
                    }
                    else
                    {

                        await context.HttpContext.Response.WriteAsync(
                            $"Too many requests. Please try again later." +
                            $"Read more about our rate limits at https://example.org/docs/ratelimiting.", cancellationToken: token);
                    }
                };
            });
        }
    }
}
