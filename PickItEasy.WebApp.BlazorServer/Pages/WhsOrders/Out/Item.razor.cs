//using MediatR;
using Microsoft.AspNetCore.Components;
//using PickItEasy.Application.MediatR.Services.WhsOrdersOut.Queries.GetById;
using PickItEasy.Application.Interfaces.Services.WhsOrder.Out;
//using PickItEasy.Application.Integration.WhsOrdersOut;
using PickItEasy.Application.Models.WhsOrder.Out.Vm;

namespace PickItEasy.WebApp.BlazorServer.Pages.WhsOrders.Out
{
    public partial class Item
    {
        //[Inject] public required IMediator Mediator { get; set; }
        [Inject] public required IWhsOrderOutService WhsOrderOutService { get; set; }

        [Parameter] public string? Id { get; set; }

        private string? barcode;

        private WhsOrderOutVm? orderOutVm;
        private string pageMessage = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            await GetWhsOrderOut();
        }

        private async Task GetWhsOrderOut()
        {
            if (string.IsNullOrEmpty(Id)) return;

            //var getByIdWhsOrderOutQuery = new GetByIdQuery { Id = Guid.Parse(Id) };
            //orderOutVm = await Mediator.Send(getByIdWhsOrderOutQuery);

            orderOutVm = await WhsOrderOutService.GetByIdAsync(Guid.Parse(Id));
        }

        private async Task PostWhsOrderOut()
        {
            if (orderOutVm is null) return;

            //var postWhsOrderOutRequest = new PostWhsOrderOutRequest { WhsOrderOutVm = orderOutVm };
            //var result = await Mediator.Send(postWhsOrderOutRequest);            
            //pageMessage = result;
        }

        private async Task ScannedBarcodeAsync(ChangeEventArgs args)
        {
            barcode = args.Value?.ToString();
            //await SearchByBarcodeAsync();
            pageMessage = barcode ?? string.Empty;
        }
    }
}
