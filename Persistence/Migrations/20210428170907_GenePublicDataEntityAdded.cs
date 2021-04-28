using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class GenePublicDataEntityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GenePublicData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    GeneID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: true),
                    Proteomics = table.Column<string>(type: "TEXT", nullable: true),
                    Mutant = table.Column<string>(type: "TEXT", nullable: true),
                    Comments = table.Column<string>(type: "TEXT", nullable: true),
                    Start = table.Column<string>(type: "TEXT", nullable: true),
                    End = table.Column<string>(type: "TEXT", nullable: true),
                    Orientation = table.Column<string>(type: "TEXT", nullable: true),
                    GeneLength = table.Column<string>(type: "TEXT", nullable: true),
                    Location = table.Column<string>(type: "TEXT", nullable: true),
                    MolecularMass = table.Column<string>(type: "TEXT", nullable: true),
                    IsoelectricPoint = table.Column<string>(type: "TEXT", nullable: true),
                    ProteinLength = table.Column<string>(type: "TEXT", nullable: true),
                    PFAM = table.Column<string>(type: "TEXT", nullable: true),
                    M_Leprae = table.Column<string>(type: "TEXT", nullable: true),
                    M_Marinum = table.Column<string>(type: "TEXT", nullable: true),
                    M_Smegmatis = table.Column<string>(type: "TEXT", nullable: true),
                    Cryo = table.Column<string>(type: "TEXT", nullable: true),
                    XRay = table.Column<string>(type: "TEXT", nullable: true),
                    Model = table.Column<string>(type: "TEXT", nullable: true),
                    Ligand = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenePublicData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenePublicData_Genes_GeneID",
                        column: x => x.GeneID,
                        principalTable: "Genes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenePublicData_GeneID",
                table: "GenePublicData",
                column: "GeneID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenePublicData");
        }
    }
}
