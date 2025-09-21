namespace Jcvalera.Core.Common.Api
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        
        public int StatusCode { get; set; }
        
        public string? Message { get; set; }
        
        public T? Data { get; set; }

        public string Token { get; set; }

        public IEnumerable<string>? Errors { get; set; }


        // Constructor to sucess response token
        public ApiResponse(string token, int statusCode = 200, string? message = null)
        {
            Success = true;
            StatusCode = statusCode;
            Message = message ?? "Operación exitosa.";
            Token = token;
        }

        // Constructor to sucess response
        public ApiResponse(T data, int statusCode = 200, string? message = null)
        {
            Success = true;
            StatusCode = statusCode;
            Message = message ?? "Operación exitosa.";
            Data = data;
        }


        // Constructor to bad response
        public ApiResponse(int statusCode, string message, IEnumerable<string>? errors = null)
        {
            Success = false;
            StatusCode = statusCode;
            Message = message;
            Errors = errors;
        }
    }
}
