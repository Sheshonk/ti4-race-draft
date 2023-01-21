using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DomainObjects.Migrations
{
    /// <inheritdoc />
    public partial class draft : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IconUrl = table.Column<string>(type: "text", nullable: false),
                    WikiUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drafts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GameId = table.Column<int>(type: "integer", nullable: false),
                    GroupId = table.Column<int>(type: "integer", nullable: true),
                    PlayerId = table.Column<int>(type: "integer", nullable: true),
                    RaceId = table.Column<int>(type: "integer", nullable: true),
                    Order = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drafts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drafts_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Drafts_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Drafts_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Drafts_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drafts_GameId",
                table: "Drafts",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Drafts_GroupId",
                table: "Drafts",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Drafts_PlayerId",
                table: "Drafts",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Drafts_RaceId",
                table: "Drafts",
                column: "RaceId");

            migrationBuilder.InsertData(
                table: "Races",
                columns: new[] { "Name", "IconUrl", "WikiUrl", "CreatedDate", "UpdatedDate" },
                values: new object[,]
                {
                    { "Arborec", "/ti_arborec.png", "https://twilight-imperium.fandom.com/wiki/The_Arborec", DateTime.UtcNow, DateTime.UtcNow },
                    { "The Argent Flight", "/ti_argent.png", "https://twilight-imperium.fandom.com/wiki/The_Argent_Flight", DateTime.UtcNow, DateTime.UtcNow },
                    { "The Ghosts of Creuss", "/ti_creuss.png", "https://twilight-imperium.fandom.com/wiki/The_Ghosts_of_Creuss", DateTime.UtcNow, DateTime.UtcNow },
                    { "The Empyrean", "/ti_empyrean.png", "https://twilight-imperium.fandom.com/wiki/The_Empyrean", DateTime.UtcNow, DateTime.UtcNow },
                    { "The Emirates of Hacan", "/ti_hacan.png", "https://twilight-imperium.fandom.com/wiki/The_Emirates_of_Hacan", DateTime.UtcNow, DateTime.UtcNow },
                    { "The Universities of Jol-Nar", "/ti_jolnar.png", "https://twilight-imperium.fandom.com/wiki/The_Universities_of_Jol-Nar", DateTime.UtcNow, DateTime.UtcNow },
                    { "The Council Keleres", "/ti_keleres.png", "https://twilight-imperium.fandom.com/wiki/The_Council_Keleres", DateTime.UtcNow, DateTime.UtcNow },
                    { "The L1Z1X Mindnet", "/ti_l1z1x.png", "https://twilight-imperium.fandom.com/wiki/The_L1Z1X_Mindnet", DateTime.UtcNow, DateTime.UtcNow },
                    { "The Barony of Letnev", "/ti_letnev.png", "https://twilight-imperium.fandom.com/wiki/The_Barony_of_Letnev", DateTime.UtcNow, DateTime.UtcNow },
                    { "The Mahact Gene-Sorcerers", "/ti_mahact.png", "https://twilight-imperium.fandom.com/wiki/The_Mahact_Gene-Sorcerers", DateTime.UtcNow, DateTime.UtcNow },
                    { "The Mentak Coalition", "/ti_mentak.png", "https://twilight-imperium.fandom.com/wiki/The_Mentak_Coalition", DateTime.UtcNow, DateTime.UtcNow },
                    { "The Embers of Muaat", "/ti_muaat.png", "https://twilight-imperium.fandom.com/wiki/The_Embers_of_Muaat", DateTime.UtcNow, DateTime.UtcNow },
                    { "The Naalu Collective", "/ti_naalu.png", "https://twilight-imperium.fandom.com/wiki/The_Naalu_Collective", DateTime.UtcNow, DateTime.UtcNow },
                    { "The Naaz-Rokha Alliance", "/ti_naazrokha.png", "https://twilight-imperium.fandom.com/wiki/The_Naaz-Rokha_Alliance", DateTime.UtcNow, DateTime.UtcNow },
                    { "The Nekro Virus", "/ti_nekro.png", "https://twilight-imperium.fandom.com/wiki/The_Nekro_Virus", DateTime.UtcNow, DateTime.UtcNow },
                    { "The Nomad", "/ti_nomad.png", "https://twilight-imperium.fandom.com/wiki/The_Nomad", DateTime.UtcNow, DateTime.UtcNow },
                    { "Sardakk N'orr", "/ti_norr.png", "https://twilight-imperium.fandom.com/wiki/Sardakk_N%27orr", DateTime.UtcNow, DateTime.UtcNow },
                    { "The Clan of Saar", "/ti_saar.png", "https://twilight-imperium.fandom.com/wiki/The_Clan_of_Saar", DateTime.UtcNow, DateTime.UtcNow },
                    { "The Federation of Sol", "/ti_sol.png", "https://twilight-imperium.fandom.com/wiki/The_Federation_of_Sol", DateTime.UtcNow, DateTime.UtcNow },
                    { "The Titans of Ul", "/ti_ul.png", "https://twilight-imperium.fandom.com/wiki/The_Titans_of_Ul", DateTime.UtcNow, DateTime.UtcNow },
                    { "The Vuil'Raith Cabal", "/ti_vuilraith.png", "https://twilight-imperium.fandom.com/wiki/The_Vuil%27Raith_Cabal", DateTime.UtcNow, DateTime.UtcNow },
                    { "The Winnu", "/ti_winnu.png", "https://twilight-imperium.fandom.com/wiki/The_Winnu", DateTime.UtcNow, DateTime.UtcNow },
                    { "The Xxcha Kingdom", "/ti_xxcha.png", "https://twilight-imperium.fandom.com/wiki/The_Xxcha_Kingdom", DateTime.UtcNow, DateTime.UtcNow },
                    { "The Yin Brotherhood", "/ti_yin.png", "https://twilight-imperium.fandom.com/wiki/The_Yin_Brotherhood", DateTime.UtcNow, DateTime.UtcNow },
                    { "The Yssaril Tribes", "/ti_yssaril.png", "https://twilight-imperium.fandom.com/wiki/The_Yssaril_Tribes", DateTime.UtcNow, DateTime.UtcNow }
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drafts");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Races");
        }
    }
}
