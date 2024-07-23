using Microsoft.EntityFrameworkCore.Migrations;

namespace Back.Migrations
{
    public partial class v18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Obradjen",
                table: "Rezervacija",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ZakazanoVreme",
                table: "Rezervacija",
                type: "varchar(10) CHARACTER SET utf8mb4",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Obradjen",
                table: "Rezervacija");

            migrationBuilder.DropColumn(
                name: "ZakazanoVreme",
                table: "Rezervacija");
        }
    }
}
