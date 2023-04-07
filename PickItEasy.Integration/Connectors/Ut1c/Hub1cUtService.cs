using Microsoft.AspNetCore.SignalR;
using PickItEasy.Application.Dtos;
using PickItEasy.Application.Interfaces.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PickItEasy.Integration.Connectors.Ut1c
{
    public class Hub1cUtService : IHub1cUtService, IDisposable
    {
        private readonly IHubContext<Hub1cUt> _hubContext;

        public Hub1cUtService(IHubContext<Hub1cUt> hubContext)
        {
            _hubContext = hubContext;
            Hub1cUt.MessageReceived += MessageReceivedHandel;
        }

        private void MessageReceivedHandel(object? sender, string message)
        {
            Console.WriteLine(message);
        }

        public async Task<string> SendWhsOrderOutAsync(WhsOrderOutDto whsOrderOutDto)
        {                                    
            string result = await _hubContext.Clients.Client(Hub1cUt.ConnectionId)
                .InvokeAsync<string>("PostWhsOrderOutDto", whsOrderOutDto, CancellationToken.None);
            
            await Console.Out.WriteLineAsync(result);
            return result;
        }

        public void Dispose()
        {
            Hub1cUt.MessageReceived -= MessageReceivedHandel;
        }
    }
}
