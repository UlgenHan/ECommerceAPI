
using System.Text.Json.Serialization;


namespace ECommerce.Core.DTOs.Response
{
    public class ResponseDTO<T>
    {

        public T Data { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }

        public List<string> Errors { get; set; }

        public ErrorDto Error { get; private set; }

        public bool IsSuccessful { get; set; }

        public static ResponseDTO<T> Succes(int statusCode, T data)
        {
            return new ResponseDTO<T> { StatusCode = statusCode, Data = data };
        }

        public static ResponseDTO<T> Succes(int statusCode)
        {
            return new ResponseDTO<T> { StatusCode = statusCode };
        }

        public static ResponseDTO<T> Succes(int statusCode, string error)
        {
            return new ResponseDTO<T> { StatusCode = statusCode, Errors = new List<string> { error } };
        }

        public static ResponseDTO<T> Fail(ErrorDto errorDto, int statusCode)
        {
            return new ResponseDTO<T>
            {
                Error = errorDto,
                StatusCode = statusCode,
                IsSuccessful = false
            };
        }

        public static ResponseDTO<T> Fail(string errorMessage, int statusCode, bool isShow)
        {
            var errorDto = new ErrorDto(errorMessage, isShow);

            return new ResponseDTO<T> { Error = errorDto, StatusCode = statusCode, IsSuccessful = false };
        }

    }
}
