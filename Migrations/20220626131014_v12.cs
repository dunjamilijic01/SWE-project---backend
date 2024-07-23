using Microsoft.EntityFrameworkCore.Migrations;

namespace Back.Migrations
{
    public partial class v12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "display",
                table: "Sto",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "m",
                table: "Kafic",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "n",
                table: "Kafic",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "display",
                table: "Sto");

            migrationBuilder.DropColumn(
                name: "m",
                table: "Kafic");

            migrationBuilder.DropColumn(
                name: "n",
                table: "Kafic");
        }
    }
}
