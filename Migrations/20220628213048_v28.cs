using Microsoft.EntityFrameworkCore.Migrations;

namespace Back.Migrations
{
    public partial class v28 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacija_Sto_StoFK",
                table: "Rezervacija");

            migrationBuilder.RenameColumn(
                name: "StoFK",
                table: "Rezervacija",
                newName: "StoID");

            migrationBuilder.RenameIndex(
                name: "IX_Rezervacija_StoFK",
                table: "Rezervacija",
                newName: "IX_Rezervacija_StoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacija_Sto_StoID",
                table: "Rezervacija",
                column: "StoID",
                principalTable: "Sto",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacija_Sto_StoID",
                table: "Rezervacija");

            migrationBuilder.RenameColumn(
                name: "StoID",
                table: "Rezervacija",
                newName: "StoFK");

            migrationBuilder.RenameIndex(
                name: "IX_Rezervacija_StoID",
                table: "Rezervacija",
                newName: "IX_Rezervacija_StoFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacija_Sto_StoFK",
                table: "Rezervacija",
                column: "StoFK",
                principalTable: "Sto",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
