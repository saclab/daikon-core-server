using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class projectscompoundevolution : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectCompoundEvolutions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    CompoundId = table.Column<Guid>(type: "uuid", nullable: false),
                    AddedOnDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AddedOnStage = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    MIC = table.Column<string>(type: "text", nullable: true),
                    IC50 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCompoundEvolutions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectCompoundEvolutions_Compounds_CompoundId",
                        column: x => x.CompoundId,
                        principalTable: "Compounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCompoundEvolutions_CompoundId",
                table: "ProjectCompoundEvolutions",
                column: "CompoundId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectCompoundEvolutions");
        }
    }
}
