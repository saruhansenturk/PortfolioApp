using Microsoft.AspNetCore.Identity;
using PortfolioApp.Application.Abstraction.Services;
using PortfolioApp.Application.Dtos.User;
using PortfolioApp.Application.Response;
using PortfolioApp.Domain.Entities.Identity;

namespace PortfolioApp.Persistance.Services
{
    public class UserService<T> : IUserService<T>
    {
        private readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CommonResponse<bool>> CreateAsync(CreateUserDto createUserDto)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = createUserDto.UserName,
                Email = createUserDto.Email,
                NameSurname = createUserDto.NameSurname
            }, createUserDto.Password);


            CommonResponse<bool> response = new()
            {
                ResponseStatus = result.Succeeded ? ResponseStatus.Success : ResponseStatus.Fail
            };

            if (result.Succeeded)
                response.Message = "Kullanici basariyla olusturuldu...";
            else
                result.Errors.ToList().ForEach(error =>
                {
                    response.Errors.Add($"{error.Code} - {error.Description}");
                });

            return response;
        }
    }
}
