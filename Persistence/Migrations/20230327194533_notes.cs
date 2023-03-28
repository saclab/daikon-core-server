using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class notes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "GeneVulnerability",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "GeneUnpublishedStructures",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "GeneResistanceMutations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "GeneProteinProductions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "GeneHypomorphs",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "GeneCRISPRiStrains",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "GeneVulnerability");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "GeneUnpublishedStructures");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "GeneResistanceMutations");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "GeneProteinProductions");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "GeneHypomorphs");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "GeneCRISPRiStrains");
        }
    }
}
