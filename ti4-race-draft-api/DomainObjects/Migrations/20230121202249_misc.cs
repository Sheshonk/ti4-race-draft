using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomainObjects.Migrations
{
    /// <inheritdoc />
    public partial class misc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Winner",
                table: "Groups",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Complete",
                table: "Games",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SuperFaction",
                table: "Drafts",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Winner",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "Complete",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "SuperFaction",
                table: "Drafts");
        }
    }
}
