using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class Orgs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Archived",
                table: "AspNetUsers",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Lock",
                table: "AspNetUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "OrgId",
                table: "AspNetUsers",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppOrgs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Alias = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppOrgs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_OrgId",
                table: "AspNetUsers",
                column: "OrgId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AppOrgs_OrgId",
                table: "AspNetUsers",
                column: "OrgId",
                principalTable: "AppOrgs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AppOrgs_OrgId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AppOrgs");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_OrgId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Archived",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Lock",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "AspNetUsers");
        }
    }
}
