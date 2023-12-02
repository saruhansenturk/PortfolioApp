using Microsoft.Extensions.DependencyInjection;
using PortfolioApp.Application;
using PortfolioApp.Application.Abstraction.Services;
using PortfolioApp.Application.Abstraction.Services.Authentication;
using PortfolioApp.Application.Repositories;
using PortfolioApp.Persistance.Repositories;
using PortfolioApp.Persistance.Services;

namespace PortfolioApp.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddScoped<IProgrammingLanguageReadRepository, ProgrammingLanguageReadRepository>();
            services.AddScoped<IProgrammingLanguageWriteRepository, ProgrammingLanguageWriteRepository>();
            services.AddScoped<IProgrammingLanguageTechReadRepository, ProgrammingLanguageTechReadRepository>();
            services.AddScoped<IProgrammingLanguageTechWriteRepository, ProgrammingLanguageTechWriteRepository>();
            services.AddScoped<IFlexReadRepository, FlexReadRepository>();
            services.AddScoped<IFlexWriteRepository, FlexWriteRepository>();
            services.AddScoped<IArticleReadRepository, ArticleReadRepository>();
            services.AddScoped<IArticleWriteRepository, ArticleWriteRepository>();

            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();


            services.AddScoped<IArticleCategoryWriteRepository, ArticleCategoryWriteRepository>();

            services.AddScoped(typeof(IUserService<>), typeof(UserService<>));
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IResponseCacheService, ResponseCacheService>();
            services.AddScoped<IInternalAuthentication, AuthService>();
        }
    }
}
