namespace PortfolioApp.Application.Abstraction.Token
{
    public interface ITokenHandler
    {
        Dtos.Token CrateAccessToken(int second);
    }
}
