using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PickItEasy.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Add_Warhouse_to_WhsOrderOut : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "WarehouseId",
                table: "WhsOrdersOut",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_WhsOrdersOut_WarehouseId",
                table: "WhsOrdersOut",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_WhsOrdersOut_Warehouses_WarehouseId",
                table: "WhsOrdersOut",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WhsOrdersOut_Warehouses_WarehouseId",
                table: "WhsOrdersOut");

            migrationBuilder.DropIndex(
                name: "IX_WhsOrdersOut_WarehouseId",
                table: "WhsOrdersOut");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "WhsOrdersOut");
        }
    }
}
