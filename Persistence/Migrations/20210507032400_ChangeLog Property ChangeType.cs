using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class ChangeLogPropertyChangeType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GenePublicData_GeneID",
                table: "GenePublicData");

            migrationBuilder.DropIndex(
                name: "IX_GeneNonPublicData_GeneID",
                table: "GeneNonPublicData");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "ChangeLogs",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GenePublicData_GeneID",
                table: "GenePublicData",
                column: "GeneID");

            migrationBuilder.CreateIndex(
                name: "IX_GeneNonPublicData_GeneID",
                table: "GeneNonPublicData",
                column: "GeneID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GenePublicData_GeneID",
                table: "GenePublicData");

            migrationBuilder.DropIndex(
                name: "IX_GeneNonPublicData_GeneID",
                table: "GeneNonPublicData");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "ChangeLogs");

            migrationBuilder.CreateIndex(
                name: "IX_GenePublicData_GeneID",
                table: "GenePublicData",
                column: "GeneID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GeneNonPublicData_GeneID",
                table: "GeneNonPublicData",
                column: "GeneID",
                unique: true);
        }
    }
}
