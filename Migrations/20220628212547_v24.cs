using Microsoft.EntityFrameworkCore.Migrations;

namespace Back.Migrations
{
    public partial class v24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Rezervacija_StoFK",
                table: "Rezervacija");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_StoFK",
                table: "Rezervacija",
                column: "StoFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Rezervacija_StoFK",
                table: "Rezervacija");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_StoFK",
                table: "Rezervacija",
                column: "StoFK",
                unique: true);
        }
    }
}
