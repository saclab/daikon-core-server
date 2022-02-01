using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class redesigngenes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GeneIds",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "GeneIds",
                table: "GenePromotionRequests");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<List<Guid>>(
                name: "GeneIds",
                table: "Targets",
                type: "uuid[]",
                nullable: true);

            migrationBuilder.AddColumn<List<Guid>>(
                name: "GeneIds",
                table: "GenePromotionRequests",
                type: "uuid[]",
                nullable: true);
        }
    }
}
