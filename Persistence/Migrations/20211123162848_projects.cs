using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class projects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectName = table.Column<string>(type: "text", nullable: true),
                    ScreenId = table.Column<Guid>(type: "uuid", nullable: false),
                    RepresentationStructureId = table.Column<Guid>(type: "uuid", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    CurrentStage = table.Column<string>(type: "text", nullable: true),
                    CurrentStageDescription = table.Column<string>(type: "text", nullable: true),
                    PrimaryOrgId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProjectDisclosure = table.Column<string>(type: "text", nullable: true),
                    DisclosureDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Priority = table.Column<string>(type: "text", nullable: true),
                    PriorityDescription = table.Column<string>(type: "text", nullable: true),
                    Probability = table.Column<string>(type: "text", nullable: true),
                    ProbabilityDescription = table.Column<string>(type: "text", nullable: true),
                    Resource = table.Column<string>(type: "text", nullable: true),
                    ResourceDescription = table.Column<string>(type: "text", nullable: true),
                    FHAStart = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    H2LStart = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LOStart = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    SPStart = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PCDDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    INDStart = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    P1Start = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_AppOrgs_PrimaryOrgId",
                        column: x => x.PrimaryOrgId,
                        principalTable: "AppOrgs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_Compounds_RepresentationStructureId",
                        column: x => x.RepresentationStructureId,
                        principalTable: "Compounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Projects_PrimaryOrgId",
                table: "Projects",
                column: "PrimaryOrgId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_RepresentationStructureId",
                table: "Projects",
                column: "RepresentationStructureId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "Projects");

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
        }
    }
}
