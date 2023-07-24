using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DND_Character_Sheet_Webapp.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DnD5ePlayerCharacter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Race = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    charStrength = table.Column<int>(type: "int", nullable: false),
                    charDexterity = table.Column<int>(type: "int", nullable: false),
                    charConstitution = table.Column<int>(type: "int", nullable: false),
                    charIntelligence = table.Column<int>(type: "int", nullable: false),
                    charWisdom = table.Column<int>(type: "int", nullable: false),
                    charCharisma = table.Column<int>(type: "int", nullable: false),
                    HitPoints = table.Column<int>(type: "int", nullable: false),
                    Background = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alignment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DnD5ePlayerCharacter", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DnD5ePlayerCharacter");
        }
    }
}
