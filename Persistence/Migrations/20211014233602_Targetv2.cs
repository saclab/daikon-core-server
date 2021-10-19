using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class Targetv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ImpactComplete",
                table: "Targets",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "LikeComplete",
                table: "Targets",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ScreeningComplete",
                table: "Targets",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ScreeningScore",
                table: "Targets",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "StructureComplete",
                table: "Targets",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "StructureScore",
                table: "Targets",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "VulnerabilityRank",
                table: "Targets",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "VulnerabilityRatio",
                table: "Targets",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImpactComplete",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "LikeComplete",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "ScreeningComplete",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "ScreeningScore",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "StructureComplete",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "StructureScore",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "VulnerabilityRank",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "VulnerabilityRatio",
                table: "Targets");
        }
    }
}
