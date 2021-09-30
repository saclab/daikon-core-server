using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class GenePromotionRecreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenePromotionRequests_Genes_GeneID",
                table: "GenePromotionRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_GenePromotionRequests_Questions_QuestionId",
                table: "GenePromotionRequests");

            migrationBuilder.DropIndex(
                name: "IX_GenePromotionRequests_GeneID",
                table: "GenePromotionRequests");

            migrationBuilder.DropIndex(
                name: "IX_GenePromotionRequests_QuestionId",
                table: "GenePromotionRequests");

            migrationBuilder.DropColumn(
                name: "Answer",
                table: "GenePromotionRequests");

            migrationBuilder.DropColumn(
                name: "AnswerdBy",
                table: "GenePromotionRequests");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "GenePromotionRequests");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "GenePromotionRequests");

            migrationBuilder.DropColumn(
                name: "QuestionIdentification",
                table: "GenePromotionRequests");

            migrationBuilder.DropColumn(
                name: "QuestionModule",
                table: "GenePromotionRequests");

            migrationBuilder.DropColumn(
                name: "QuestionSubModule",
                table: "GenePromotionRequests");

            migrationBuilder.RenameColumn(
                name: "GeneID",
                table: "GenePromotionRequests",
                newName: "GeneId");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "GenePromotionRequests",
                newName: "GenePromotionRequestStatus");

            migrationBuilder.CreateTable(
                name: "GenePromotionRequestValues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    GenePromotionRequestId = table.Column<Guid>(type: "TEXT", nullable: false),
                    QuestionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Answer = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    AnswerdBy = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenePromotionRequestValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenePromotionRequestValues_GenePromotionRequests_GenePromotionRequestId",
                        column: x => x.GenePromotionRequestId,
                        principalTable: "GenePromotionRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenePromotionRequestValues_GenePromotionRequestId",
                table: "GenePromotionRequestValues",
                column: "GenePromotionRequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenePromotionRequestValues");

            migrationBuilder.RenameColumn(
                name: "GeneId",
                table: "GenePromotionRequests",
                newName: "GeneID");

            migrationBuilder.RenameColumn(
                name: "GenePromotionRequestStatus",
                table: "GenePromotionRequests",
                newName: "Status");

            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "GenePromotionRequests",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AnswerdBy",
                table: "GenePromotionRequests",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "GenePromotionRequests",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "QuestionId",
                table: "GenePromotionRequests",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "QuestionIdentification",
                table: "GenePromotionRequests",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuestionModule",
                table: "GenePromotionRequests",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuestionSubModule",
                table: "GenePromotionRequests",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GenePromotionRequests_GeneID",
                table: "GenePromotionRequests",
                column: "GeneID");

            migrationBuilder.CreateIndex(
                name: "IX_GenePromotionRequests_QuestionId",
                table: "GenePromotionRequests",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_GenePromotionRequests_Genes_GeneID",
                table: "GenePromotionRequests",
                column: "GeneID",
                principalTable: "Genes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenePromotionRequests_Questions_QuestionId",
                table: "GenePromotionRequests",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
