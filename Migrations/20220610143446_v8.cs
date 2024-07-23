using Microsoft.EntityFrameworkCore.Migrations;

namespace Back.Migrations
{
    public partial class v8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Komentar_AspNetUsers_PosetilacId",
                table: "Komentar");

            migrationBuilder.AlterColumn<int>(
                name: "PosetilacId",
                table: "Komentar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Komentar_AspNetUsers_PosetilacId",
                table: "Komentar",
                column: "PosetilacId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Komentar_AspNetUsers_PosetilacId",
                table: "Komentar");

            migrationBuilder.AlterColumn<int>(
                name: "PosetilacId",
                table: "Komentar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Komentar_AspNetUsers_PosetilacId",
                table: "Komentar",
                column: "PosetilacId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
