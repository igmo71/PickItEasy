using MediatR;
using Microsoft.AspNetCore.Components;
using PickItEasy.Application.Dtos;
using PickItEasy.EventBus.RabbitMq;
using WhsOrderOutStatuses = PickItEasy.Application.Services.WhsOrderOutStatuses.Queries.GetList;
using WhsOrderOutQueues = PickItEasy.Application.Services.WhsOrderOutQueues.Queries.GetList;
using WhsOrdersOut = PickItEasy.Application.Services.WhsOrdersOut.Queries;
using PickItEasy.Application.Services.WhsOrdersOut.Queries;

namespace PickItEasy.WebApp.BlazorServer.Pages.WhsOrders.Out
{
    public partial class List : IDisposable
    {
        [Parameter]
        public string? StatusId { get; set; }

        [Inject] public required IMediator Mediator { get; set; }

        private string? barcode;

        private string pageMessage = "Hello!";
        private WhsOrderOutListVm orderListVm = new();
        private WhsOrderOutDictionaryByQueueVm orderOutDictionaryByQueueVm = new();
        private WhsOrderOutStatusListVm statusListVm = new();
        private WhsOrderOutQueueListVm queueListVm = new();
        private SearchParameters searchParameters = new();

        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await GetStatusList();
            await GetQueueList();
            SetInitialStatusId();
            SetSearchParameters();
            await GetOrderList();
            await GetOrderDictionaryByQueue();
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

        private void SetInitialStatusId()
        {
            if (!string.IsNullOrEmpty(StatusId)) return;
            var initialStatus = statusListVm.Statuses?.FirstOrDefault();
            StatusId = initialStatus == null ? Guid.Empty.ToString() : initialStatus.Id.ToString();
        }

        private void SetSearchParameters()
        {
            searchParameters.StatusId = string.IsNullOrEmpty(StatusId) ? Guid.Empty : Guid.Parse(StatusId);
        }

        private async Task GetOrderList()
        {
            var getListQuery = new WhsOrdersOut.GetList.GetListQuery { SearchParameters = searchParameters };
            orderListVm = await Mediator.Send(getListQuery);
        }
        private async Task GetOrderDictionaryByQueue()
        {
            var getDictionaryByQueueQuery = new WhsOrdersOut.GetDictionaryByQueue.GetDictionaryByQueueQuery { SearchParameters = searchParameters };
            orderOutDictionaryByQueueVm = await Mediator.Send(getDictionaryByQueueQuery);
        }

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            if (firstRender)
            {
                WhsOrderOutConsumer.MessageReceived += async (sender, args) => await MessageReceivedHandle(sender, args);
            }
        }

        private async Task MessageReceivedHandle(object? sender, string message)
        {
            pageMessage = $"{sender}: {message}";
            await GetOrderList();
            await InvokeAsync(StateHasChanged);
        }

        public void Dispose()
        {
            WhsOrderOutConsumer.MessageReceived += async (sender, args) => await MessageReceivedHandle(sender, args);
        }

        private async Task ScannedBarcodeAsync(ChangeEventArgs args)
        {
            barcode = args.Value?.ToString();
            //await SearchByBarcodeAsync();
            pageMessage = barcode;
        }

        private async Task NavigationOnClickHandle(Guid statusId)
        {
            pageMessage = statusListVm.Statuses.FirstOrDefault(e => e.Id == statusId).Synonym;
            searchParameters.StatusId = statusId;
            await HandleSearch();
        }

        private async Task HandleSearch()
        {
            await GetOrderDictionaryByQueue();
        }
    }
}
