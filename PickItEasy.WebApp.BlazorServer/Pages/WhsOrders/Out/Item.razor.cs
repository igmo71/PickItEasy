using MediatR;
using Microsoft.AspNetCore.Components;
using PickItEasy.Application.Dtos;
using PickItEasy.Application.Integration.WhsOrdersOut;
using PickItEasy.Application.Services.WhsOrdersOut.Queries.GetById;

namespace PickItEasy.WebApp.BlazorServer.Pages.WhsOrders.Out
{
    public partial class Item
    {
        [Inject]
        public required IMediator Mediator { get; set; }

        [Parameter]
        public string? Id { get; set; }

        private string? barcode;

        private WhsOrderOutVm? whsOrderOutVm;
        private string pageMessage = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            if (string.IsNullOrEmpty(Id)) return;
            var getByIdWhsOrderOutQuery = new GetByIdQuery { Id = Guid.Parse(Id) };
            whsOrderOutVm = await Mediator.Send(getByIdWhsOrderOutQuery);
        }

        private async Task PostWhsOrderOut()
        {
            if (whsOrderOutVm is null) return;
            var postWhsOrderOutRequest = new PostWhsOrderOutRequest { WhsOrderOutVm = whsOrderOutVm };
            var result = await Mediator.Send(postWhsOrderOutRequest);
            pageMessage = result;
        }

        private async Task ScannedBarcodeAsync(ChangeEventArgs args)
        {
            barcode = args.Value?.ToString();
            //await SearchByBarcodeAsync();
            pageMessage = barcode;
        }
    }
}
