using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class votes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Voters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    VoteId = table.Column<Guid>(type: "uuid", nullable: false),
                    VoterEmail = table.Column<string>(type: "text", nullable: true),
                    VotedPositive = table.Column<bool>(type: "boolean", nullable: false),
                    VotedNeutral = table.Column<bool>(type: "boolean", nullable: false),
                    VotedNegative = table.Column<bool>(type: "boolean", nullable: false),
                    VotedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ElementId = table.Column<Guid>(type: "uuid", nullable: false),
                    Positive = table.Column<int>(type: "integer", nullable: false),
                    Neutral = table.Column<int>(type: "integer", nullable: false),
                    Negative = table.Column<int>(type: "integer", nullable: false),
                    IsVotingAllowed = table.Column<bool>(type: "boolean", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Voters");

            migrationBuilder.DropTable(
                name: "Votes");
        }
    }
}
