using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class droppedgenebacklink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneNonPublicData_Genes_GeneID",
                table: "GeneNonPublicData");

            migrationBuilder.DropForeignKey(
                name: "FK_GenePublicData_Genes_GeneID",
                table: "GenePublicData");

            migrationBuilder.RenameColumn(
                name: "GeneID",
                table: "GenePublicData",
                newName: "GeneId");

            migrationBuilder.RenameIndex(
                name: "IX_GenePublicData_GeneID",
                table: "GenePublicData",
                newName: "IX_GenePublicData_GeneId");

            migrationBuilder.RenameColumn(
                name: "GeneID",
                table: "GeneNonPublicData",
                newName: "GeneId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneNonPublicData_GeneID",
                table: "GeneNonPublicData",
                newName: "IX_GeneNonPublicData_GeneId");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneNonPublicData_Genes_GeneId",
                table: "GeneNonPublicData",
                column: "GeneId",
                principalTable: "Genes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenePublicData_Genes_GeneId",
                table: "GenePublicData",
                column: "GeneId",
                principalTable: "Genes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneNonPublicData_Genes_GeneId",
                table: "GeneNonPublicData");

            migrationBuilder.DropForeignKey(
                name: "FK_GenePublicData_Genes_GeneId",
                table: "GenePublicData");

            migrationBuilder.RenameColumn(
                name: "GeneId",
                table: "GenePublicData",
                newName: "GeneID");

            migrationBuilder.RenameIndex(
                name: "IX_GenePublicData_GeneId",
                table: "GenePublicData",
                newName: "IX_GenePublicData_GeneID");

            migrationBuilder.RenameColumn(
                name: "GeneId",
                table: "GeneNonPublicData",
                newName: "GeneID");

            migrationBuilder.RenameIndex(
                name: "IX_GeneNonPublicData_GeneId",
                table: "GeneNonPublicData",
                newName: "IX_GeneNonPublicData_GeneID");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneNonPublicData_Genes_GeneID",
                table: "GeneNonPublicData",
                column: "GeneID",
                principalTable: "Genes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenePublicData_Genes_GeneID",
                table: "GenePublicData",
                column: "GeneID",
                principalTable: "Genes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
