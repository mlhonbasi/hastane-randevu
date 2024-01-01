using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_proje.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Kullanicilar_KullaniciId",
                table: "Randevular");

            migrationBuilder.AlterColumn<int>(
                name: "KullaniciId",
                table: "Randevular",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "CalismaSaati",
                columns: table => new
                {
                    CalismaSaatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    secilenTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Baslangic = table.Column<TimeSpan>(type: "time", nullable: false),
                    Bitis = table.Column<TimeSpan>(type: "time", nullable: false),
                    DoktorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalismaSaati", x => x.CalismaSaatId);
                    table.ForeignKey(
                        name: "FK_CalismaSaati_Doktorlar_DoktorId",
                        column: x => x.DoktorId,
                        principalTable: "Doktorlar",
                        principalColumn: "DoktorId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalismaSaati_DoktorId",
                table: "CalismaSaati",
                column: "DoktorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Kullanicilar_KullaniciId",
                table: "Randevular",
                column: "KullaniciId",
                principalTable: "Kullanicilar",
                principalColumn: "KullaniciId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Kullanicilar_KullaniciId",
                table: "Randevular");

            migrationBuilder.DropTable(
                name: "CalismaSaati");

            migrationBuilder.AlterColumn<int>(
                name: "KullaniciId",
                table: "Randevular",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Kullanicilar_KullaniciId",
                table: "Randevular",
                column: "KullaniciId",
                principalTable: "Kullanicilar",
                principalColumn: "KullaniciId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
