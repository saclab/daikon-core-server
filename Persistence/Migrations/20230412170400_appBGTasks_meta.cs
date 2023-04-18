using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class appBGTasks_meta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppBackgroundTasks");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AppConfigurations",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "AppConfigurations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "AppConfigurations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "AppConfigurations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AppConfigurations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "AppConfigurations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "AppConfigurations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "AppConfigurations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExpired",
                table: "AppConfigurations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "AppConfigurations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "AppConfigurations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPending",
                table: "AppConfigurations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "AppConfigurations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "AppConfigurations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "AppConfigurations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReadOnly",
                table: "AppConfigurations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "AppConfigurations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditAt",
                table: "AppConfigurations",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastEditBy",
                table: "AppConfigurations",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppBackgroundTasksLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TaskName = table.Column<string>(type: "text", nullable: true),
                    TaskConfigurationKey = table.Column<string>(type: "text", nullable: true),
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
                    TaskCreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastEditAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastEditBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    IsPublished = table.Column<bool>(type: "boolean", nullable: false),
                    IsDraft = table.Column<bool>(type: "boolean", nullable: false),
                    IsPrivate = table.Column<bool>(type: "boolean", nullable: false),
                    IsPublic = table.Column<bool>(type: "boolean", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "boolean", nullable: false),
                    IsLocked = table.Column<bool>(type: "boolean", nullable: false),
                    IsHidden = table.Column<bool>(type: "boolean", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    IsDisabled = table.Column<bool>(type: "boolean", nullable: false),
                    IsApproved = table.Column<bool>(type: "boolean", nullable: false),
                    IsRejected = table.Column<bool>(type: "boolean", nullable: false),
                    IsPending = table.Column<bool>(type: "boolean", nullable: false),
                    IsExpired = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppBackgroundTasksLog", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppBackgroundTasksLog");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AppConfigurations");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AppConfigurations");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "AppConfigurations");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "AppConfigurations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AppConfigurations");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "AppConfigurations");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "AppConfigurations");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "AppConfigurations");

            migrationBuilder.DropColumn(
                name: "IsExpired",
                table: "AppConfigurations");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "AppConfigurations");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "AppConfigurations");

            migrationBuilder.DropColumn(
                name: "IsPending",
                table: "AppConfigurations");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "AppConfigurations");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "AppConfigurations");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "AppConfigurations");

            migrationBuilder.DropColumn(
                name: "IsReadOnly",
                table: "AppConfigurations");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "AppConfigurations");

            migrationBuilder.DropColumn(
                name: "LastEditAt",
                table: "AppConfigurations");

            migrationBuilder.DropColumn(
                name: "LastEditBy",
                table: "AppConfigurations");

            migrationBuilder.CreateTable(
                name: "AppBackgroundTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TaskCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TaskCreatedBy = table.Column<string>(type: "text", nullable: true),
                    TaskDescription = table.Column<string>(type: "text", nullable: true),
                    TaskEndTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TaskLastUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TaskModule = table.Column<string>(type: "text", nullable: true),
                    TaskName = table.Column<string>(type: "text", nullable: true),
                    TaskResult = table.Column<string>(type: "text", nullable: true),
                    TaskResultData = table.Column<string>(type: "text", nullable: true),
                    TaskResultMessage = table.Column<string>(type: "text", nullable: true),
                    TaskStartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TaskStatus = table.Column<string>(type: "text", nullable: true),
                    TaskSubModule = table.Column<string>(type: "text", nullable: true),
                    TaskType = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppBackgroundTasks", x => x.Id);
                });
        }
    }
}
