using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class screen_promoter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Screens");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Screens",
                newName: "PromotionDate");

            migrationBuilder.RenameColumn(
                name: "Scientist",
                table: "Screens",
                newName: "Promoter");

            migrationBuilder.AddColumn<Guid>(
                name: "OrgId",
                table: "Screens",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Screens_OrgId",
                table: "Screens",
                column: "OrgId");

            migrationBuilder.AddForeignKey(
                name: "FK_Screens_AppOrgs_OrgId",
                table: "Screens",
                column: "OrgId",
                principalTable: "AppOrgs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Screens_AppOrgs_OrgId",
                table: "Screens");

            migrationBuilder.DropIndex(
                name: "IX_Screens_OrgId",
                table: "Screens");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "Screens");

            migrationBuilder.RenameColumn(
                name: "PromotionDate",
                table: "Screens",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "Promoter",
                table: "Screens",
                newName: "Scientist");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Screens",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
