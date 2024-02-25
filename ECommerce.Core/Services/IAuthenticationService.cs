using ECommerce.Core.DTOs;
using ECommerce.Core.DTOs.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Services
{
    public interface IAuthenticationService
    {
        Task<ResponseDTO<TokenDTO>> CreateTokenAsync(LoginDTO loginDTO);
        Task<ResponseDTO<TokenDTO>> CreateTokenByRefreshToken(string refreshToken);

        Task<ResponseDTO<NoDataDTO>> RevokeRefreshToken(string refreshToken);

        ResponseDTO<ClientLoginDTO> CreateTokenByClient(ClientLoginDTO clientLoginDTO);
    }
}
