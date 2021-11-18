using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class geneHypomorph : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeneHypomorphs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GeneId = table.Column<Guid>(type: "uuid", nullable: false),
                    GeneAccessionNumber = table.Column<string>(type: "text", nullable: true),
                    KnockdownStrain = table.Column<string>(type: "text", nullable: true),
                    Phenotype = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneHypomorphs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneHypomorphs_Genes_GeneId",
                        column: x => x.GeneId,
                        principalTable: "Genes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GeneHypomorphs_GeneId",
                table: "GeneHypomorphs",
                column: "GeneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneHypomorphs");
        }
    }
}
