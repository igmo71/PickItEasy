using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Interfaces;
using PickItEasy.Domain;
using PickItEasy.Domain.Entities;
using PickItEasy.Persistence.Data.EntityTypeConfigurations;
using PickItEasy.Persistence.Data.EntityTypeConfigurations.WhsOrder;
using PickItEasy.Persistence.Data.EntityTypeConfigurations.WhsOrder.Out;
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // WhsOrder
            builder.ApplyConfiguration(new WhsOrderQueueConfiguration());
            builder.ApplyConfiguration(new WhsOrderStatusConfiguration());            
                // In
            //builder.ApplyConfiguration(new WhsOrderInConfiguration());
            //builder.ApplyConfiguration(new WhsOrderInProductConfiguration());            
                // Out
            builder.ApplyConfiguration(new WhsOrderOutBaseDocumentConfiguration());
            builder.ApplyConfiguration(new WhsOrderOutConfiguration());
            builder.ApplyConfiguration(new WhsOrderOutProductConfiguration());
            builder.ApplyConfiguration(new WhsOrderOutQueueConfiguration());
            builder.ApplyConfiguration(new WhsOrderOutStatusConfiguration());
            //
            builder.ApplyConfiguration(new BaseDocumentConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new QueueNumbersConfiguration());
            builder.ApplyConfiguration(new WarehouseConfiguration());

            builder.ApplyConfiguration(new WeatherForecastConfiguration());
        }
    }
}
