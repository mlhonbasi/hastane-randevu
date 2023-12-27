using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_proje.Migrations
{
    /// <inheritdoc />
    public partial class admin2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isAdmin",
                table: "Kullanicilar",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isAdmin",
                table: "Kullanicilar");
        }
    }
}
