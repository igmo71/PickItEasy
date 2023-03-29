using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PickItEasy.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Add_WeatherForecasts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WeatherForecast",
                table: "WeatherForecast");

            migrationBuilder.RenameTable(
                name: "WeatherForecast",
                newName: "WeatherForecasts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeatherForecasts",
                table: "WeatherForecasts",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WeatherForecasts",
                table: "WeatherForecasts");

            migrationBuilder.RenameTable(
                name: "WeatherForecasts",
                newName: "WeatherForecast");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeatherForecast",
                table: "WeatherForecast",
                column: "ProductId");
        }
    }
}
