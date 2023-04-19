using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PickItEasy.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Create_BaseDocument : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Warehouses",
                type: "varchar",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "BaseDocuments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "varchar", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseDocuments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WhsOrderOutBaseDocuments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    WhsOrderOutId = table.Column<Guid>(type: "uuid", nullable: false),
                    BaseDocumentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhsOrderOutBaseDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WhsOrderOutBaseDocuments_BaseDocuments_BaseDocumentId",
                        column: x => x.BaseDocumentId,
                        principalTable: "BaseDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WhsOrderOutBaseDocuments_WhsOrdersOut_WhsOrderOutId",
                        column: x => x.WhsOrderOutId,
                        principalTable: "WhsOrdersOut",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WhsOrderOutBaseDocuments_BaseDocumentId",
                table: "WhsOrderOutBaseDocuments",
                column: "BaseDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_WhsOrderOutBaseDocuments_WhsOrderOutId",
                table: "WhsOrderOutBaseDocuments",
                column: "WhsOrderOutId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WhsOrderOutBaseDocuments");

            migrationBuilder.DropTable(
                name: "BaseDocuments");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Warehouses",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 120);
        }
    }
}
