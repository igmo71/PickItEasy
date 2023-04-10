using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PickItEasy.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Create_WhsOrderQueues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WhsOrderQueues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "varchar", maxLength: 120, nullable: false),
                    Synonym = table.Column<string>(type: "varchar", maxLength: 120, nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhsOrderQueues", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "WhsOrderQueues",
                columns: new[] { "Id", "Discriminator", "IsActive", "Name", "Synonym", "Value" },
                values: new object[,]
                {
                    { new Guid("3558d2ba-ffb6-4f08-9891-f7f1e8853c83"), "WhsOrderOutQueue", true, "Schedule", "Собрать к дате", 20 },
                    { new Guid("7e83260a-316f-4a1f-be9a-bf353b118536"), "WhsOrderOutQueue", true, "LiveQueue", "Живая очередь", 10 },
                    { new Guid("8bdc656e-8a2c-4aef-9422-e0a419608190"), "WhsOrderOutQueue", true, "NoQue", "Очередность не указана", 40 },
                    { new Guid("d964fcad-d71d-480a-bdeb-0b2c045fcd90"), "WhsOrderOutQueue", true, "SelfDelivery", "Собственная доставка", 30 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WhsOrderQueues");
        }
    }
}
