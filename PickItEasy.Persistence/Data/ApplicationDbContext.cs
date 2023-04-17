﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using PickItEasy.Application.Interfaces;
using PickItEasy.Domain;
using PickItEasy.Domain.Entities;
using PickItEasy.Persistence.Data.EntityTypeConfigurations;
using PickItEasy.Persistence.Models;

namespace PickItEasy.Persistence.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
            Database.EnsureCreated();
            //Database.Migrate();
        }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

        public DbSet<Product> Products { get; set; }

        //public DbSet<WhsOrderIn> WhsOrdersIn { get; set; }
        //public DbSet<WhsOrderInProduct> WhsOrderInProducts { get; set; }
        public DbSet<WhsOrderOut> WhsOrdersOut { get; set; }
        public DbSet<WhsOrderOutProduct> WhsOrderOutProducts { get; set; }


        public DbSet<WhsOrderStatus> WhsOrderStatuses { get; set; }
        public DbSet<WhsOrderOutStatus> WhsOrderOutStatuses { get; set; }

        public DbSet<WhsOrderQueue> WhsOrderQueues { get; set; }
        public DbSet<WhsOrderOutQueue> WhsOrderOutQueues { get; set; }

        public DbSet<Warehouse> Warehouses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new WeatherForecastConfiguration());

            builder.ApplyConfiguration(new ProductConfiguration());
            //builder.ApplyConfiguration(new WhsOrderInConfiguration());
            //builder.ApplyConfiguration(new WhsOrderInProductConfiguration());
            builder.ApplyConfiguration(new WhsOrderOutConfiguration());
            builder.ApplyConfiguration(new WhsOrderOutProductConfiguration());
            builder.ApplyConfiguration(new WhsOrderStatusConfiguration());
            builder.ApplyConfiguration(new WhsOrderOutStatusConfiguration());
            builder.ApplyConfiguration(new WhsOrderQueueConfiguration());
            builder.ApplyConfiguration(new WhsOrderOutQueueConfiguration());


        }
    }
}
