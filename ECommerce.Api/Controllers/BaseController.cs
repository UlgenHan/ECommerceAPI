using ECommerce.Core.DTOs.Response;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{

    public class BaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(ResponseDTO<T> response)
        {
            if (response.StatusCode == 204)
            {
                return new ObjectResult(null)
                {
                    StatusCode = response.StatusCode,
                };
            }

            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode,
            };
        }
    }
}
