using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class GeneSequenceAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GeneSequence",
                table: "GenePublicData",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProteinSequence",
                table: "GenePublicData",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GeneSequence",
                table: "GenePublicData");

            migrationBuilder.DropColumn(
                name: "ProteinSequence",
                table: "GenePublicData");
        }
    }
}
