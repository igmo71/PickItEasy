using Microsoft.EntityFrameworkCore;
using PickItEasy.Domain;
using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        // WhsOrder
        public DbSet<WhsOrderQueue> WhsOrderQueues { get; set; }
        public DbSet<WhsOrderStatus> WhsOrderStatuses { get; set; }
        // In
        //public DbSet<WhsOrderIn> WhsOrdersIn { get; set; }
        //public DbSet<WhsOrderInProduct> WhsOrderInProducts { get; set; }
        // Out
        public DbSet<WhsOrderOutBaseDocument> whsOrderOutBaseDocuments { get; set; }
        public DbSet<WhsOrderOut> WhsOrdersOut { get; set; }
        public DbSet<WhsOrderOutProduct> WhsOrderOutProducts { get; set; }
        public DbSet<WhsOrderOutQueue> WhsOrderOutQueues { get; set; }
        public DbSet<WhsOrderOutStatus> WhsOrderOutStatuses { get; set; }
        //
        public DbSet<BaseDocument> BaseDocuments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<QueueNumber> QueueNumber { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}
