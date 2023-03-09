using MediatR;
using Microsoft.Extensions.Logging;
using PX.Approval.Domain.DomainObjects;
using System.Diagnostics;
using System.Text.Json;

namespace PX.Crop.Application.Common.PipelineBehaviours;

public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
       where TRequest : IRequest<TResponse>
       where TResponse : IResponse
{
    private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;

    public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        //Pré
        var stopWatch = new Stopwatch();

        stopWatch.Start();

        _logger.LogInformation("[{0}] [{1}] is starting", this?.GetType().Name, request.GetType().Name);

        var response = await next();

        //Pos

        if (response != null)
        {
            var json = JsonSerializer.Serialize(response);
            _logger.LogInformation(json);
        }

        stopWatch.Stop();

        _logger.LogInformation("[{0}] [{1}] has finished. Elapsed time: {2}", this?.GetType().Name, request.GetType().Name, stopWatch.ElapsedMilliseconds.ToString());

        return response;
    }
}