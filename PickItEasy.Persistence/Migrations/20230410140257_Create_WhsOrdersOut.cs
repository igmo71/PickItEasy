using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PickItEasy.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Create_WhsOrdersOut : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WhsOrdersOut",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StatusId = table.Column<Guid>(type: "uuid", nullable: false),
                    QueueId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "varchar", maxLength: 120, nullable: false),
                    Number = table.Column<string>(type: "varchar", maxLength: 60, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhsOrdersOut", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WhsOrdersOut_WhsOrderQueues_QueueId",
                        column: x => x.QueueId,
                        principalTable: "WhsOrderQueues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_WhsOrdersOut_WhsOrderStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "WhsOrderStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WhsOrderOutProducts_WhsOrdersOut_WhsOrderOutId",
                        column: x => x.WhsOrderOutId,
                        principalTable: "WhsOrdersOut",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WhsOrderOutProducts_ProductId",
                table: "WhsOrderOutProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_WhsOrderOutProducts_WhsOrderOutId",
                table: "WhsOrderOutProducts",
                column: "WhsOrderOutId");

            migrationBuilder.CreateIndex(
                name: "IX_WhsOrdersOut_QueueId",
                table: "WhsOrdersOut",
                column: "QueueId");

            migrationBuilder.CreateIndex(
                name: "IX_WhsOrdersOut_StatusId",
                table: "WhsOrdersOut",
                column: "StatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WhsOrderOutProducts");

            migrationBuilder.DropTable(
                name: "WhsOrdersOut");
        }
    }
}
