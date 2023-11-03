namespace PortfolioApp.Application.Abstraction.Services.Authentication
{
    public interface IInternalAuthentication
    {
        Task<Dtos.Token> LoginAsync(string userNameOrEmail, string password, int accesstokenLifeTime);
    }
}
