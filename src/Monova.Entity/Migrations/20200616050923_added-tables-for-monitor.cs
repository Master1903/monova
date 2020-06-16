using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Monova.Entity.Migrations
{
    public partial class addedtablesformonitor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Monitor",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    MonitorStatus = table.Column<short>(nullable: false),
                    TestStatus = table.Column<short>(nullable: false),
                    LastCheckDate = table.Column<DateTime>(nullable: false),
                    UpTime = table.Column<decimal>(nullable: false),
                    LoadTime = table.Column<int>(nullable: false),
                    MonitorTime = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monitor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MonitorStep",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MonitorId = table.Column<Guid>(nullable: false),
                    Type = table.Column<short>(nullable: false),
                    Settings = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonitorStep", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MonitorStepLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MonitorStepId = table.Column<Guid>(nullable: false),
                    MonitorId = table.Column<Guid>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<short>(nullable: false),
                    Log = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonitorStepLog", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Monitor");

            migrationBuilder.DropTable(
                name: "MonitorStep");

            migrationBuilder.DropTable(
                name: "MonitorStepLog");
        }
    }
}
