using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class projectAnticipatedDates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "P1Start",
                table: "Projects",
                newName: "SPPredictedStart");

            migrationBuilder.RenameColumn(
                name: "P1Enabled",
                table: "Projects",
                newName: "ClinicalP1Enabled");

            migrationBuilder.RenameColumn(
                name: "P1Description",
                table: "Projects",
                newName: "ClinicalP1Description");

            migrationBuilder.AddColumn<DateTime>(
                name: "ClinicalP1PredictedStart",
                table: "Projects",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ClinicalP1Start",
                table: "Projects",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FHAPredictedStart",
                table: "Projects",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "H2LPredictedStart",
                table: "Projects",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "INDPredictedStart",
                table: "Projects",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LOPredictedStart",
                table: "Projects",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClinicalP1PredictedStart",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ClinicalP1Start",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "FHAPredictedStart",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "H2LPredictedStart",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "INDPredictedStart",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "LOPredictedStart",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "SPPredictedStart",
                table: "Projects",
                newName: "P1Start");

            migrationBuilder.RenameColumn(
                name: "ClinicalP1Enabled",
                table: "Projects",
                newName: "P1Enabled");

            migrationBuilder.RenameColumn(
                name: "ClinicalP1Description",
                table: "Projects",
                newName: "P1Description");
        }
    }
}
