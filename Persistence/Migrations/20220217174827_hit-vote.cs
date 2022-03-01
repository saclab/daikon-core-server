using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class hitvote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "VoteId",
                table: "Hits",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Hits_VoteId",
                table: "Hits",
                column: "VoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hits_Votes_VoteId",
                table: "Hits",
                column: "VoteId",
                principalTable: "Votes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hits_Votes_VoteId",
                table: "Hits");

            migrationBuilder.DropIndex(
                name: "IX_Hits_VoteId",
                table: "Hits");

            migrationBuilder.DropColumn(
                name: "VoteId",
                table: "Hits");
        }
    }
}
