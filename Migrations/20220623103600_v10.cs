using Microsoft.EntityFrameworkCore.Migrations;

namespace Back.Migrations
{
    public partial class v10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Kafic_KaficID",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "KaficID",
                table: "AspNetUsers",
                newName: "KaficId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_KaficID",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_KaficId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Kafic_KaficId",
                table: "AspNetUsers",
                column: "KaficId",
                principalTable: "Kafic",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Kafic_KaficId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "KaficId",
                table: "AspNetUsers",
                newName: "KaficID");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_KaficId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_KaficID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Kafic_KaficID",
                table: "AspNetUsers",
                column: "KaficID",
                principalTable: "Kafic",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
