using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class TargetSummary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Background",
                table: "Targets",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Challenges",
                table: "Targets",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Enablement",
                table: "Targets",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Strategy",
                table: "Targets",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Background",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "Challenges",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "Enablement",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "Strategy",
                table: "Targets");
        }
    }
}
