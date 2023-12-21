using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_proje.Migrations
{
    /// <inheritdoc />
    public partial class modelguncelleme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HastaneId",
                table: "Randevular",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PolikinlikId",
                table: "Randevular",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_HastaneId",
                table: "Randevular",
                column: "HastaneId");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_PolikinlikId",
                table: "Randevular",
                column: "PolikinlikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Hastaneler_HastaneId",
                table: "Randevular",
                column: "HastaneId",
                principalTable: "Hastaneler",
                principalColumn: "HastaneId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Polikinlikler_PolikinlikId",
                table: "Randevular",
                column: "PolikinlikId",
                principalTable: "Polikinlikler",
                principalColumn: "PolikinlikId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Hastaneler_HastaneId",
                table: "Randevular");

            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Polikinlikler_PolikinlikId",
                table: "Randevular");

            migrationBuilder.DropIndex(
                name: "IX_Randevular_HastaneId",
                table: "Randevular");

            migrationBuilder.DropIndex(
                name: "IX_Randevular_PolikinlikId",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "HastaneId",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "PolikinlikId",
                table: "Randevular");
        }
    }
}
