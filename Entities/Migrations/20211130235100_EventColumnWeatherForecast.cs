using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class EventColumnWeatherForecast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WeatherForecast",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WeatherForecast",
                table: "Events");
        }
    }
}
