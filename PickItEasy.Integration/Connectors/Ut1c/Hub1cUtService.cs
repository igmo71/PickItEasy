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
            Hub1cUt.ResultReceived += ResultReceivedHandel;
        }

        private void ResultReceivedHandel(object? sender, string message)
        {
            Console.WriteLine(message);
        }

        public async Task SendWhsOrderOutAsync(WhsOrderOutDto whsOrderOutDto)
        {
            //var message = JsonSerializer.Serialize(whsOrderOutDto);
            //await _hubContext.Clients.Group(Hub1cUt.HUB_1C_UT_GROUP)
            //    .SendAsync("PostWhsOrderOutDto", whsOrderOutDto);

            var clientId = Hub1cUt.connections[0];

            CancellationTokenSource cts = new CancellationTokenSource();

            //string result = await _hubContext.Clients.Client(clientId)
            //    .InvokeAsync<string>("PostWhsOrderOutDtoWithResponse", whsOrderOutDto, cts.Token);
                        
            string result = await _hubContext.Clients.Client(clientId)
                .InvokeAsync<string>("PostWhsOrderOutDtoWithResponse", "Request from Hub", CancellationToken.None);
            
            await Console.Out.WriteLineAsync(result);
        }

        public void Dispose()
        {
            Hub1cUt.ResultReceived -= ResultReceivedHandel;
        }
    }
}
