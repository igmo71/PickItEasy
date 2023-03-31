using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Integration.WhsOrdersOut;
using PickItEasy.Application.Interfaces;
using PickItEasy.Application.Interfaces.Integration;
using PickItEasy.Application.Services.WhsOrdersOut.Queries.GetById;
using PickItEasy.Domain.Entities;

namespace PickItEasy.WebApp.BlazorServer.Pages.WhsOrdersOut
{
    public partial class Item
    {
        [Inject]
        public required IMediator Mediator { get; set; }

        [Parameter]
        public string? Id { get; set; }

        private WhsOrderOutVm? whsOrderOut;
        private string pageMessage = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            if (string.IsNullOrEmpty(Id)) return;
            var getByIdWhsOrderOutQuery = new GetByIdWhsOrderOutQuery { Id = Guid.Parse(Id) };
            whsOrderOut = await Mediator.Send(getByIdWhsOrderOutQuery);
        }

        private async Task PostWhsOrderOut()
        {
            if (whsOrderOut is null) return;
            var postWhsOrderOutRequest = new PostWhsOrderOutRequest { GetByIdWhsOrderOutVm = whsOrderOut };
            var httpStatusCode = await Mediator.Send(postWhsOrderOutRequest);
            pageMessage = httpStatusCode.ToString();
        }
    }
}
