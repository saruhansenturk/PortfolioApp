using MediatR;
using PortfolioApp.Application.Abstraction.Services;
using PortfolioApp.Application.Response;

namespace PortfolioApp.Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {

        private readonly IUserService<bool> _userService;

        public CreateUserCommandHandler(IUserService<bool> userService)
        {
            _userService = userService;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request,
            CancellationToken cancellationToken)
        {
            CommonResponse<bool> response = await _userService.CreateAsync(new()
            {
                Email = request.Email,
                Password = request.Password,
                NameSurname = request.NameSurname,
                PasswordConfirm = request.PasswordConfirm,
                UserName = request.UserName
            });

            return new()
            {
                CreateUserResponse = response
            };
        }
    }
}
