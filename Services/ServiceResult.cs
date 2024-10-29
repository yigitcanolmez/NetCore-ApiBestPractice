using System.Net;
using System.Text.Json.Serialization;

namespace Services;

public class ServiceResult<T>
{
    public T? Data { get; set; }
    public List<string>? ErrorMessage { get; set; }

    [JsonIgnore] public bool IsSuccess => ErrorMessage == null || ErrorMessage.Count == 0;
    [JsonIgnore] public bool IsFail => !IsSuccess;
    [JsonIgnore] public HttpStatusCode StatusCode { get; set; }

    public static ServiceResult<T> Success(T data, HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        return new ServiceResult<T>
        {
            Data = data,
            StatusCode = statusCode,
            ErrorMessage = null
        };
    }

    public static ServiceResult<T> Fail(string errorMessage, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
    {
        return new ServiceResult<T>
        {
            Data = default,
            StatusCode = statusCode,
            ErrorMessage = [errorMessage]
        };
    }

    public static ServiceResult<T> Fail(List<string> errorMessage,
        HttpStatusCode statusCode = HttpStatusCode.BadRequest)
    {
        return new ServiceResult<T>
        {
            Data = default,
            StatusCode = statusCode,
            ErrorMessage = errorMessage
        };
    }
}

public class ServiceResult
{
    public List<string>? ErrorMessage { get; set; }
    [JsonIgnore] public bool IsSuccess => ErrorMessage == null || ErrorMessage.Count == 0;
    [JsonIgnore] public bool IsFail => !IsSuccess;
    [JsonIgnore] public HttpStatusCode StatusCode { get; set; }

    public static ServiceResult Success(HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        return new ServiceResult
        {
            StatusCode = statusCode,
            ErrorMessage = null
        };
    }

    public static ServiceResult Fail(string errorMessage, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
    {
        return new ServiceResult
        {
            StatusCode = statusCode,
            ErrorMessage = [errorMessage]
        };
    }

    public static ServiceResult Fail(List<string> errorMessage,
        HttpStatusCode statusCode = HttpStatusCode.BadRequest)
    {
        return new ServiceResult
        {
            StatusCode = statusCode,
            ErrorMessage = errorMessage
        };
    }
}