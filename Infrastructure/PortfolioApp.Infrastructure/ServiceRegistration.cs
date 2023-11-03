using Microsoft.Extensions.DependencyInjection;
using PortfolioApp.Application.Abstraction.Token;
using PortfolioApp.Infrastructure.Services.Token;

namespace PortfolioApp.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ITokenHandler, TokenHandler>();

        }
    }
}
