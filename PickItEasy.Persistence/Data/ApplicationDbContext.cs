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

        public DbSet<Document> Documents => Set<Document>();
        public DbSet<DocumentHistory> DocumentHistory => Set<DocumentHistory>();
        public DbSet<DocumentItem> DocumentItems => Set<DocumentItem>();
        public DbSet<DocumentItemHistory> DocumentItemHistory => Set<DocumentItemHistory>();

        public DbSet<WhsOrder> WhsOrders => Set<WhsOrder>();
        public DbSet<WhsOrderHistory> OrderHistory => Set<WhsOrderHistory>();
        public DbSet<WhsOrderProductHistory> WhsOrderProductHistory => Set<WhsOrderProductHistory>();
        public DbSet<WhsOrderIn> WhsOrdersIn => Set<WhsOrderIn>();
        public DbSet<WhsOrderOut> WhsOrdersOut { get; set; }

        public DbSet<Product> Products => Set<Product>();

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
