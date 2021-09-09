using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class addeduniqueconstraintstoTargetcolumnGeneID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Targets_GeneId",
                table: "Targets");

            migrationBuilder.CreateIndex(
                name: "IX_Targets_GeneId",
                table: "Targets",
                column: "GeneId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Targets_GeneId",
                table: "Targets");

            migrationBuilder.CreateIndex(
                name: "IX_Targets_GeneId",
                table: "Targets",
                column: "GeneId");
        }
    }
}
