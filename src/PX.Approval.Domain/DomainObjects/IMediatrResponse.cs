using System.Net;

namespace PX.Approval.Domain.DomainObjects;

public interface IResponse
{
    Task<Response.Response> CreateSuccessResponseAsync(object? data, string message = "");
    Task<Response.Response> CreateErrorResponseAsync(HttpStatusCode? statusCode = HttpStatusCode.BadRequest);
    Task<Response.Response> CreateErrorResponseAsync(object? data, HttpStatusCode? statusCode = HttpStatusCode.BadRequest);
}
