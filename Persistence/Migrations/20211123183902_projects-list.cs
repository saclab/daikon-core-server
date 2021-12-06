using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class projectslist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppOrgs_Projects_ProjectId",
                table: "AppOrgs");

            migrationBuilder.DropForeignKey(
                name: "FK_AppOrgs_Projects_ProjectId1",
                table: "AppOrgs");

            migrationBuilder.DropForeignKey(
                name: "FK_Hits_Projects_ProjectId",
                table: "Hits");

            migrationBuilder.DropIndex(
                name: "IX_Hits_ProjectId",
                table: "Hits");

            migrationBuilder.DropIndex(
                name: "IX_AppOrgs_ProjectId",
                table: "AppOrgs");

            migrationBuilder.DropIndex(
                name: "IX_AppOrgs_ProjectId1",
                table: "AppOrgs");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Hits");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "AppOrgs");

            migrationBuilder.DropColumn(
                name: "ProjectId1",
                table: "AppOrgs");

            migrationBuilder.CreateTable(
                name: "ProjectBaseHits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    HitId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectBaseHits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectBaseHits_Hits_HitId",
                        column: x => x.HitId,
                        principalTable: "Hits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectBaseHits_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectParticipatingOrgs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    AppOrgId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectParticipatingOrgs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectParticipatingOrgs_AppOrgs_AppOrgId",
                        column: x => x.AppOrgId,
                        principalTable: "AppOrgs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectParticipatingOrgs_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectSupportingOrgs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    AppOrgId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectSupportingOrgs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectSupportingOrgs_AppOrgs_AppOrgId",
                        column: x => x.AppOrgId,
                        principalTable: "AppOrgs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectSupportingOrgs_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ScreenId",
                table: "Projects",
                column: "ScreenId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectBaseHits_HitId",
                table: "ProjectBaseHits",
                column: "HitId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectBaseHits_ProjectId",
                table: "ProjectBaseHits",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectParticipatingOrgs_AppOrgId",
                table: "ProjectParticipatingOrgs",
                column: "AppOrgId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectParticipatingOrgs_ProjectId",
                table: "ProjectParticipatingOrgs",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSupportingOrgs_AppOrgId",
                table: "ProjectSupportingOrgs",
                column: "AppOrgId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSupportingOrgs_ProjectId",
                table: "ProjectSupportingOrgs",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Screens_ScreenId",
                table: "Projects",
                column: "ScreenId",
                principalTable: "Screens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Screens_ScreenId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "ProjectBaseHits");

            migrationBuilder.DropTable(
                name: "ProjectParticipatingOrgs");

            migrationBuilder.DropTable(
                name: "ProjectSupportingOrgs");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ScreenId",
                table: "Projects");

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "Hits",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "AppOrgs",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId1",
                table: "AppOrgs",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hits_ProjectId",
                table: "Hits",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOrgs_ProjectId",
                table: "AppOrgs",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOrgs_ProjectId1",
                table: "AppOrgs",
                column: "ProjectId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOrgs_Projects_ProjectId",
                table: "AppOrgs",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppOrgs_Projects_ProjectId1",
                table: "AppOrgs",
                column: "ProjectId1",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hits_Projects_ProjectId",
                table: "Hits",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
