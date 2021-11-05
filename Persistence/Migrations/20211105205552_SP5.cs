using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class SP5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeneCRISPRiStrains",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GeneId = table.Column<Guid>(type: "uuid", nullable: false),
                    GeneAccessionNumber = table.Column<string>(type: "text", nullable: true),
                    CRISPRiStrain = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneCRISPRiStrains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneCRISPRiStrains_Genes_GeneId",
                        column: x => x.GeneId,
                        principalTable: "Genes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeneProteinActivityAssays",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GeneId = table.Column<Guid>(type: "uuid", nullable: false),
                    GeneAccessionNumber = table.Column<string>(type: "text", nullable: true),
                    ProteinActivityAssay = table.Column<string>(type: "text", nullable: true),
                    AssayType = table.Column<string>(type: "text", nullable: true),
                    AssayThroughput = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneProteinActivityAssays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneProteinActivityAssays_Genes_GeneId",
                        column: x => x.GeneId,
                        principalTable: "Genes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeneProteinProductions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GeneId = table.Column<Guid>(type: "uuid", nullable: false),
                    GeneAccessionNumber = table.Column<string>(type: "text", nullable: true),
                    ProteinProduction = table.Column<string>(type: "text", nullable: true),
                    Quantity = table.Column<string>(type: "text", nullable: true),
                    Purity = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneProteinProductions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneProteinProductions_Genes_GeneId",
                        column: x => x.GeneId,
                        principalTable: "Genes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeneResistanceMutations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GeneId = table.Column<Guid>(type: "uuid", nullable: false),
                    GeneAccessionNumber = table.Column<string>(type: "text", nullable: true),
                    Mutation = table.Column<string>(type: "text", nullable: true),
                    Isolate = table.Column<string>(type: "text", nullable: true),
                    ParentStrain = table.Column<string>(type: "text", nullable: true),
                    Compound = table.Column<string>(type: "text", nullable: true),
                    ShiftInMIC = table.Column<string>(type: "text", nullable: true),
                    Org = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneResistanceMutations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneResistanceMutations_Genes_GeneId",
                        column: x => x.GeneId,
                        principalTable: "Genes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeneUnpublishedStructures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GeneId = table.Column<Guid>(type: "uuid", nullable: false),
                    GeneAccessionNumber = table.Column<string>(type: "text", nullable: true),
                    Organization = table.Column<string>(type: "text", nullable: true),
                    Method = table.Column<string>(type: "text", nullable: true),
                    Resolution = table.Column<string>(type: "text", nullable: true),
                    Condition = table.Column<string>(type: "text", nullable: true),
                    Ligand = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneUnpublishedStructures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneUnpublishedStructures_Genes_GeneId",
                        column: x => x.GeneId,
                        principalTable: "Genes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GeneCRISPRiStrains_GeneId",
                table: "GeneCRISPRiStrains",
                column: "GeneId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneProteinActivityAssays_GeneId",
                table: "GeneProteinActivityAssays",
                column: "GeneId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneProteinProductions_GeneId",
                table: "GeneProteinProductions",
                column: "GeneId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneResistanceMutations_GeneId",
                table: "GeneResistanceMutations",
                column: "GeneId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneUnpublishedStructures_GeneId",
                table: "GeneUnpublishedStructures",
                column: "GeneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneCRISPRiStrains");

            migrationBuilder.DropTable(
                name: "GeneProteinActivityAssays");

            migrationBuilder.DropTable(
                name: "GeneProteinProductions");

            migrationBuilder.DropTable(
                name: "GeneResistanceMutations");

            migrationBuilder.DropTable(
                name: "GeneUnpublishedStructures");
        }
    }
}
