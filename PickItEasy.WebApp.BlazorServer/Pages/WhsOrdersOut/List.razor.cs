using MediatR;
using Microsoft.AspNetCore.Components;
using PickItEasy.Application.Dtos;
using PickItEasy.Application.Services.WhsOrdersOut.Queries.GetList;
using PickItEasy.EventBus.RabbitMq;

namespace PickItEasy.WebApp.BlazorServer.Pages.WhsOrdersOut
{
    public partial class List : IDisposable
    {
        [Inject] public required IMediator Mediator { get; set; }

        private string pageMessage = "Hello!";
        private WhsOrderOutListVm whsOrderOutListVm = new();
        private WhsOrderOutSearchParameters searchParameters = new();
        private string searchTerm = "";

        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await GetListWhsOrdersOut();
        }

        private async Task GetListWhsOrdersOut()
        {
            searchParameters = new WhsOrderOutSearchParameters { SearchTerm = searchTerm };
            var getListWhsOrderOutQuery = new GetListWhsOrderOutQuery { SearchParameters = searchParameters };
            whsOrderOutListVm = await Mediator.Send(getListWhsOrderOutQuery);
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
            await GetListWhsOrdersOut();
            await InvokeAsync(StateHasChanged);
        }

        public void Dispose()
        {
            WhsOrderOutConsumer.MessageReceived += async (sender, args) => await MessageReceivedHandle(sender, args);
        }
    }
}
