using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Interfaces;
using PickItEasy.Application.Interfaces.Integration;
using PickItEasy.Domain.Entities;

namespace PickItEasy.WebApp.BlazorServer.Pages.WhsOrdersOut
{
    public partial class Item
    {
        [Inject]
        public IApplicationDbContext? DbContext { get; set; }

        [Inject]
        public IClient1cUt? Client1cUt { get; set; }

        [Parameter]
        public string? Id { get; set; }

        private WhsOrderOut? whsOrderOut;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            whsOrderOut = await DbContext.WhsOrdersOut.FirstOrDefaultAsync(e => e.Id.ToString() == Id);
        }

        private async Task PostWhsOrderOut()
        {
            await Client1cUt.PostWhsOrderOutAsync(whsOrderOut);
        }
    }
}
