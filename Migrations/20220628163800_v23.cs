using Microsoft.EntityFrameworkCore.Migrations;

namespace Back.Migrations
{
    public partial class v23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KaficID",
                table: "Rezervacija",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_KaficID",
                table: "Rezervacija",
                column: "KaficID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacija_Kafic_KaficID",
                table: "Rezervacija",
                column: "KaficID",
                principalTable: "Kafic",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacija_Kafic_KaficID",
                table: "Rezervacija");

            migrationBuilder.DropIndex(
                name: "IX_Rezervacija_KaficID",
                table: "Rezervacija");

            migrationBuilder.DropColumn(
                name: "KaficID",
                table: "Rezervacija");
        }
    }
}
