using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class projectsdescs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FHADescription",
                table: "Projects",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "H2LDescription",
                table: "Projects",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "INDDescription",
                table: "Projects",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LODescription",
                table: "Projects",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "P1Description",
                table: "Projects",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PCDDescription",
                table: "Projects",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SPCDescription",
                table: "Projects",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FHADescription",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "H2LDescription",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "INDDescription",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "LODescription",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "P1Description",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "PCDDescription",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "SPCDescription",
                table: "Projects");
        }
    }
}
