using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Weather_App.Data.Migrations
{
    public partial class UpdatedAccountRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WeatherForecast_AccountId",
                table: "WeatherForecast");

            migrationBuilder.DropIndex(
                name: "IX_WeatherCurrent_AccountId",
                table: "WeatherCurrent");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDay",
                table: "Current",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherForecast_AccountId",
                table: "WeatherForecast",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherCurrent_AccountId",
                table: "WeatherCurrent",
                column: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WeatherForecast_AccountId",
                table: "WeatherForecast");

            migrationBuilder.DropIndex(
                name: "IX_WeatherCurrent_AccountId",
                table: "WeatherCurrent");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDay",
                table: "Current",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeatherForecast_AccountId",
                table: "WeatherForecast",
                column: "AccountId",
                unique: true,
                filter: "[AccountId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherCurrent_AccountId",
                table: "WeatherCurrent",
                column: "AccountId",
                unique: true,
                filter: "[AccountId] IS NOT NULL");
        }
    }
}
