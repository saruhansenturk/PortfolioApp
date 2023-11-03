using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PortfolioApp.Application.Abstraction.Token;

namespace PortfolioApp.Infrastructure.Services.Token
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Application.Dtos.Token CrateAccessToken(int second)
        {
            Application.Dtos.Token token = new();

            SymmetricSecurityKey securitykey = new(Encoding.UTF8.GetBytes(_configuration["TokenOptions:SecurityKey"]));

            SigningCredentials signingCredentials = new(securitykey, SecurityAlgorithms.HmacSha256);

            token.Expiration = DateTime.Now.AddMinutes(second);
            JwtSecurityToken securityToken = new(
                audience: _configuration["TokenOptions:Audience"],
                issuer: _configuration["TokenOptions:Issuer"],
                expires: token.Expiration,
                notBefore: DateTime.Now,
                signingCredentials: signingCredentials);

            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken = tokenHandler.WriteToken(securityToken);

            return token;
        }
    }
}
