using PortfolioApp.Application.Response;

namespace PortfolioApp.Application.Features.Commands.AppUser.CreateUser;

public class CreateUserCommandResponse
{
    public CommonResponse<bool> CreateUserResponse { get; set; }
}