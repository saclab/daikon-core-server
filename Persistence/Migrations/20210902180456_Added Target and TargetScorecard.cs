using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddedTargetandTargetScorecard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Targets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AccessionNumber = table.Column<string>(type: "TEXT", nullable: true),
                    GeneName = table.Column<string>(type: "TEXT", nullable: true),
                    BaseGeneId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Score = table.Column<double>(type: "REAL", nullable: false),
                    HTSFeasibility = table.Column<double>(type: "REAL", nullable: false),
                    SBDFeasibility = table.Column<double>(type: "REAL", nullable: false),
                    Progressibility = table.Column<double>(type: "REAL", nullable: false),
                    Saftey = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Targets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Targets_Genes_BaseGeneId",
                        column: x => x.BaseGeneId,
                        principalTable: "Genes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TargetScorecards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TargetID = table.Column<Guid>(type: "TEXT", nullable: false),
                    TargetAccessionNumber = table.Column<string>(type: "TEXT", nullable: true),
                    QuestionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    QuestionIdentification = table.Column<string>(type: "TEXT", nullable: true),
                    QuestionModule = table.Column<string>(type: "TEXT", nullable: true),
                    QuestionSubModule = table.Column<string>(type: "TEXT", nullable: true),
                    Answer = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    AnswerdBy = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TargetScorecards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TargetScorecards_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TargetScorecards_Targets_TargetID",
                        column: x => x.TargetID,
                        principalTable: "Targets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Targets_BaseGeneId",
                table: "Targets",
                column: "BaseGeneId");

            migrationBuilder.CreateIndex(
                name: "IX_TargetScorecards_QuestionId",
                table: "TargetScorecards",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_TargetScorecards_TargetID",
                table: "TargetScorecards",
                column: "TargetID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TargetScorecards");

            migrationBuilder.DropTable(
                name: "Targets");
        }
    }
}
