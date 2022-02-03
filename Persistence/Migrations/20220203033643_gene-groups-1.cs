using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class genegroups1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeneGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StrainId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GeneGroupGenes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GeneGroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    GeneId = table.Column<Guid>(type: "uuid", nullable: false),
                    StrainId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneGroupGenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneGroupGenes_GeneGroups_GeneGroupId",
                        column: x => x.GeneGroupId,
                        principalTable: "GeneGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneGroupGenes_Genes_GeneId",
                        column: x => x.GeneId,
                        principalTable: "Genes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GeneGroupGenes_GeneGroupId",
                table: "GeneGroupGenes",
                column: "GeneGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneGroupGenes_GeneId",
                table: "GeneGroupGenes",
                column: "GeneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneGroupGenes");

            migrationBuilder.DropTable(
                name: "GeneGroups");
        }
    }
}
