using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomainObjects.Migrations
{
    /// <inheritdoc />
    public partial class game : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Groups",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_GameId",
                table: "Groups",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Games_GameId",
                table: "Groups",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Games_GameId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_GameId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Groups");
        }
    }
}
