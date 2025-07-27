using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebGame.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "Lobbies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<short>(
                name: "MaxPlayers",
                table: "Lobbies",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Lobbies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<short>(
                name: "PlayerCount",
                table: "Lobbies",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "Lobbies");

            migrationBuilder.DropColumn(
                name: "MaxPlayers",
                table: "Lobbies");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Lobbies");

            migrationBuilder.DropColumn(
                name: "PlayerCount",
                table: "Lobbies");
        }
    }
}
