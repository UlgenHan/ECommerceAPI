namespace ECommerce.Core.DTOs.Authentication
{
    public class ClientTokenDTO
    {
        public string AccessToken { get; set; }

        public DateTime AccessTokenExpiration { get; set; }
    }
}
