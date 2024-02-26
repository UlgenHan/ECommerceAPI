using ECommerce.Core.DTOs.Response;
using ECommerce.Service.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace ECommerce.Api.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                    var statusCode = exceptionFeature.Error switch
                    {
                        ClientSideException => 400,
                        NotFoundException => 404,
                        _ => 500
                    };

                    context.Response.StatusCode = statusCode;

                    var response = ResponseDTO<NoDataDTO>.Fail(new ErrorDto() { Errors =  }, statusCode);
                });
            });
        }
    }
}
