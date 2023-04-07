using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class appBGTasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppBackgroundTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TaskName = table.Column<string>(type: "text", nullable: true),
                    TaskDescription = table.Column<string>(type: "text", nullable: true),
                    TaskStatus = table.Column<string>(type: "text", nullable: true),
                    TaskType = table.Column<string>(type: "text", nullable: true),
                    TaskModule = table.Column<string>(type: "text", nullable: true),
                    TaskSubModule = table.Column<string>(type: "text", nullable: true),
                    TaskResult = table.Column<string>(type: "text", nullable: true),
                    TaskResultMessage = table.Column<string>(type: "text", nullable: true),
                    TaskResultData = table.Column<string>(type: "text", nullable: true),
                    TaskStartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TaskEndTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TaskLastUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TaskCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TaskCreatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppBackgroundTasks", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppBackgroundTasks");
        }
    }
}
