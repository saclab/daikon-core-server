using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class GenomeEntityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genomes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AccessionNumber = table.Column<string>(nullable: true),
                    GeneName = table.Column<string>(nullable: true),
                    Function = table.Column<string>(nullable: true),
                    Product = table.Column<string>(nullable: true),
                    FunctionalCategory = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genomes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Genomes");
        }
    }
}
