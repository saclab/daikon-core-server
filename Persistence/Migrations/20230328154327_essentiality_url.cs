using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class essentiality_url : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "URL",
                table: "GeneVulnerability",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "URL",
                table: "GeneEssentiality",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "URL",
                table: "GeneVulnerability");

            migrationBuilder.DropColumn(
                name: "URL",
                table: "GeneEssentiality");
        }
    }
}
