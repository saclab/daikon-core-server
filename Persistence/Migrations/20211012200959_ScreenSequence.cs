using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class ScreenSequence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Screens");

            migrationBuilder.DropColumn(
                name: "Library",
                table: "Screens");

            migrationBuilder.DropColumn(
                name: "Method",
                table: "Screens");

            migrationBuilder.DropColumn(
                name: "Protocol",
                table: "Screens");

            migrationBuilder.AddColumn<string>(
                name: "AccessionNumber",
                table: "Hits",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AspNetRoles",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ScreenSequences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ScreenId = table.Column<Guid>(type: "uuid", nullable: false),
                    AccessionNumber = table.Column<string>(type: "text", nullable: true),
                    Method = table.Column<string>(type: "text", nullable: true),
                    Protocol = table.Column<string>(type: "text", nullable: true),
                    Library = table.Column<string>(type: "text", nullable: true),
                    Scientist = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UnverifiedHitCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScreenSequences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScreenSequences_Screens_ScreenId",
                        column: x => x.ScreenId,
                        principalTable: "Screens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScreenSequences_ScreenId",
                table: "ScreenSequences",
                column: "ScreenId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScreenSequences");

            migrationBuilder.DropColumn(
                name: "AccessionNumber",
                table: "Hits");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AspNetRoles");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Screens",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Library",
                table: "Screens",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Method",
                table: "Screens",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Protocol",
                table: "Screens",
                type: "text",
                nullable: true);
        }
    }
}
