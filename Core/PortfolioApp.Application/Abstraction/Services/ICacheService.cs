namespace PortfolioApp.Application.Abstraction.Services;

public interface IResponseCacheService
{
    Task CacheResponseAsync(string cacheKey, object response, TimeSpan expireTimeSeconds);
    Task<string> GetCachedResponseAsync(string cacheKey);
}