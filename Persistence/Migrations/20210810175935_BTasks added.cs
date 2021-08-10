using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class BTasksadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GenePublicData_GeneID",
                table: "GenePublicData");

            migrationBuilder.DropIndex(
                name: "IX_GeneNonPublicData_GeneID",
                table: "GeneNonPublicData");

            migrationBuilder.CreateTable(
                name: "BTask",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateCompleted = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BTask", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenePublicData_GeneID",
                table: "GenePublicData",
                column: "GeneID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GeneNonPublicData_GeneID",
                table: "GeneNonPublicData",
                column: "GeneID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BTask");

            migrationBuilder.DropIndex(
                name: "IX_GenePublicData_GeneID",
                table: "GenePublicData");

            migrationBuilder.DropIndex(
                name: "IX_GeneNonPublicData_GeneID",
                table: "GeneNonPublicData");

            migrationBuilder.CreateIndex(
                name: "IX_GenePublicData_GeneID",
                table: "GenePublicData",
                column: "GeneID");

            migrationBuilder.CreateIndex(
                name: "IX_GeneNonPublicData_GeneID",
                table: "GeneNonPublicData",
                column: "GeneID");
        }
    }
}
