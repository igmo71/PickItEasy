using MediatR;
using Microsoft.AspNetCore.Components;
using PickItEasy.Application.Dtos;
using PickItEasy.EventBus.RabbitMq;
using WhsOrderOutStatuses = PickItEasy.Application.Services.WhsOrderOutStatuses.Queries.GetList;
using WhsOrderOutQueues = PickItEasy.Application.Services.WhsOrderOutQueues.Queries.GetList;
using WhsOrdersOut = PickItEasy.Application.Services.WhsOrdersOut.Queries;
using PickItEasy.Application.Services.WhsOrdersOut.Queries;
using PickItEasy.Application.Common;

namespace PickItEasy.WebApp.BlazorServer.Pages.WhsOrders.Out
{
    public partial class List : IDisposable
    {
        [Inject] public required IMediator Mediator { get; set; }
        [Inject] public required SearchParameters SearchParameters { get; set; }

        private string? barcode;

        private string pageMessage = "Hello!";

        private WhsOrderOutStatusListVm statusListVm = new();       
        private WhsOrderOutQueueListVm queueListVm = new();
        private WhsOrderOutDictionaryByQueueVm orderOutDictionaryByQueueVm = new();

        protected async override Task OnInitializedAsync()
        {
            await GetStatusList();
            await GetQueueList();
            await SearchHandle();
        }
        private async Task GetStatusList()
        {
            var getStatusListQuery = new WhsOrderOutStatuses.GetListQuery();
            statusListVm = await Mediator.Send(getStatusListQuery);            
        }

        private async Task GetQueueList()
        {
            var getSQueueListQuery = new WhsOrderOutQueues.GetListQuery();
            queueListVm = await Mediator.Send(getSQueueListQuery);
        }

        private async Task SearchHandle()
        {
            await GetOrderDictionaryByQueue();
            //await InvokeAsync(StateHasChanged);
        }

        private async Task GetOrderDictionaryByQueue()
        {
            var getDictionaryByQueueQuery = new WhsOrdersOut.GetDictionaryByQueue.GetDictionaryByQueueQuery
            {
                SearchParameters = SearchParameters
            };
            orderOutDictionaryByQueueVm = await Mediator.Send(getDictionaryByQueueQuery);
        }

        private async Task NavigationOnClickHandle(Guid statusId)
        {
            SearchParameters.StatusId = statusId;
            await SearchHandle();
        }

        private async Task ScannedBarcodeAsync(ChangeEventArgs args)
        {
            barcode = args.Value?.ToString();
            SearchParameters.DocumentId = BarcodeGuidConvert.FromNumericString(barcode);
            await SearchHandle();
            SearchParameters.DocumentId = null;
            pageMessage = barcode ?? string.Empty;
        }

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                WhsOrderOutConsumer.MessageReceived += async (sender, args) => await MessageReceivedHandle(sender, args);
            }
        }

        private async Task MessageReceivedHandle(object? sender, string message)
        {
            await SearchHandle();
            pageMessage = $"{sender}: {message}";
        }

        public void Dispose()
        {
            WhsOrderOutConsumer.MessageReceived -= async (sender, args) => await MessageReceivedHandle(sender, args);
        }
    }
}
