
using ECommerce.Core.DTOs.Response;
using ECommerce.Core.DTOs.User;
using ECommerce.Core.Models.Authentication;
using ECommerce.Core.Services;
using ECommerce.Service.Mapping;
using Microsoft.AspNetCore.Identity;


namespace ECommerce.Service.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<ResponseDTO<AppUserDTO>> CreateUserAsync(CreateUserDTO createUserDTO)
        {
            var user = new AppUser { UserName = createUserDTO.UserName, Email = createUserDTO.Email };

            var result = await _userManager.CreateAsync(user);

            if(!result.Succeeded)
            {

              var errors = result.Errors.Select(x => x.Description).ToList();
              return ResponseDTO<AppUserDTO>.Fail(new ErrorDto(errors, true), 400);

            }

            return ResponseDTO<AppUserDTO>.Succes(200, ObjectMapper.Mapper.Map<AppUserDTO>(user));
        }

        public async Task<ResponseDTO<AppUserDTO>> GetUserByNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if(user == null)
            {
                return ResponseDTO<AppUserDTO>.Fail("User not found", 400,true);
            }

            return ResponseDTO<AppUserDTO>.Succes(200, ObjectMapper.Mapper.Map<AppUserDTO>(user));

        }
    }
}
