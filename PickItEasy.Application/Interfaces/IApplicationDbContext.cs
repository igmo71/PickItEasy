using Microsoft.EntityFrameworkCore;
using PickItEasy.Domain;
using PickItEasy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentHistory> DocumentsHistory { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemHistory> ItemsHistory { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<WhsOrder> WhsOrders { get; set; }
        public DbSet<WhsOrderProduct> WhsOrderProducts { get; set; }
        public DbSet<WhsOrderHistory> OrderHistory { get; set; }
        public DbSet<ProductHistory> WhsOrderProductHistory { get; set; }
        public DbSet<WhsOrderIn> WhsOrdersIn { get; set; }
        public DbSet<WhsOrderInProduct> WhsOrderInProducts { get; set; }
        public DbSet<WhsOrderOut> WhsOrdersOut { get; set; }
        public DbSet<WhsOrderOutProduct> WhsOrderOutProducts { get; set; }
    }
}
