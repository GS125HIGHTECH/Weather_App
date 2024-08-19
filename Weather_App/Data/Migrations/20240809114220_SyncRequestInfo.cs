using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Weather_App.Data.Migrations
{
    public partial class SyncRequestInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SyncRequestInfo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExecutionTime = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    BaseEntity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AdditionalEntities = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ApiName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BaseAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EndPoint = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Parameters = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    When = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GlobalCount = table.Column<int>(type: "int", nullable: false),
                    Reconnections = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: true),
                    AdditionalInformations = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: true),
                    ProcessingDetails = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SyncRequestInfo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SyncRequestInfo");
        }
    }
}
