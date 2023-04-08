using PickItEasy.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Integration.Proxy
{
    public class RequestHandler : IRequestHandler
    {
        private readonly ILogger<RequestHandler> _logger;
        public RequestHandler(ILogger<RequestHandler> logger)
        {
            _logger = logger;
        }

        public Task<string> Handle<T>(T request)
        {
            _logger.LogInformation(typeof(T).Name);
            string result = typeof(T).Name;
            return Task.FromResult(result);
        }
    }
}
