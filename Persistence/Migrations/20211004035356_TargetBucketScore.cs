using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class TargetBucketScore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Score",
                table: "Targets",
                newName: "LikeScore");

            migrationBuilder.AddColumn<string>(
                name: "Bucket",
                table: "Targets",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ImpactScore",
                table: "Targets",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bucket",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "ImpactScore",
                table: "Targets");

            migrationBuilder.RenameColumn(
                name: "LikeScore",
                table: "Targets",
                newName: "Score");
        }
    }
}
