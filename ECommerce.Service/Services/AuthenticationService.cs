using ECommerce.Core.DTOs.Authentication;
using ECommerce.Core.DTOs.Response;
using ECommerce.Core.Models.Authentication;
using ECommerce.Core.Repositories;
using ECommerce.Core.Services;
using ECommerce.Core.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ECommerce.Service.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly List<Client> _clients;
        private readonly ITokenService _tokenService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<UserRefreshToken> _userRefreshTokenService;

        public AuthenticationService(IOptions<List<Client>> optionsClient, ITokenService tokenService, UserManager<AppUser> userManager, IUnitOfWork unitOfWork, IGenericRepository<UserRefreshToken> userRefreshTokenService)
        {
            _clients = optionsClient.Value;

            _tokenService = tokenService;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _userRefreshTokenService = userRefreshTokenService;
        }

        public async Task<ResponseDTO<TokenDTO>> CreateTokenAsync(LoginDTO loginDTO)
        {
            if(loginDTO == null) {  throw new ArgumentNullException(nameof(loginDTO)); }

            var user = await _userManager.FindByEmailAsync(loginDTO.Email);

            if(user == null) { return ResponseDTO<TokenDTO>.Fail("Email or Password is wrong",400,true); }

            if(!await _userManager.CheckPasswordAsync(user, loginDTO.Password)) { return ResponseDTO<TokenDTO>.Fail("Email or Password is wrong", 400, true); }

            var token = _tokenService.CreateToken(user);

            var userRefreshToken = await _userRefreshTokenService.Where(x => x.UserId == user.Id).SingleOrDefaultAsync();

            if (userRefreshToken == null)
            {
                await _userRefreshTokenService.AddAsync(new UserRefreshToken { UserId = user.Id , Code = token.RefreshToken, Expiration = token.RefreshTokenExpiration });
            }
            else
            {
                userRefreshToken.Code = token.RefreshToken;
                userRefreshToken.Expiration = token.RefreshTokenExpiration;
            }

            await _unitOfWork.CommitAsync();

            return ResponseDTO<TokenDTO>.Succes(200, token);

        }

        public ResponseDTO<ClientTokenDTO> CreateTokenByClient(ClientLoginDTO clientLoginDTO)
        {
            var client = _clients.SingleOrDefault(x => x.Id == clientLoginDTO.ClientId && x.Secret == clientLoginDTO.ClientSecret);

            if (client == null)
            {
                return ResponseDTO<ClientTokenDTO>.Fail("ClientId Or ClientSecret not found", 404, true);
            }

            var token = _tokenService.CreateClientToken(client);

            return ResponseDTO<ClientTokenDTO>.Succes(200, token);
        }

        public Task<ResponseDTO<TokenDTO>> CreateTokenByRefreshToken(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<NoDataDTO>> RevokeRefreshToken(string refreshToken)
        {
            throw new NotImplementedException();
        }
    }
}
