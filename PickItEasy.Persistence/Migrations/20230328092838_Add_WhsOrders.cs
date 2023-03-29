using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PickItEasy.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Add_WhsOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WhsOrdersIn",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "varchar", maxLength: 120, nullable: false),
                    Number = table.Column<string>(type: "varchar", maxLength: 60, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhsOrdersIn", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WhsOrdersOut",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "varchar", maxLength: 120, nullable: false),
                    Number = table.Column<string>(type: "varchar", maxLength: 60, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhsOrdersOut", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WhsOrderInProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    WhsOrderInId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Count = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhsOrderInProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WhsOrderInProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WhsOrderInProducts_WhsOrdersIn_WhsOrderInId",
                        column: x => x.WhsOrderInId,
                        principalTable: "WhsOrdersIn",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WhsOrderOutProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    WhsOrderOutId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Count = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhsOrderOutProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WhsOrderOutProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WhsOrderOutProducts_WhsOrdersOut_WhsOrderOutId",
                        column: x => x.WhsOrderOutId,
                        principalTable: "WhsOrdersOut",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WhsOrderInProducts_ProductId",
                table: "WhsOrderInProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_WhsOrderInProducts_WhsOrderInId",
                table: "WhsOrderInProducts",
                column: "WhsOrderInId");

            migrationBuilder.CreateIndex(
                name: "IX_WhsOrderOutProducts_ProductId",
                table: "WhsOrderOutProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_WhsOrderOutProducts_WhsOrderOutId",
                table: "WhsOrderOutProducts",
                column: "WhsOrderOutId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WhsOrderInProducts");

            migrationBuilder.DropTable(
                name: "WhsOrderOutProducts");

            migrationBuilder.DropTable(
                name: "WhsOrdersIn");

            migrationBuilder.DropTable(
                name: "WhsOrdersOut");
        }
    }
}
