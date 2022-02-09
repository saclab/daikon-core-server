using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class gene_renames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Condition",
                table: "GeneUnpublishedStructures");

            migrationBuilder.RenameColumn(
                name: "Ligand",
                table: "GeneUnpublishedStructures",
                newName: "Ligands");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "GeneProteinProductions",
                newName: "Production");

            migrationBuilder.RenameColumn(
                name: "ProteinProduction",
                table: "GeneProteinProductions",
                newName: "Method");

            migrationBuilder.RenameColumn(
                name: "ProteinActivityAssay",
                table: "GeneProteinActivityAssays",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "AssayType",
                table: "GeneProteinActivityAssays",
                newName: "Throughput");

            migrationBuilder.RenameColumn(
                name: "AssayThroughput",
                table: "GeneProteinActivityAssays",
                newName: "Activity");

            migrationBuilder.RenameColumn(
                name: "EssentialityCondition",
                table: "GeneEssentiality",
                newName: "Condition");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ligands",
                table: "GeneUnpublishedStructures",
                newName: "Ligand");

            migrationBuilder.RenameColumn(
                name: "Production",
                table: "GeneProteinProductions",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "Method",
                table: "GeneProteinProductions",
                newName: "ProteinProduction");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "GeneProteinActivityAssays",
                newName: "ProteinActivityAssay");

            migrationBuilder.RenameColumn(
                name: "Throughput",
                table: "GeneProteinActivityAssays",
                newName: "AssayType");

            migrationBuilder.RenameColumn(
                name: "Activity",
                table: "GeneProteinActivityAssays",
                newName: "AssayThroughput");

            migrationBuilder.RenameColumn(
                name: "Condition",
                table: "GeneEssentiality",
                newName: "EssentialityCondition");

            migrationBuilder.AddColumn<string>(
                name: "Condition",
                table: "GeneUnpublishedStructures",
                type: "text",
                nullable: true);
        }
    }
}
