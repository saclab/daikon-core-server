using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class projectTeamPP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TeamPriority",
                table: "Projects",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeamPriorityDescription",
                table: "Projects",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeamProbability",
                table: "Projects",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeamProbabilityDescription",
                table: "Projects",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeamPriority",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "TeamPriorityDescription",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "TeamProbability",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "TeamProbabilityDescription",
                table: "Projects");
        }
    }
}
