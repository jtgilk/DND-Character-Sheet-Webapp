using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DND_Character_Sheet_Webapp.Data.Migrations
{
    /// <inheritdoc />
    public partial class Weapons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DnD5eWeapon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WeightInPounds = table.Column<int>(type: "int", nullable: false),
                    CostInGoldPieces = table.Column<int>(type: "int", nullable: false),
                    WeaponType = table.Column<int>(type: "int", nullable: false),
                    DamageDice = table.Column<int>(type: "int", nullable: false),
                    NumberOfDice = table.Column<int>(type: "int", nullable: false),
                    BonusDamage = table.Column<int>(type: "int", nullable: false),
                    IsMagical = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DnD5eWeapon", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DnD5eWeapon");

            migrationBuilder.CreateTable(
                name: "Weapon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapon", x => x.Id);
                });
        }
    }
}
