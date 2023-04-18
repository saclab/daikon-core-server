using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class strains_ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StrainId",
                table: "GenePromotionRequests",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Genes_StrainId",
                table: "Genes",
                column: "StrainId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genes_Strains_StrainId",
                table: "Genes",
                column: "StrainId",
                principalTable: "Strains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genes_Strains_StrainId",
                table: "Genes");

            migrationBuilder.DropIndex(
                name: "IX_Genes_StrainId",
                table: "Genes");

            migrationBuilder.DropColumn(
                name: "StrainId",
                table: "GenePromotionRequests");
        }
    }
}
