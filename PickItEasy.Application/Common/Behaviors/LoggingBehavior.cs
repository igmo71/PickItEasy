using MediatR;
using PickItEasy.Application.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Common.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ICurrentUserService _currentUserService;

        public LoggingBehavior(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;

            Log.Information("PickItEasy.WebApi Request: {RequestName} {@UserId} {@RequestBody}", typeof(TRequest).Name, userId, request);

            var response = await next();

            Log.Information("PickItEasy.WebApi Response: {ResponseName} {@UserId} {@ResponseBody}", typeof(TResponse).Name, userId, response);

            return response;
        }
    }
}
