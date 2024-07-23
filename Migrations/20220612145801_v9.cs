using Microsoft.EntityFrameworkCore.Migrations;

namespace Back.Migrations
{
    public partial class v9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrojMesta",
                table: "Kafic",
                type: "int",
                maxLength: 500,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "srednjaOcena",
                table: "Kafic",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrojMesta",
                table: "Kafic");

            migrationBuilder.DropColumn(
                name: "srednjaOcena",
                table: "Kafic");
        }
    }
}
