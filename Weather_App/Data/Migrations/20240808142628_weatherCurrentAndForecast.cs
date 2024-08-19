using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Weather_App.Data.Migrations
{
    public partial class weatherCurrentAndForecast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Astro",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sunrise = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sunset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Moonrise = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Moonset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoonPhase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoonIllumination = table.Column<float>(type: "real", nullable: true),
                    IsMoonUp = table.Column<bool>(type: "bit", nullable: false),
                    IsSunUp = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Astro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Condition",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<float>(type: "real", nullable: true),
                    Longitude = table.Column<float>(type: "real", nullable: true),
                    TimeZone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocaltimeEpoch = table.Column<long>(type: "bigint", nullable: true),
                    Localtime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Current",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastUpdatedEpoch = table.Column<long>(type: "bigint", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TemperatureCelsius = table.Column<float>(type: "real", nullable: true),
                    TemperatureFahrenheit = table.Column<float>(type: "real", nullable: true),
                    IsDay = table.Column<bool>(type: "bit", nullable: false),
                    WindMPH = table.Column<float>(type: "real", nullable: true),
                    WindKPH = table.Column<float>(type: "real", nullable: true),
                    WindDegree = table.Column<float>(type: "real", nullable: true),
                    WindDirection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PressureMilibars = table.Column<float>(type: "real", nullable: true),
                    PressureHgInches = table.Column<float>(type: "real", nullable: true),
                    PrecipMillimetres = table.Column<float>(type: "real", nullable: true),
                    PrecipInches = table.Column<float>(type: "real", nullable: true),
                    Humidity = table.Column<float>(type: "real", nullable: true),
                    Cloud = table.Column<float>(type: "real", nullable: true),
                    FeelsLikeTemperatureCelsius = table.Column<float>(type: "real", nullable: true),
                    FeelsLikeTemperatureFahrenheit = table.Column<float>(type: "real", nullable: true),
                    WindChillCelsius = table.Column<float>(type: "real", nullable: true),
                    WindChillFahrenheit = table.Column<float>(type: "real", nullable: true),
                    HeatIndexCelsius = table.Column<float>(type: "real", nullable: true),
                    HeatIndexFahrenheit = table.Column<float>(type: "real", nullable: true),
                    DewpointCelsius = table.Column<float>(type: "real", nullable: true),
                    DewpointFahrenheit = table.Column<float>(type: "real", nullable: true),
                    VisibilityKilometers = table.Column<float>(type: "real", nullable: true),
                    VisibilityMiles = table.Column<float>(type: "real", nullable: true),
                    UVIndex = table.Column<float>(type: "real", nullable: true),
                    GustMPH = table.Column<float>(type: "real", nullable: true),
                    GustKPH = table.Column<float>(type: "real", nullable: true),
                    ConditionId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Current", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Current_Condition_ConditionId",
                        column: x => x.ConditionId,
                        principalTable: "Condition",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WeatherCurrent",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LocationId = table.Column<long>(type: "bigint", nullable: false),
                    CurrentId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherCurrent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeatherCurrent_AspNetUsers_AccountId",
                        column: x => x.AccountId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WeatherCurrent_Current_CurrentId",
                        column: x => x.CurrentId,
                        principalTable: "Current",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WeatherCurrent_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WeatherForecast",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LocationId = table.Column<long>(type: "bigint", nullable: false),
                    CurrentId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherForecast", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeatherForecast_AspNetUsers_AccountId",
                        column: x => x.AccountId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WeatherForecast_Current_CurrentId",
                        column: x => x.CurrentId,
                        principalTable: "Current",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WeatherForecast_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ForecastDay",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeatherForecastId = table.Column<long>(type: "bigint", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateEpoch = table.Column<long>(type: "bigint", nullable: true),
                    MaxTemperatureCelsius = table.Column<float>(type: "real", nullable: true),
                    MaxTemperatureFahrenheit = table.Column<float>(type: "real", nullable: true),
                    MinTemperatureCelsius = table.Column<float>(type: "real", nullable: true),
                    MinTemperatureFahrenheit = table.Column<float>(type: "real", nullable: true),
                    AvgTemperatureCelsius = table.Column<float>(type: "real", nullable: true),
                    AvgTemperatureFahrenheit = table.Column<float>(type: "real", nullable: true),
                    MaxWindMPH = table.Column<float>(type: "real", nullable: true),
                    MaxWindKPH = table.Column<float>(type: "real", nullable: true),
                    TotalPrecipMillimetres = table.Column<float>(type: "real", nullable: true),
                    TotalPrecipInches = table.Column<float>(type: "real", nullable: true),
                    TotalSnowCentimeters = table.Column<float>(type: "real", nullable: true),
                    AvgVisibilityKilometers = table.Column<float>(type: "real", nullable: true),
                    AvgVisibilityMiles = table.Column<float>(type: "real", nullable: true),
                    AvgHumidity = table.Column<int>(type: "int", nullable: true),
                    WillItRain = table.Column<bool>(type: "bit", nullable: false),
                    ChanceOfRain = table.Column<int>(type: "int", nullable: true),
                    WillItSnow = table.Column<bool>(type: "bit", nullable: false),
                    ChanceOfSnow = table.Column<int>(type: "int", nullable: true),
                    UVIndex = table.Column<float>(type: "real", nullable: true),
                    ConditionId = table.Column<long>(type: "bigint", nullable: false),
                    AstroId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForecastDay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForecastDay_Astro_AstroId",
                        column: x => x.AstroId,
                        principalTable: "Astro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ForecastDay_Condition_ConditionId",
                        column: x => x.ConditionId,
                        principalTable: "Condition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ForecastDay_WeatherForecast_WeatherForecastId",
                        column: x => x.WeatherForecastId,
                        principalTable: "WeatherForecast",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ForecastHour",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ForecastDayId = table.Column<long>(type: "bigint", nullable: false),
                    TimeEpoch = table.Column<long>(type: "bigint", nullable: true),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TemperatureCelsius = table.Column<float>(type: "real", nullable: true),
                    TemperatureFahrenheit = table.Column<float>(type: "real", nullable: true),
                    IsDay = table.Column<bool>(type: "bit", nullable: false),
                    WindMPH = table.Column<float>(type: "real", nullable: true),
                    WindKPH = table.Column<float>(type: "real", nullable: true),
                    WindDegree = table.Column<float>(type: "real", nullable: true),
                    WindDirection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PressureMilibars = table.Column<float>(type: "real", nullable: true),
                    PressureHgInches = table.Column<float>(type: "real", nullable: true),
                    PrecipMillimetres = table.Column<float>(type: "real", nullable: true),
                    PrecipInches = table.Column<float>(type: "real", nullable: true),
                    SnowCentimeters = table.Column<float>(type: "real", nullable: true),
                    Humidity = table.Column<float>(type: "real", nullable: true),
                    Cloud = table.Column<float>(type: "real", nullable: true),
                    FeelsLikeTemperatureCelsius = table.Column<float>(type: "real", nullable: true),
                    FeelsLikeTemperatureFahrenheit = table.Column<float>(type: "real", nullable: true),
                    WindChillCelsius = table.Column<float>(type: "real", nullable: true),
                    WindChillFahrenheit = table.Column<float>(type: "real", nullable: true),
                    HeatIndexCelsius = table.Column<float>(type: "real", nullable: true),
                    HeatIndexFahrenheit = table.Column<float>(type: "real", nullable: true),
                    DewpointCelsius = table.Column<float>(type: "real", nullable: true),
                    DewpointFahrenheit = table.Column<float>(type: "real", nullable: true),
                    WillItRain = table.Column<bool>(type: "bit", nullable: false),
                    ChanceOfRain = table.Column<int>(type: "int", nullable: true),
                    WillItSnow = table.Column<bool>(type: "bit", nullable: false),
                    ChanceOfSnow = table.Column<int>(type: "int", nullable: true),
                    VisibilityKilometers = table.Column<float>(type: "real", nullable: true),
                    VisibilityMiles = table.Column<float>(type: "real", nullable: true),
                    GustMPH = table.Column<float>(type: "real", nullable: true),
                    GustKPH = table.Column<float>(type: "real", nullable: true),
                    UVIndex = table.Column<float>(type: "real", nullable: true),
                    ConditionId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForecastHour", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForecastHour_Condition_ConditionId",
                        column: x => x.ConditionId,
                        principalTable: "Condition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ForecastHour_ForecastDay_ForecastDayId",
                        column: x => x.ForecastDayId,
                        principalTable: "ForecastDay",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Current_ConditionId",
                table: "Current",
                column: "ConditionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ForecastDay_AstroId",
                table: "ForecastDay",
                column: "AstroId");

            migrationBuilder.CreateIndex(
                name: "IX_ForecastDay_ConditionId",
                table: "ForecastDay",
                column: "ConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_ForecastDay_WeatherForecastId",
                table: "ForecastDay",
                column: "WeatherForecastId");

            migrationBuilder.CreateIndex(
                name: "IX_ForecastHour_ConditionId",
                table: "ForecastHour",
                column: "ConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_ForecastHour_ForecastDayId",
                table: "ForecastHour",
                column: "ForecastDayId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherCurrent_AccountId",
                table: "WeatherCurrent",
                column: "AccountId",
                unique: true,
                filter: "[AccountId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherCurrent_CurrentId",
                table: "WeatherCurrent",
                column: "CurrentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeatherCurrent_LocationId",
                table: "WeatherCurrent",
                column: "LocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeatherForecast_AccountId",
                table: "WeatherForecast",
                column: "AccountId",
                unique: true,
                filter: "[AccountId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherForecast_CurrentId",
                table: "WeatherForecast",
                column: "CurrentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeatherForecast_LocationId",
                table: "WeatherForecast",
                column: "LocationId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ForecastHour");

            migrationBuilder.DropTable(
                name: "WeatherCurrent");

            migrationBuilder.DropTable(
                name: "ForecastDay");

            migrationBuilder.DropTable(
                name: "Astro");

            migrationBuilder.DropTable(
                name: "WeatherForecast");

            migrationBuilder.DropTable(
                name: "Current");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Condition");
        }
    }
}
