using PortfolioApp.Application.Dtos.User;
using PortfolioApp.Application.Response;

namespace PortfolioApp.Application.Abstraction.Services;

public interface IUserService<T>
{
    Task<CommonResponse<bool>> CreateAsync(CreateUserDto createUserDto);
}