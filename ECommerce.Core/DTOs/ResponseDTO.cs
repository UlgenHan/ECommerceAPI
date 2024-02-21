
using System.Text.Json.Serialization;


namespace ECommerce.Core.DTOs
{
    public class ResponseDTO<T>
    {

        public T Data { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }

        public List<String> Errors { get; set; }

        public static ResponseDTO<T> Succes(int statusCode,T data)
        {
            return new ResponseDTO<T> { StatusCode = statusCode, Data = data };
        }

        public static ResponseDTO<T> Succes(int statusCode)
        {
            return new ResponseDTO<T> { StatusCode = statusCode };
        }

        public static ResponseDTO<T> Succes(int statusCode, string error)
        {
            return new ResponseDTO<T> { StatusCode = statusCode, Errors = new List<String> { error } };
        }


    }
}
