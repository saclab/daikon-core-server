using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class researcher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Researcher",
                table: "GeneUnpublishedStructures",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Researcher",
                table: "GeneResistanceMutations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateProduced",
                table: "GeneProteinProductions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Researcher",
                table: "GeneUnpublishedStructures");

            migrationBuilder.DropColumn(
                name: "Researcher",
                table: "GeneResistanceMutations");

            migrationBuilder.DropColumn(
                name: "DateProduced",
                table: "GeneProteinProductions");
        }
    }
}
