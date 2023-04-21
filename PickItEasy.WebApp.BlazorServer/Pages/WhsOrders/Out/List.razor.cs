using MediatR;
using Microsoft.AspNetCore.Components;
using PickItEasy.Application.Dtos;
using PickItEasy.Application.Services.WhsOrdersOut.Queries;
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
            await GetWhsOrderList();
            //await InvokeAsync(StateHasChanged);
        }

        private async Task GetWhsOrderList()
        {

            var getListQuery = new WhsOrdersOut.GetList.GetListQuery
            {
                SearchParameters = SearchParameters
            };
            orderListVm = await Mediator.Send(getListQuery);
        }

        private async Task ScannedBarcodeHandle(ChangeEventArgs args)
        {
            barcode = args.Value?.ToString();
            if (barcode is null) return;
            pageMessage = barcode;            

            SearchParameters.SetSearchByBarcode(barcode);

            await SearchHandle();

            TryOpenItem();
        }

        private void TryOpenItem()
        {
            if (IsDocumentSingle(out Guid? id)) { 
                SearchParameters.ClearSearchByBarcode();
                NavigationManager?.NavigateTo($"WhsOrders/Out/Item/{id}");
            }
            else
                SearchParameters.StatusId = Guid.Empty;
        }

        private bool IsDocumentSingle(out Guid? id)
        {
            var result = orderListVm.Orders != null
                && orderListVm.Orders.Count == 1
                && orderListVm.Orders.FirstOrDefault().Value != null
                && orderListVm.Orders.FirstOrDefault().Value.Count == 1;

            id = orderListVm.Orders?.FirstOrDefault().Value?.FirstOrDefault()?.Id;

            return result;
        }

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                SearchParameters.OnChange += StateHasChanged;
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
            SearchParameters.OnChange -= StateHasChanged;
            WhsOrderOutConsumer.MessageReceived -= async (sender, args) => await MessageReceivedHandle(sender, args);
        }
    }
}
