using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class GeneNonPublicDataEntityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeneNonPublicData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    GeneID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Classification = table.Column<string>(type: "TEXT", nullable: true),
                    EssentialityCondition = table.Column<string>(type: "TEXT", nullable: true),
                    Strain = table.Column<string>(type: "TEXT", nullable: true),
                    Method = table.Column<string>(type: "TEXT", nullable: true),
                    Reference = table.Column<string>(type: "TEXT", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    ProteinProduction = table.Column<string>(type: "TEXT", nullable: true),
                    ProteinActivityAssay = table.Column<string>(type: "TEXT", nullable: true),
                    KnockdownStrain = table.Column<string>(type: "TEXT", nullable: true),
                    Phenotype = table.Column<string>(type: "TEXT", nullable: true),
                    CRISPRiStrain = table.Column<string>(type: "TEXT", nullable: true),
                    Mutation = table.Column<string>(type: "TEXT", nullable: true),
                    Isolate = table.Column<string>(type: "TEXT", nullable: true),
                    ParentStrain = table.Column<string>(type: "TEXT", nullable: true),
                    CompoundSmiles = table.Column<string>(type: "TEXT", nullable: true),
                    ShiftInMIC = table.Column<string>(type: "TEXT", nullable: true),
                    Lab = table.Column<string>(type: "TEXT", nullable: true),
                    Rank = table.Column<string>(type: "TEXT", nullable: true),
                    U_Vi = table.Column<string>(type: "TEXT", nullable: true),
                    I_Vi = table.Column<string>(type: "TEXT", nullable: true),
                    Vi_Ratio = table.Column<string>(type: "TEXT", nullable: true),
                    VulnerabilityCondition = table.Column<string>(type: "TEXT", nullable: true),
                    Operon = table.Column<string>(type: "TEXT", nullable: true),
                    Confounded = table.Column<string>(type: "TEXT", nullable: true),
                    Shell_2015Operon = table.Column<string>(type: "TEXT", nullable: true),
                    Organization = table.Column<string>(type: "TEXT", nullable: true),
                    UnpublishedMethod = table.Column<string>(type: "TEXT", nullable: true),
                    Resolution = table.Column<string>(type: "TEXT", nullable: true),
                    UnpublishedCondition = table.Column<string>(type: "TEXT", nullable: true),
                    Ligand = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneNonPublicData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneNonPublicData_Genes_GeneID",
                        column: x => x.GeneID,
                        principalTable: "Genes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GeneNonPublicData_GeneID",
                table: "GeneNonPublicData",
                column: "GeneID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneNonPublicData");
        }
    }
}
