using MediatR;
using Microsoft.AspNetCore.Components;
using PickItEasy.Application.Common;
using PickItEasy.Application.Dtos;
using PickItEasy.Application.Services.WhsOrdersOut.Queries;
using PickItEasy.Application.Services.WhsOrdersOut.Queries.GetDictionaryByQueue;
using PickItEasy.EventBus.RabbitMq;
using WhsOrderOutQueues = PickItEasy.Application.Services.WhsOrderOutQueues.Queries.GetList;
using WhsOrderOutStatuses = PickItEasy.Application.Services.WhsOrderOutStatuses.Queries.GetList;
using WhsOrdersOut = PickItEasy.Application.Services.WhsOrdersOut.Queries;

namespace PickItEasy.WebApp.BlazorServer.Pages.WhsOrders.Out
{
    public partial class List : IDisposable
    {
        [Inject] public required IMediator Mediator { get; set; }
        [Inject] public required SearchParameters SearchParameters { get; set; }
        [Inject] public required NavigationManager NavigationManager { get; set; }

        private string? barcode;

        private string pageMessage = "Hello!";

        private WhsOrderOutStatusListVm statusListVm = new();
        private WhsOrderOutQueueListVm queueListVm = new();
        //private WhsOrderOutDictionaryByQueueVm orderDictionaryVm = new();
        private WhsOrderOutListVm orderListVm = new();

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
            if (SearchParameters.StatusId is null)
                SearchParameters.StatusId = statusListVm.Statuses?.FirstOrDefault()?.Id;
        }

        private async Task GetQueueList()
        {
            var getSQueueListQuery = new WhsOrderOutQueues.GetListQuery();
            queueListVm = await Mediator.Send(getSQueueListQuery);
        }

        private async Task SearchHandle()
        {
            await GetWhsOrderDictionaryByQueue(/*searchParameters*/);
            //await InvokeAsync(StateHasChanged);
        }

        private async Task GetWhsOrderDictionaryByQueue() // TODO: Rename to GetWhsOrderList
        {
            //var getDictionaryByQueueQuery = new WhsOrdersOut.GetDictionaryByQueue.GetDictionaryByQueueQuery
            var getListQuery = new WhsOrdersOut.GetList.GetListQuery
            {
                SearchParameters = SearchParameters
            };
            //orderListVm = await Mediator.Send(getDictionaryByQueueQuery);
            orderListVm = await Mediator.Send(getListQuery);
        }

        private async Task NavigationOnClickHandle(Guid statusId)
        {
            SearchParameters.StatusId = statusId;
            await SearchHandle();
        }

        private async Task ScannedBarcodeHandle(ChangeEventArgs args)
        {
            barcode = args.Value?.ToString();
            if (barcode is null) return;
            pageMessage = barcode;

            SearchParameters.DocumentId = BarcodeGuidConvert.FromNumericString(barcode);

            await SearchHandle();

            TryOpenItem(SearchParameters.DocumentId);

            SearchParameters.DocumentId = null;
        }

        private void TryOpenItem(Guid? documentId)
        {
            if (IsDocumentSingle())
                NavigationManager?.NavigateTo($"WhsOrders/Out/Item/{documentId}");
            else
                SearchParameters.StatusId = Guid.Empty;
        }

        private bool IsDocumentSingle()
        {
            return orderListVm.Orders != null
                && orderListVm.Orders.Count == 1
                && orderListVm.Orders.FirstOrDefault().Value != null
                && orderListVm.Orders.FirstOrDefault().Value.Count == 1;
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
            pageMessage = $"{sender}: {message}";

            if (SearchParameters.StatusId == Guid.Empty) return;

            await SearchHandle();
            await InvokeAsync(StateHasChanged);
        }

        public void Dispose()
        {
            WhsOrderOutConsumer.MessageReceived -= async (sender, args) => await MessageReceivedHandle(sender, args);
        }
    }
}
