using Microsoft.EntityFrameworkCore;
using PickItEasy.Domain;
using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<WhsOrderIn> WhsOrdersIn { get; set; }
        public DbSet<WhsOrderInProduct> WhsOrderInProducts { get; set; }

        public DbSet<WhsOrderOut> WhsOrdersOut { get; set; }
        public DbSet<WhsOrderOutProduct> WhsOrderOutProducts { get; set; }

        public DbSet<WhsOrderStatus> WhsOrderStatuses { get; set; }
        public DbSet<WhsOrderOutStatus> WhsOrderOutStatuses { get; set; }

        public DbSet<WhsOrderQueue> WhsOrderQueues { get; set; }
        public DbSet<WhsOrderOutQueue> WhsOrderOutQueues { get; set; }
    }
}
