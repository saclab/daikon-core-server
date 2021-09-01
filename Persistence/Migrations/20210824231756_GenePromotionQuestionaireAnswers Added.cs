using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class GenePromotionQuestionaireAnswersAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenePromotionQuestionaire");

            migrationBuilder.CreateTable(
                name: "GenePromotionQuestionaireAnswers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    GeneID = table.Column<Guid>(type: "TEXT", nullable: false),
                    GeneAccessionNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: true),
                    QuestionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    QuestionIdentification = table.Column<string>(type: "TEXT", nullable: true),
                    QuestionModule = table.Column<string>(type: "TEXT", nullable: true),
                    Answer = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    AnswerdBy = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenePromotionQuestionaireAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenePromotionQuestionaireAnswers_Genes_GeneID",
                        column: x => x.GeneID,
                        principalTable: "Genes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenePromotionQuestionaireAnswers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenePromotionQuestionaireAnswers_GeneID",
                table: "GenePromotionQuestionaireAnswers",
                column: "GeneID");

            migrationBuilder.CreateIndex(
                name: "IX_GenePromotionQuestionaireAnswers_QuestionId",
                table: "GenePromotionQuestionaireAnswers",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenePromotionQuestionaireAnswers");

            migrationBuilder.CreateTable(
                name: "GenePromotionQuestionaire",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Answer = table.Column<string>(type: "TEXT", nullable: true),
                    AnswerdBy = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    GeneAccessionNumber = table.Column<Guid>(type: "TEXT", nullable: false),
                    GeneID = table.Column<Guid>(type: "TEXT", nullable: false),
                    QuestionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    QuestionIdentification = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenePromotionQuestionaire", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenePromotionQuestionaire_Genes_GeneID",
                        column: x => x.GeneID,
                        principalTable: "Genes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenePromotionQuestionaire_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenePromotionQuestionaire_GeneID",
                table: "GenePromotionQuestionaire",
                column: "GeneID");

            migrationBuilder.CreateIndex(
                name: "IX_GenePromotionQuestionaire_QuestionId",
                table: "GenePromotionQuestionaire",
                column: "QuestionId");
        }
    }
}
