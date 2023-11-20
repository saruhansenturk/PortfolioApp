namespace PortfolioApp.Api.Extensions
{
    public static class AppSettingExtension
    {
        public static T GetInfoFromAppsettings<T>(this IConfiguration configuration) where T : class, new()
        {
            T instance = new T();
            configuration.Bind(typeof(T).Name, instance);
            return instance;
        }
    }
}
