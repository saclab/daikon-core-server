using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class RelationsDefined : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_GenePromotionRequestValues_QuestionId",
                table: "GenePromotionRequestValues",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_GenePromotionRequests_GeneId",
                table: "GenePromotionRequests",
                column: "GeneId");

            migrationBuilder.AddForeignKey(
                name: "FK_GenePromotionRequests_Genes_GeneId",
                table: "GenePromotionRequests",
                column: "GeneId",
                principalTable: "Genes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenePromotionRequestValues_Questions_QuestionId",
                table: "GenePromotionRequestValues",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenePromotionRequests_Genes_GeneId",
                table: "GenePromotionRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_GenePromotionRequestValues_Questions_QuestionId",
                table: "GenePromotionRequestValues");

            migrationBuilder.DropIndex(
                name: "IX_GenePromotionRequestValues_QuestionId",
                table: "GenePromotionRequestValues");

            migrationBuilder.DropIndex(
                name: "IX_GenePromotionRequests_GeneId",
                table: "GenePromotionRequests");
        }
    }
}
