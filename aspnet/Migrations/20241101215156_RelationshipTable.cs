using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CharacterCreator.Migrations
{
    /// <inheritdoc />
    public partial class RelationshipTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Relationships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstCharacterId = table.Column<int>(type: "int", nullable: false),
                    SecondCharacterId = table.Column<int>(type: "int", nullable: false),
                    RelationshipType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relationships", x => x.Id);
                    table.CheckConstraint("CK_Unique_FKs", "[FirstCharacterId] <> [SecondCharacterId]");
                    table.ForeignKey(
                        name: "FK_Relationships_Characters_FirstCharacterId",
                        column: x => x.FirstCharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Relationships_Characters_SecondCharacterId",
                        column: x => x.SecondCharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Relationships_FirstCharacterId",
                table: "Relationships",
                column: "FirstCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Relationships_SecondCharacterId",
                table: "Relationships",
                column: "SecondCharacterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Relationships");
        }
    }
}
