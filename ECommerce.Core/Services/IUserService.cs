using ECommerce.Core.DTOs;
using ECommerce.Core.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Services
{
    public interface IUserService
    {
        Task<ResponseDTO<AppUserDTO>> CreateUserAsync(CreateUserDTO createUserDTO);

        Task<ResponseDTO<AppUserDTO>> GetUserByNameAsync(string userName);
    }
}
