using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddedTarget_TargetScorecardreference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TargetScorecards_TargetID",
                table: "TargetScorecards");

            migrationBuilder.CreateIndex(
                name: "IX_TargetScorecards_TargetID",
                table: "TargetScorecards",
                column: "TargetID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TargetScorecards_TargetID",
                table: "TargetScorecards");

            migrationBuilder.CreateIndex(
                name: "IX_TargetScorecards_TargetID",
                table: "TargetScorecards",
                column: "TargetID");
        }
    }
}
