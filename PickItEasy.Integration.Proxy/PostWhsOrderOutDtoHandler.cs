using PickItEasy.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Integration.Proxy
{
    public class PostWhsOrderOutDtoHandler : IRequestHandler, IDisposable
    {
        private readonly ILogger<PostWhsOrderOutDtoHandler> _logger;
        private readonly ISignalRHubClient _signalRHubClient;
        public PostWhsOrderOutDtoHandler(ILogger<PostWhsOrderOutDtoHandler> logger, ISignalRHubClient signalRHubClient)
        {
            _logger = logger;
            _signalRHubClient = signalRHubClient;
            _signalRHubClient.RegisterPostWhsOrderOutDtoHandler(Handle);
        }

        public Task<string> Handle<WhsOrderOutDto>(WhsOrderOutDto request)
        {
            string result = string.Empty;
            return Task.FromResult(result);
        }

        public void Dispose()
        {
            _signalRHubClient.UnregisterPostWhsOrderOutDtoHandler(Handle);
        }
    }
}
