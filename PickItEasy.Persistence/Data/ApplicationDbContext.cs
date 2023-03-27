using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Interfaces;
using PickItEasy.Domain;
using PickItEasy.Domain.Entities;
using PickItEasy.Persistence.Data.EntityTypeConfigurations;
using PickItEasy.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Persistence.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentHistory> DocumentHistory { get; set; }
        public DbSet<Item> DocumentItems { get; set; }
        public DbSet<ItemHistory> DocumentItemHistory { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<WhsOrder> WhsOrders { get; set; }
        public DbSet<WhsOrderProduct> WhsOrderProducts { get; set; }
        public DbSet<WhsOrderHistory> OrderHistory { get; set; }
        public DbSet<ProductHistory> WhsOrderProductHistory { get; set; }
        public DbSet<WhsOrderIn> WhsOrdersIn { get; set; }
        public DbSet<WhsOrderInProduct> WhsOrderInProducts { get; set; }
        public DbSet<WhsOrderOut> WhsOrdersOut { get; set; }
        public DbSet<WhsOrderOutProduct> WhsOrderOutProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new WeatherForecastConfiguration());

            builder.ApplyConfiguration(new DocumentConfiguration());
            builder.ApplyConfiguration(new DocumentItemConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new WhsOrderConfiguration());
            builder.ApplyConfiguration(new WhsOrderHistoryConfiguration());
            builder.ApplyConfiguration(new WhsOrderProductHistoryConfiguration());
        }
    }
}
