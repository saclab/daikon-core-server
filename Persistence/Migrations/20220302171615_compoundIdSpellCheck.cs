using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class compoundIdSpellCheck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExternalCompundIds",
                table: "Compounds",
                newName: "ExternalCompoundIds");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExternalCompoundIds",
                table: "Compounds",
                newName: "ExternalCompundIds");
        }
    }
}
