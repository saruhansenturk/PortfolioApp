namespace PortfolioApp.Application.Extensions
{
    public static class GeneratorExtension
    {
        public static string GetTypeProp<T>(this string val)
        {
            val = $"{val[0].ToString().ToUpper()}{val.Remove(0, 1)}";
            return val;
        }
    }
}
