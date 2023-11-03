using System.Security.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using PortfolioApp.Application.Abstraction.Services;
using PortfolioApp.Application.Abstraction.Token;
using PortfolioApp.Application.Dtos;
using PortfolioApp.Domain.Entities.Identity;

namespace PortfolioApp.Persistance.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenHandler _tokenHandler;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthService(IConfiguration configuration, UserManager<AppUser> userManager, ITokenHandler tokenHandler, SignInManager<AppUser> signInManager)
        {
            _configuration = configuration;
            _userManager = userManager;
            _tokenHandler = tokenHandler;
            _signInManager = signInManager;
        }


        public async Task<Token> LoginAsync(string userNameOrEmail, string password, int accesstokenLifeTime)
        {
            AppUser? user = await _userManager.FindByNameAsync(userNameOrEmail) ??
                            await _userManager.FindByEmailAsync(userNameOrEmail);

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);

            if (result.Succeeded)
            {
                Token token = _tokenHandler.CrateAccessToken(accesstokenLifeTime);
                return token;
            }

            throw new AuthenticationException();
        }
    }
}
