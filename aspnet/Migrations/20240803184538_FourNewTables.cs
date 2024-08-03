using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CharacterCreator.Migrations
{
    /// <inheritdoc />
    public partial class FourNewTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EyeColor",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HairColor",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RaceId",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sex",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Factions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_RaceId",
                table: "Characters",
                column: "RaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Races_RaceId",
                table: "Characters",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Races_RaceId",
                table: "Characters");

            migrationBuilder.DropTable(
                name: "Factions");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Races");

            migrationBuilder.DropIndex(
                name: "IX_Characters_RaceId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "EyeColor",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "HairColor",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "RaceId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "Characters");
        }
    }
}
