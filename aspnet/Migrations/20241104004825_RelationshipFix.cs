using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CharacterCreator.Migrations
{
    /// <inheritdoc />
    public partial class RelationshipFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Relationships_Characters_FirstCharacterId",
                table: "Relationships");

            migrationBuilder.AddForeignKey(
                name: "FK_Relationships_Characters_FirstCharacterId",
                table: "Relationships",
                column: "FirstCharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Relationships_Characters_FirstCharacterId",
                table: "Relationships");

            migrationBuilder.AddForeignKey(
                name: "FK_Relationships_Characters_FirstCharacterId",
                table: "Relationships",
                column: "FirstCharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
