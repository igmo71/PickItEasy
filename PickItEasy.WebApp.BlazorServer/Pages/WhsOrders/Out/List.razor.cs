﻿using MediatR;
using Microsoft.AspNetCore.Components;
using PickItEasy.Application.Common;
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
        private WhsOrderOutDictionaryByQueueVm orderDictionaryVm = new();

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

        private async Task GetWhsOrderDictionaryByQueue()
        {
            var getDictionaryByQueueQuery = new WhsOrdersOut.GetDictionaryByQueue.GetDictionaryByQueueQuery
            {
                SearchParameters = SearchParameters
            };
            orderDictionaryVm = await Mediator.Send(getDictionaryByQueueQuery);
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
            SearchParameters.DocumentId = null;

            TryOpenItem(SearchParameters.DocumentId);
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
            return orderDictionaryVm.Orders != null
                && orderDictionaryVm.Orders.Count == 1
                && orderDictionaryVm.Orders.FirstOrDefault().Value != null
                && orderDictionaryVm.Orders.FirstOrDefault().Value.Count == 1;
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
            await SearchHandle();
            await InvokeAsync(StateHasChanged);
        }

        public void Dispose()
        {
            WhsOrderOutConsumer.MessageReceived -= async (sender, args) => await MessageReceivedHandle(sender, args);
        }
    }
}
