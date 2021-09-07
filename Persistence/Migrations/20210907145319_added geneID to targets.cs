using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class addedgeneIDtotargets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Targets_Genes_BaseGeneId",
                table: "Targets");

            migrationBuilder.DropIndex(
                name: "IX_Targets_BaseGeneId",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "BaseGeneId",
                table: "Targets");

            migrationBuilder.AddColumn<Guid>(
                name: "GeneId",
                table: "Targets",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Targets_GeneId",
                table: "Targets",
                column: "GeneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Targets_Genes_GeneId",
                table: "Targets",
                column: "GeneId",
                principalTable: "Genes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Targets_Genes_GeneId",
                table: "Targets");

            migrationBuilder.DropIndex(
                name: "IX_Targets_GeneId",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "GeneId",
                table: "Targets");

            migrationBuilder.AddColumn<Guid>(
                name: "BaseGeneId",
                table: "Targets",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Targets_BaseGeneId",
                table: "Targets",
                column: "BaseGeneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Targets_Genes_BaseGeneId",
                table: "Targets",
                column: "BaseGeneId",
                principalTable: "Genes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
