using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class redesigngenes1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genes_GenePromotionRequests_GenePromotionRequestId",
                table: "Genes");

            migrationBuilder.DropForeignKey(
                name: "FK_Genes_Targets_TargetId",
                table: "Genes");

            migrationBuilder.DropIndex(
                name: "IX_Genes_GenePromotionRequestId",
                table: "Genes");

            migrationBuilder.DropIndex(
                name: "IX_Genes_TargetId",
                table: "Genes");

            migrationBuilder.DropColumn(
                name: "GenePromotionRequestId",
                table: "Genes");

            migrationBuilder.DropColumn(
                name: "TargetId",
                table: "Genes");

            migrationBuilder.CreateTable(
                name: "GenePromtionRequestGenes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GenePromotionRequestId = table.Column<Guid>(type: "uuid", nullable: false),
                    GeneId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenePromtionRequestGenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenePromtionRequestGenes_GenePromotionRequests_GenePromotio~",
                        column: x => x.GenePromotionRequestId,
                        principalTable: "GenePromotionRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TargetGenes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TargetId = table.Column<Guid>(type: "uuid", nullable: false),
                    GeneId = table.Column<Guid>(type: "uuid", nullable: false),
                    StrainId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TargetGenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TargetGenes_Genes_GeneId",
                        column: x => x.GeneId,
                        principalTable: "Genes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TargetGenes_Targets_TargetId",
                        column: x => x.TargetId,
                        principalTable: "Targets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenePromtionRequestGenes_GenePromotionRequestId",
                table: "GenePromtionRequestGenes",
                column: "GenePromotionRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_TargetGenes_GeneId",
                table: "TargetGenes",
                column: "GeneId");

            migrationBuilder.CreateIndex(
                name: "IX_TargetGenes_TargetId",
                table: "TargetGenes",
                column: "TargetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenePromtionRequestGenes");

            migrationBuilder.DropTable(
                name: "TargetGenes");

            migrationBuilder.AddColumn<Guid>(
                name: "GenePromotionRequestId",
                table: "Genes",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TargetId",
                table: "Genes",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genes_GenePromotionRequestId",
                table: "Genes",
                column: "GenePromotionRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Genes_TargetId",
                table: "Genes",
                column: "TargetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genes_GenePromotionRequests_GenePromotionRequestId",
                table: "Genes",
                column: "GenePromotionRequestId",
                principalTable: "GenePromotionRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Genes_Targets_TargetId",
                table: "Genes",
                column: "TargetId",
                principalTable: "Targets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
