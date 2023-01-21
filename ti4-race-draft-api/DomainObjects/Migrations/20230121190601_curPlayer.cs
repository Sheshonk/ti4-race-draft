using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomainObjects.Migrations
{
    /// <inheritdoc />
    public partial class curPlayer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentPlayerId",
                table: "Games",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentPlayerId",
                table: "Games");
        }
    }
}
