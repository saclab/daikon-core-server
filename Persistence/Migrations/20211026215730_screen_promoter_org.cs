using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class screen_promoter_org : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Screens_AppOrgs_OrgId",
                table: "Screens");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrgId",
                table: "Screens",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Screens_AppOrgs_OrgId",
                table: "Screens",
                column: "OrgId",
                principalTable: "AppOrgs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Screens_AppOrgs_OrgId",
                table: "Screens");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrgId",
                table: "Screens",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Screens_AppOrgs_OrgId",
                table: "Screens",
                column: "OrgId",
                principalTable: "AppOrgs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
