using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PickItEasy.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Add_Document_WhsOrder_Product : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Number = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DocumentId = table.Column<Guid>(type: "uuid", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentHistory_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentItemHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DocumentId = table.Column<Guid>(type: "uuid", nullable: false),
                    DocumentItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentItemHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentItemHistory_DocumentItems_DocumentItemId",
                        column: x => x.DocumentItemId,
                        principalTable: "DocumentItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentItemHistory_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductWhsOrder",
                columns: table => new
                {
                    ProductsId = table.Column<Guid>(type: "uuid", nullable: false),
                    WhsOrdersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductWhsOrder", x => new { x.ProductsId, x.WhsOrdersId });
                    table.ForeignKey(
                        name: "FK_ProductWhsOrder_DocumentItems_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "DocumentItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductWhsOrder_Documents_WhsOrdersId",
                        column: x => x.WhsOrdersId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentHistory_DocumentId",
                table: "DocumentHistory",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentItemHistory_DocumentId",
                table: "DocumentItemHistory",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentItemHistory_DocumentItemId",
                table: "DocumentItemHistory",
                column: "DocumentItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductWhsOrder_WhsOrdersId",
                table: "ProductWhsOrder",
                column: "WhsOrdersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentHistory");

            migrationBuilder.DropTable(
                name: "DocumentItemHistory");

            migrationBuilder.DropTable(
                name: "ProductWhsOrder");

            migrationBuilder.DropTable(
                name: "DocumentItems");

            migrationBuilder.DropTable(
                name: "Documents");
        }
    }
}
