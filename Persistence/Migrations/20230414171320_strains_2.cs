using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class strains_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Targets_Name",
                table: "Targets");

            migrationBuilder.CreateIndex(
                name: "IX_Targets_StrainId",
                table: "Targets",
                column: "StrainId");

            migrationBuilder.CreateIndex(
                name: "IX_Screens_StrainId",
                table: "Screens",
                column: "StrainId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_StrainId",
                table: "Projects",
                column: "StrainId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Strains_StrainId",
                table: "Projects",
                column: "StrainId",
                principalTable: "Strains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Screens_Strains_StrainId",
                table: "Screens",
                column: "StrainId",
                principalTable: "Strains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Targets_Strains_StrainId",
                table: "Targets",
                column: "StrainId",
                principalTable: "Strains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Strains_StrainId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Screens_Strains_StrainId",
                table: "Screens");

            migrationBuilder.DropForeignKey(
                name: "FK_Targets_Strains_StrainId",
                table: "Targets");

            migrationBuilder.DropIndex(
                name: "IX_Targets_StrainId",
                table: "Targets");

            migrationBuilder.DropIndex(
                name: "IX_Screens_StrainId",
                table: "Screens");

            migrationBuilder.DropIndex(
                name: "IX_Projects_StrainId",
                table: "Projects");

            migrationBuilder.CreateIndex(
                name: "IX_Targets_Name",
                table: "Targets",
                column: "Name",
                unique: true);
        }
    }
}
