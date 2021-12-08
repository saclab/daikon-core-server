using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class projectsstageenable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SPCDescription",
                table: "Projects",
                newName: "SPDescription");

            migrationBuilder.AddColumn<bool>(
                name: "FHAEnabled",
                table: "Projects",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "H2LEnabled",
                table: "Projects",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "INDEnabled",
                table: "Projects",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LOEnabled",
                table: "Projects",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "P1Enabled",
                table: "Projects",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PCDEnabled",
                table: "Projects",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SPEnabled",
                table: "Projects",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FHAEnabled",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "H2LEnabled",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "INDEnabled",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "LOEnabled",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "P1Enabled",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "PCDEnabled",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "SPEnabled",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "SPDescription",
                table: "Projects",
                newName: "SPCDescription");
        }
    }
}
