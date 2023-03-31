using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Dtos;
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

        private WhsOrderOutVm? whsOrderOutVm;
        private string pageMessage = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            if (string.IsNullOrEmpty(Id)) return;
            var getByIdWhsOrderOutQuery = new GetByIdWhsOrderOutQuery { Id = Guid.Parse(Id) };
            whsOrderOutVm = await Mediator.Send(getByIdWhsOrderOutQuery);
        }

        private async Task PostWhsOrderOut()
        {
            if (whsOrderOutVm is null) return;
            var postWhsOrderOutRequest = new PostWhsOrderOutRequest { WhsOrderOutVm = whsOrderOutVm };
            var httpStatusCode = await Mediator.Send(postWhsOrderOutRequest);
            pageMessage = httpStatusCode.ToString();
        }
    }
}
