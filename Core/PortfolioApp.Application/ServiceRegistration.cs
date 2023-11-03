using Microsoft.Extensions.DependencyInjection;

namespace PortfolioApp.Application;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection collection)
    {
        collection.AddMediatR(opt =>
        {
            opt.RegisterServicesFromAssemblyContaining(typeof(ServiceRegistration));
        });
    }
}