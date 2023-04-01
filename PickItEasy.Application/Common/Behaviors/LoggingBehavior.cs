using MediatR;
using PickItEasy.Application.Interfaces;
using Serilog;

namespace PickItEasy.Application.Common.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse> where TRequest : IBaseRequest
    {
        private readonly ICurrentUserService _currentUserService;

        public LoggingBehavior(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;

            //Log.Information("PickItEasy Request: {RequestName} - {ResponseName}", typeof(TRequest).Name, typeof(TResponse).Name);
            Log.Debug("PickItEasy Request: {RequestName}<{ResponseName}> {@RequestBody} {@UserId}", typeof(TRequest).Name, typeof(TResponse).Name, request, userId);

            var response = await next();

            Log.Debug("PickItEasy Response: {RequestName}<{ResponseName}> {@ResponseBody} {@UserId}", typeof(TRequest).Name, typeof(TResponse).Name, response, userId);
            //Log.Information("PickItEasy Response: {RequestName} - {ResponseName}", typeof(TRequest).Name, typeof(TResponse).Name);

            return response;
        }
    }
}
