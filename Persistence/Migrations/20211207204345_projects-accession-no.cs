using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class projectsaccessionno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AppOrgs_PrimaryOrgId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Compounds_RepresentationStructureId",
                table: "Projects");

            migrationBuilder.AlterColumn<Guid>(
                name: "RepresentationStructureId",
                table: "Projects",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PrimaryOrgId",
                table: "Projects",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccessionNo",
                table: "Projects",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GeneName",
                table: "Projects",
                type: "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_AppOrgs_PrimaryOrgId",
                table: "Projects",
                column: "PrimaryOrgId",
                principalTable: "AppOrgs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Compounds_RepresentationStructureId",
                table: "Projects",
                column: "RepresentationStructureId",
                principalTable: "Compounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AppOrgs_PrimaryOrgId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Compounds_RepresentationStructureId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "AccessionNo",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "GeneName",
                table: "Projects");

            migrationBuilder.AlterColumn<Guid>(
                name: "RepresentationStructureId",
                table: "Projects",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "PrimaryOrgId",
                table: "Projects",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_AppOrgs_PrimaryOrgId",
                table: "Projects",
                column: "PrimaryOrgId",
                principalTable: "AppOrgs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Compounds_RepresentationStructureId",
                table: "Projects",
                column: "RepresentationStructureId",
                principalTable: "Compounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
