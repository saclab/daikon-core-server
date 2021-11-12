using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class dropped_gene_nonpublic_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneNonPublicData");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeneNonPublicData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CRISPRiStrain = table.Column<string>(type: "text", nullable: true),
                    CompoundSmiles = table.Column<string>(type: "text", nullable: true),
                    GeneAccessionNumber = table.Column<string>(type: "text", nullable: true),
                    GeneId = table.Column<Guid>(type: "uuid", nullable: false),
                    Isolate = table.Column<string>(type: "text", nullable: true),
                    KnockdownStrain = table.Column<string>(type: "text", nullable: true),
                    Lab = table.Column<string>(type: "text", nullable: true),
                    Ligand = table.Column<string>(type: "text", nullable: true),
                    Mutation = table.Column<string>(type: "text", nullable: true),
                    Organization = table.Column<string>(type: "text", nullable: true),
                    ParentStrain = table.Column<string>(type: "text", nullable: true),
                    Phenotype = table.Column<string>(type: "text", nullable: true),
                    ProteinActivityAssay = table.Column<string>(type: "text", nullable: true),
                    ProteinProduction = table.Column<string>(type: "text", nullable: true),
                    Resolution = table.Column<string>(type: "text", nullable: true),
                    ShiftInMIC = table.Column<string>(type: "text", nullable: true),
                    UnpublishedCondition = table.Column<string>(type: "text", nullable: true),
                    UnpublishedMethod = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneNonPublicData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneNonPublicData_Genes_GeneId",
                        column: x => x.GeneId,
                        principalTable: "Genes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GeneNonPublicData_GeneId",
                table: "GeneNonPublicData",
                column: "GeneId",
                unique: true);
        }
    }
}
