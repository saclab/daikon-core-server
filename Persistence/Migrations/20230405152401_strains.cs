using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class strains : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Strains",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DrugResistanceLevel",
                table: "Strains",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "GenomeSequence",
                table: "Strains",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrganismId",
                table: "Strains",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Organisms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CanonicalName = table.Column<string>(type: "text", nullable: true),
                    GeneCount = table.Column<int>(type: "integer", nullable: false),
                    GenomeSequence = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    LastEditAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastEditBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    IsPublished = table.Column<bool>(type: "boolean", nullable: false),
                    IsDraft = table.Column<bool>(type: "boolean", nullable: false),
                    IsPrivate = table.Column<bool>(type: "boolean", nullable: false),
                    IsPublic = table.Column<bool>(type: "boolean", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "boolean", nullable: false),
                    IsLocked = table.Column<bool>(type: "boolean", nullable: false),
                    IsHidden = table.Column<bool>(type: "boolean", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    IsDisabled = table.Column<bool>(type: "boolean", nullable: false),
                    IsApproved = table.Column<bool>(type: "boolean", nullable: false),
                    IsRejected = table.Column<bool>(type: "boolean", nullable: false),
                    IsPending = table.Column<bool>(type: "boolean", nullable: false),
                    IsExpired = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisms", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Strains_OrganismId",
                table: "Strains",
                column: "OrganismId");

            migrationBuilder.AddForeignKey(
                name: "FK_Strains_Organisms_OrganismId",
                table: "Strains",
                column: "OrganismId",
                principalTable: "Organisms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Strains_Organisms_OrganismId",
                table: "Strains");

            migrationBuilder.DropTable(
                name: "Organisms");

            migrationBuilder.DropIndex(
                name: "IX_Strains_OrganismId",
                table: "Strains");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Strains");

            migrationBuilder.DropColumn(
                name: "DrugResistanceLevel",
                table: "Strains");

            migrationBuilder.DropColumn(
                name: "GenomeSequence",
                table: "Strains");

            migrationBuilder.DropColumn(
                name: "OrganismId",
                table: "Strains");
        }
    }
}
