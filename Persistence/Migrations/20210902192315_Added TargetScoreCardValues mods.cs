using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddedTargetScoreCardValuesmods : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TargetScorecards_Questions_QuestionId",
                table: "TargetScorecards");

            migrationBuilder.DropIndex(
                name: "IX_TargetScorecards_QuestionId",
                table: "TargetScorecards");

            migrationBuilder.DropColumn(
                name: "Answer",
                table: "TargetScorecards");

            migrationBuilder.DropColumn(
                name: "AnswerdBy",
                table: "TargetScorecards");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "TargetScorecards");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "TargetScorecards");

            migrationBuilder.DropColumn(
                name: "QuestionIdentification",
                table: "TargetScorecards");

            migrationBuilder.DropColumn(
                name: "QuestionModule",
                table: "TargetScorecards");

            migrationBuilder.DropColumn(
                name: "QuestionSubModule",
                table: "TargetScorecards");

            migrationBuilder.RenameColumn(
                name: "TargetID",
                table: "TargetScoreCardValues",
                newName: "TargetScorecardId");

            migrationBuilder.CreateIndex(
                name: "IX_TargetScoreCardValues_TargetScorecardId",
                table: "TargetScoreCardValues",
                column: "TargetScorecardId");

            migrationBuilder.AddForeignKey(
                name: "FK_TargetScoreCardValues_TargetScorecards_TargetScorecardId",
                table: "TargetScoreCardValues",
                column: "TargetScorecardId",
                principalTable: "TargetScorecards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TargetScoreCardValues_TargetScorecards_TargetScorecardId",
                table: "TargetScoreCardValues");

            migrationBuilder.DropIndex(
                name: "IX_TargetScoreCardValues_TargetScorecardId",
                table: "TargetScoreCardValues");

            migrationBuilder.RenameColumn(
                name: "TargetScorecardId",
                table: "TargetScoreCardValues",
                newName: "TargetID");

            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "TargetScorecards",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AnswerdBy",
                table: "TargetScorecards",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TargetScorecards",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "QuestionId",
                table: "TargetScorecards",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "QuestionIdentification",
                table: "TargetScorecards",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuestionModule",
                table: "TargetScorecards",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuestionSubModule",
                table: "TargetScorecards",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TargetScorecards_QuestionId",
                table: "TargetScorecards",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_TargetScorecards_Questions_QuestionId",
                table: "TargetScorecards",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
