using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_proje.Migrations
{
    /// <inheritdoc />
    public partial class uptdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HastaneAd",
                table: "Hastaneler",
                newName: "HastaneAdi");

            migrationBuilder.AddColumn<string>(
                name: "PolikinlikAdi",
                table: "Polikinlikler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PolikinlikAdi",
                table: "Polikinlikler");

            migrationBuilder.RenameColumn(
                name: "HastaneAdi",
                table: "Hastaneler",
                newName: "HastaneAd");
        }
    }
}
