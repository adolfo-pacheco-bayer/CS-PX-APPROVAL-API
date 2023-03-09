
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PX.Approval.Domain.Response;
using PX.Library.Common.Middleware.Exceptions;
using System.Net;

namespace PX.Approval.Crosscutting;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;

    public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionMessageAsync(context, ex).ConfigureAwait(false);
        }
    }

    private Task HandleExceptionMessageAsync(HttpContext context, Exception exception)
    {
        var statusCode = HttpStatusCode.InternalServerError;

        var response = new Response()
            .CreateErrorResponseAsync(statusCode)
            .WithErrorAsync<ExceptionsMessage>(x => ExceptionsMessage.GlobalExceptionHandling);

        var result = JsonConvert.SerializeObject(response);

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        _logger.LogError(exception, ExceptionsMessage.GlobalExceptionHandling);

        return context.Response.WriteAsync(result);
    }
}