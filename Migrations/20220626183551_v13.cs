using Microsoft.EntityFrameworkCore.Migrations;

namespace Back.Migrations
{
    public partial class v13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sto_Kafic_KaficID",
                table: "Sto");

            migrationBuilder.RenameColumn(
                name: "KaficID",
                table: "Sto",
                newName: "KaficFK");

            migrationBuilder.RenameIndex(
                name: "IX_Sto_KaficID",
                table: "Sto",
                newName: "IX_Sto_KaficFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Sto_Kafic_KaficFK",
                table: "Sto",
                column: "KaficFK",
                principalTable: "Kafic",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sto_Kafic_KaficFK",
                table: "Sto");

            migrationBuilder.RenameColumn(
                name: "KaficFK",
                table: "Sto",
                newName: "KaficID");

            migrationBuilder.RenameIndex(
                name: "IX_Sto_KaficFK",
                table: "Sto",
                newName: "IX_Sto_KaficID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sto_Kafic_KaficID",
                table: "Sto",
                column: "KaficID",
                principalTable: "Kafic",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
