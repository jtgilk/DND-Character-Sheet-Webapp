using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DND_Character_Sheet_Webapp.Data.Migrations
{
    /// <inheritdoc />
    public partial class DebugTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Player",
                table: "DnD5ePlayerCharacter",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Player",
                table: "DnD5ePlayerCharacter");
        }
    }
}
