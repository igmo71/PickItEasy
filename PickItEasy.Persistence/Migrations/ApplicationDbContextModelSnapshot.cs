﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PickItEasy.Persistence.Data;

#nullable disable

namespace PickItEasy.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("PickItEasy.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("PickItEasy.Domain.Entities.WhsOrderOut", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("varchar");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar");

                    b.Property<Guid>("QueueId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("StatusId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("QueueId");

                    b.HasIndex("StatusId");

                    b.ToTable("WhsOrdersOut");
                });

            modelBuilder.Entity("PickItEasy.Domain.Entities.WhsOrderOutProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<float>("Count")
                        .HasColumnType("real");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("WhsOrderOutId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("WhsOrderOutId");

                    b.ToTable("WhsOrderOutProducts");
                });

            modelBuilder.Entity("PickItEasy.Domain.Entities.WhsOrderQueue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("varchar");

                    b.Property<string>("Synonym")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("varchar");

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("WhsOrderQueues");

                    b.HasDiscriminator<string>("Discriminator").HasValue("WhsOrderQueue");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("PickItEasy.Domain.Entities.WhsOrderStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("varchar");

                    b.Property<string>("Synonym")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("varchar");

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("WhsOrderStatuses");

                    b.HasDiscriminator<string>("Discriminator").HasValue("WhsOrderStatus");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("PickItEasy.Domain.WeatherForecast", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Summary")
                        .HasColumnType("text");

                    b.Property<int>("TemperatureC")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("WeatherForecasts");
                });

            modelBuilder.Entity("PickItEasy.Persistence.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("PickItEasy.Domain.Entities.WhsOrderOutQueue", b =>
                {
                    b.HasBaseType("PickItEasy.Domain.Entities.WhsOrderQueue");

                    b.HasDiscriminator().HasValue("WhsOrderOutQueue");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7e83260a-316f-4a1f-be9a-bf353b118536"),
                            IsActive = true,
                            Name = "LiveQueue",
                            Synonym = "Живая очередь",
                            Value = 10
                        },
                        new
                        {
                            Id = new Guid("3558d2ba-ffb6-4f08-9891-f7f1e8853c83"),
                            IsActive = true,
                            Name = "Schedule",
                            Synonym = "Собрать к дате",
                            Value = 20
                        },
                        new
                        {
                            Id = new Guid("d964fcad-d71d-480a-bdeb-0b2c045fcd90"),
                            IsActive = true,
                            Name = "SelfDelivery",
                            Synonym = "Собственная доставка",
                            Value = 30
                        },
                        new
                        {
                            Id = new Guid("8bdc656e-8a2c-4aef-9422-e0a419608190"),
                            IsActive = true,
                            Name = "NoQue",
                            Synonym = "Очередность не указана",
                            Value = 40
                        });
                });

            modelBuilder.Entity("PickItEasy.Domain.Entities.WhsOrderOutStatus", b =>
                {
                    b.HasBaseType("PickItEasy.Domain.Entities.WhsOrderStatus");

                    b.HasDiscriminator().HasValue("WhsOrderOutStatus");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c2c5935d-b332-4d84-b1fd-309ad8a65356"),
                            IsActive = true,
                            Name = "Подготовлено",
                            Synonym = "Подготовлено",
                            Value = 0
                        },
                        new
                        {
                            Id = new Guid("e1a4c395-f7a3-40af-82ab-ad545e51eca7"),
                            IsActive = true,
                            Name = "КОтбору",
                            Synonym = "К отбору",
                            Value = 1
                        },
                        new
                        {
                            Id = new Guid("bd1ae241-d787-4a6d-b920-029bc6577364"),
                            IsActive = false,
                            Name = "КПроверке",
                            Synonym = "К проверке",
                            Value = 2
                        },
                        new
                        {
                            Id = new Guid("17cee206-e06f-47d8-824d-14eeceaf394a"),
                            IsActive = false,
                            Name = "ВПроцессеПроверки",
                            Synonym = "В процессе проверки",
                            Value = 3
                        },
                        new
                        {
                            Id = new Guid("e911589b-613c-42ad-ad56-7083c481c4b4"),
                            IsActive = false,
                            Name = "Проверен",
                            Synonym = "Проверен",
                            Value = 4
                        },
                        new
                        {
                            Id = new Guid("7c2bd6be-cf81-4b1a-9acf-d4ebf416f4d3"),
                            IsActive = true,
                            Name = "КОтгрузке",
                            Synonym = "К отгрузке",
                            Value = 5
                        },
                        new
                        {
                            Id = new Guid("9eba20ce-9245-4109-92cb-a9875801fbb4"),
                            IsActive = true,
                            Name = "Отгружен",
                            Synonym = "Отгружен",
                            Value = 6
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("PickItEasy.Persistence.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("PickItEasy.Persistence.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PickItEasy.Persistence.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("PickItEasy.Persistence.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PickItEasy.Domain.Entities.WhsOrderOut", b =>
                {
                    b.HasOne("PickItEasy.Domain.Entities.WhsOrderOutQueue", "Queue")
                        .WithMany()
                        .HasForeignKey("QueueId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("PickItEasy.Domain.Entities.WhsOrderOutStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Queue");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("PickItEasy.Domain.Entities.WhsOrderOutProduct", b =>
                {
                    b.HasOne("PickItEasy.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PickItEasy.Domain.Entities.WhsOrderOut", "WhsOrderOut")
                        .WithMany("WhsOrderOutProducts")
                        .HasForeignKey("WhsOrderOutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("WhsOrderOut");
                });

            modelBuilder.Entity("PickItEasy.Domain.Entities.WhsOrderOut", b =>
                {
                    b.Navigation("WhsOrderOutProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
