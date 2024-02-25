using ECommerce.Core.DTOs.Authentication;
using ECommerce.Core.Models.Authentication;

namespace ECommerce.Core.Services
{
    public interface ITokenService
    {
        TokenDTO CreateToken(AppUser appUser);
        ClientTokenDTO CreateClientToken(Client client);
    }
}
