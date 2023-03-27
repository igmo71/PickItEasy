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
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Persistence.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>//, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentHistory> DocumentsHistory { get; set; }

        public DbSet<Item> Items { get; set; }
        public DbSet<ItemHistory> ItemsHistory { get; set; }

        public DbSet<DocumentItem> DocumentItem { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductHistory> ProductsHistory { get; set; }

        public DbSet<WhsOrder> WhsOrders { get; set; }
        public DbSet<WhsOrderHistory> WhsOrdersHistory { get; set; }
        public DbSet<WhsOrderProduct> WhsOrderProduct { get; set; }
        //public DbSet<WhsOrderIn> WhsOrdersIn { get; set; }
        //public DbSet<WhsOrderInProduct> WhsOrderInProducts { get; set; }
        //public DbSet<WhsOrderOut> WhsOrdersOut { get; set; }
        //public DbSet<WhsOrderOutProduct> WhsOrderOutProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new WeatherForecastConfiguration());

            builder.ApplyConfiguration(new DocumentConfiguration());
            builder.ApplyConfiguration(new ItemConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new WhsOrderConfiguration());
            builder.ApplyConfiguration(new WhsOrderHistoryConfiguration());
            builder.ApplyConfiguration(new WhsOrderProductHistoryConfiguration());

        }
    }
}
