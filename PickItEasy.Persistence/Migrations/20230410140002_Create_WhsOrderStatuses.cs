using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PickItEasy.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Create_WhsOrderStatuses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WhsOrderStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "varchar", maxLength: 120, nullable: false),
                    Synonym = table.Column<string>(type: "varchar", maxLength: 120, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhsOrderStatuses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "WhsOrderStatuses",
                columns: new[] { "Id", "Discriminator", "IsActive", "Name", "Synonym", "Value" },
                values: new object[,]
                {
                    { new Guid("17cee206-e06f-47d8-824d-14eeceaf394a"), "WhsOrderOutStatus", false, "ВПроцессеПроверки", "В процессе проверки", 3 },
                    { new Guid("7c2bd6be-cf81-4b1a-9acf-d4ebf416f4d3"), "WhsOrderOutStatus", true, "КОтгрузке", "К отгрузке", 5 },
                    { new Guid("9eba20ce-9245-4109-92cb-a9875801fbb4"), "WhsOrderOutStatus", true, "Отгружен", "Отгружен", 6 },
                    { new Guid("bd1ae241-d787-4a6d-b920-029bc6577364"), "WhsOrderOutStatus", false, "КПроверке", "К проверке", 2 },
                    { new Guid("c2c5935d-b332-4d84-b1fd-309ad8a65356"), "WhsOrderOutStatus", true, "Подготовлено", "Подготовлено", 0 },
                    { new Guid("e1a4c395-f7a3-40af-82ab-ad545e51eca7"), "WhsOrderOutStatus", true, "КОтбору", "К отбору", 1 },
                    { new Guid("e911589b-613c-42ad-ad56-7083c481c4b4"), "WhsOrderOutStatus", false, "Проверен", "Проверен", 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WhsOrderStatuses");
        }
    }
}
