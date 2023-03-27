using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PickItEasy.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Refactor_Documents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductWhsOrder_DocumentItems_ProductsId",
                table: "ProductWhsOrder");

            migrationBuilder.RenameColumn(
                name: "ProductsId",
                table: "ProductWhsOrder",
                newName: "ProductId");

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Documents",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Documents",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "DocumentDocumentItem",
                columns: table => new
                {
                    DocumentsId = table.Column<Guid>(type: "uuid", nullable: false),
                    ItemsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentDocumentItem", x => new { x.DocumentsId, x.ItemsId });
                    table.ForeignKey(
                        name: "FK_DocumentDocumentItem_DocumentItems_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "DocumentItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentDocumentItem_Documents_DocumentsId",
                        column: x => x.DocumentsId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WhsOrderProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    WhsOrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Count = table.Column<float>(type: "real", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhsOrderProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WhsOrderProducts_DocumentItems_ProductId",
                        column: x => x.ProductId,
                        principalTable: "DocumentItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WhsOrderProducts_Documents_WhsOrderId",
                        column: x => x.WhsOrderId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentDocumentItem_ItemsId",
                table: "DocumentDocumentItem",
                column: "ItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_WhsOrderProducts_ProductId",
                table: "WhsOrderProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_WhsOrderProducts_WhsOrderId",
                table: "WhsOrderProducts",
                column: "WhsOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductWhsOrder_DocumentItems_ProductId",
                table: "ProductWhsOrder",
                column: "ProductId",
                principalTable: "DocumentItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductWhsOrder_DocumentItems_ProductId",
                table: "ProductWhsOrder");

            migrationBuilder.DropTable(
                name: "DocumentDocumentItem");

            migrationBuilder.DropTable(
                name: "WhsOrderProducts");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProductWhsOrder",
                newName: "ProductsId");

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Documents",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Documents",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductWhsOrder_DocumentItems_ProductsId",
                table: "ProductWhsOrder",
                column: "ProductsId",
                principalTable: "DocumentItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
