using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class redesign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenePromotionRequests_Genes_GeneId",
                table: "GenePromotionRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Targets_Genes_GeneId",
                table: "Targets");

            migrationBuilder.DropIndex(
                name: "IX_Targets_GeneId",
                table: "Targets");

            migrationBuilder.DropIndex(
                name: "IX_GenePromotionRequests_GeneId",
                table: "GenePromotionRequests");

            migrationBuilder.DropColumn(
                name: "GeneId",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "AccessionNo",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "GeneId",
                table: "GenePromotionRequests");

            migrationBuilder.RenameColumn(
                name: "TargetAccessionNumber",
                table: "TargetScoreCardValues",
                newName: "TargetName");

            migrationBuilder.RenameColumn(
                name: "TargetAccessionNumber",
                table: "TargetScorecards",
                newName: "TargetName");

            migrationBuilder.RenameColumn(
                name: "GeneName",
                table: "Targets",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "AccessionNumber",
                table: "Targets",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "AccessionNumber",
                table: "ScreenSequences",
                newName: "TargetName");

            migrationBuilder.RenameColumn(
                name: "AccessionNumber",
                table: "Screens",
                newName: "TargetName");

            migrationBuilder.RenameColumn(
                name: "GeneName",
                table: "Projects",
                newName: "TargetName");

            migrationBuilder.RenameColumn(
                name: "AccessionNumber",
                table: "Hits",
                newName: "TargetName");

            migrationBuilder.RenameColumn(
                name: "GeneAccessionNumber",
                table: "GenePromotionRequests",
                newName: "TargetType");

            migrationBuilder.AddColumn<List<Guid>>(
                name: "GeneIds",
                table: "Targets",
                type: "uuid[]",
                nullable: true);

            migrationBuilder.AddColumn<List<Guid>>(
                name: "GeneIds",
                table: "GenePromotionRequests",
                type: "uuid[]",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TargetName",
                table: "GenePromotionRequests",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Strains",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CanonicalName = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strains", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Targets_Name",
                table: "Targets",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Strains");

            migrationBuilder.DropIndex(
                name: "IX_Targets_Name",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "GeneIds",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "GeneIds",
                table: "GenePromotionRequests");

            migrationBuilder.DropColumn(
                name: "TargetName",
                table: "GenePromotionRequests");

            migrationBuilder.RenameColumn(
                name: "TargetName",
                table: "TargetScoreCardValues",
                newName: "TargetAccessionNumber");

            migrationBuilder.RenameColumn(
                name: "TargetName",
                table: "TargetScorecards",
                newName: "TargetAccessionNumber");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Targets",
                newName: "GeneName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Targets",
                newName: "AccessionNumber");

            migrationBuilder.RenameColumn(
                name: "TargetName",
                table: "ScreenSequences",
                newName: "AccessionNumber");

            migrationBuilder.RenameColumn(
                name: "TargetName",
                table: "Screens",
                newName: "AccessionNumber");

            migrationBuilder.RenameColumn(
                name: "TargetName",
                table: "Projects",
                newName: "GeneName");

            migrationBuilder.RenameColumn(
                name: "TargetName",
                table: "Hits",
                newName: "AccessionNumber");

            migrationBuilder.RenameColumn(
                name: "TargetType",
                table: "GenePromotionRequests",
                newName: "GeneAccessionNumber");

            migrationBuilder.AddColumn<Guid>(
                name: "GeneId",
                table: "Targets",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "AccessionNo",
                table: "Projects",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GeneId",
                table: "GenePromotionRequests",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Targets_GeneId",
                table: "Targets",
                column: "GeneId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GenePromotionRequests_GeneId",
                table: "GenePromotionRequests",
                column: "GeneId");

            migrationBuilder.AddForeignKey(
                name: "FK_GenePromotionRequests_Genes_GeneId",
                table: "GenePromotionRequests",
                column: "GeneId",
                principalTable: "Genes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Targets_Genes_GeneId",
                table: "Targets",
                column: "GeneId",
                principalTable: "Genes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
